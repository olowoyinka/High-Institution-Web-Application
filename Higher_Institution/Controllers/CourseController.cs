using Higher_Institution.Data;
using Higher_Institution.Models;
using Higher_Institution.Models.InstructorViewModels;
using Higher_Institution.Models.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Higher_Institution.Controllers
{
    public class CourseController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<InstructorUser> _userManager;

        public CourseController(ApplicationDbContext context, UserManager<InstructorUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

       
        // GET: Course
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Course
                                            .Include(c => c.Department)
                                               .OrderBy(c => c.Department);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Course/Details/5
        [Authorize]
        [HttpGet]
        public async Task<IActionResult> CourseDetail(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ViewModel = new InstructorIndexData();

            var user = await GetCurrentUserAsync();


            ViewModel.InstructorUser = await _userManager.Users
                                    .Include(i => i.Department)
                                    .Include(i => i.InstructorCourse)
                                        .ThenInclude(e => e.Course)
                                          .ThenInclude(e => e.GeneratedStudentCourse)
                            //  .ThenInclude(e => e.ApplicationUser)
                            /* .Include(i => i.StudentCourse)
                                .ThenInclude(e => e.EntryYear)
                            .Include(i => i.StudentCourse)
                                .ThenInclude(e => e.Semester) */

                            .AsNoTracking()
                            .SingleOrDefaultAsync(m => m.Id == user.Id);


            

            ViewModel.Course = await _context.Course
                .Include(c => c.GeneratedStudentCourse)
                    .ThenInclude(c => c.ApplicationUser)
                .Include(c => c.Department)
                .SingleOrDefaultAsync(m => m.Name == id);


            ViewModel.GeneratedStudentCourse = await _context.GeneratedStudentCourse
                                                    .Include(i => i.ApplicationUser)
                                                    .Include(i => i.Course)
                                                        .OrderBy(m => m.ApplicationUser.IdentityNumber)
                                                    .ToListAsync();

            if (ViewModel.Course == null)
            {
                return NotFound();
            }

            return View(ViewModel);
        }

        [HttpPost]
        public IActionResult UploadScore(InstructorIndexData model)
        {

            //var model = new InstructorIndexData();


            if (ModelState.IsValid)
            {

                foreach (var i in model.GeneratedStudentCourse)
                {
                    var c = _context.GeneratedStudentCourse
                        .Include(a => a.Semester)
                        .Include(a => a.EntryYear)
                        .Include(a => a.ApplicationUser)
                        .Include(a => a.Course)
                        .Where(a => a.GeneratedStudentCourseID.Equals(i.GeneratedStudentCourseID)).FirstOrDefault();

                    if (c != null)
                    {
                        c.GeneratedStudentCourseID = i.GeneratedStudentCourseID;

                        

                        c.Grade = i.Grade;
                    }
                }

                _context.SaveChanges();

            }
            return RedirectToAction("Index");
        }



        // GET: Course/Create
        public IActionResult AddCourse()
        {
            ViewData["DepartmentID"] = new SelectList(_context.Department.OrderBy(c => c.Name), "DepartmentID", "Name");
            return View();
        }

        // POST: Course/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddCourse([Bind("CourseID,Name,CourseCode,Level,Semester,DepartmentID")] Course course)
        {
            if (ModelState.IsValid)
            {
                var model = new Course()
                {

                    CourseID = course.CourseID,
                    CourseCode = course.CourseCode,
                    Semester = course.Semester,
                    Level = course.Level,
                    Name = course.Name,
                    DepartmentID = course.DepartmentID,
                    FullName = course.Full,
                };

                _context.Add(model);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewData["DepartmentID"] = new SelectList(_context.Department.OrderBy(c => c.Name), "DepartmentID", "Name", course.DepartmentID);
            return View(course);
        }

        // GET: Course/Edit/5
        public async Task<IActionResult> CourseEdit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var course = await _context.Course.SingleOrDefaultAsync(m => m.Name == id);
            if (course == null)
            {
                return NotFound();
            }
            ViewData["DepartmentID"] = new SelectList(_context.Department.OrderBy(c => c.Name), "DepartmentID", "Name", course.DepartmentID);
            return View(course);
        }

        // POST: Course/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CourseEdit(string id, [Bind("CourseID,Name,Level,CourseCode,Semester,DepartmentID")] Course course)
        {
            if (id != course.Name)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(course);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CourseExists(course.Name))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction("Index");
            }
            ViewData["DepartmentID"] = new SelectList(_context.Department.OrderBy(c => c.Name), "DepartmentID", "Name", course.DepartmentID);
            return View(course);
        }

        // GET: Course/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var course = await _context.Course
                .Include(c => c.Department)
                .SingleOrDefaultAsync(m => m.CourseID == id);
            if (course == null)
            {
                return NotFound();
            }

            return View(course);
        }

        // POST: Course/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var course = await _context.Course.SingleOrDefaultAsync(m => m.CourseID == id);
            _context.Course.Remove(course);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        private bool CourseExists(string id)
        {
            return _context.Course.Any(e => e.Name == id);
        }

        private Task<InstructorUser> GetCurrentUserAsync()
        {
            return _userManager.GetUserAsync(HttpContext.User);
        }
    }
}
