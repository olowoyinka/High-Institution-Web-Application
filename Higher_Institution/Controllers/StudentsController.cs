using Higher_Institution.Data;
using Higher_Institution.Models;
using Higher_Institution.Models.ViewModels;
using Higher_Institution.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Higher_Institution.Controllers
{
    [Authorize]
    public class StudentsController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly ApplicationDbContext _context;
        private readonly IEmailSender _emailSender;
        private readonly ISmsSender _smsSender;
        private readonly ILogger _logger;
        private readonly string _externalCookieScheme;

        public StudentsController(
           UserManager<ApplicationUser> userManager,
           SignInManager<ApplicationUser> signInManager,
           IOptions<IdentityCookieOptions> identityCookieOptions,
           ApplicationDbContext context,
           IEmailSender emailSender,
           ISmsSender smsSender,
           ILoggerFactory loggerFactory)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _externalCookieScheme = identityCookieOptions.Value.ExternalCookieAuthenticationScheme;
            _emailSender = emailSender;
            _smsSender = smsSender;
            _context = context;
            _logger = loggerFactory.CreateLogger<StudentsController>();
        }


        public async Task<IActionResult> Index()
        {
            var user = await GetCurrentUserAsync();

            var StudentUser = await _userManager.Users
                        .Include(i => i.Department)
                        .Include(i => i.EntryYear)
                        .Include(i => i.Semester)
                        .Include(i => i.Level)
                        .Include(i => i.StudentCourse)
                            .ThenInclude(e => e.Course)
                        /* .Include(i => i.StudentCourse)
                            .ThenInclude(e => e.EntryYear)
                        .Include(i => i.StudentCourse)
                            .ThenInclude(e => e.Semester) */

                        .AsNoTracking()
                .SingleOrDefaultAsync(m => m.Id == user.Id);

            ViewData["ree"] = StudentUser.DepartmentID + " " + StudentUser.Semester.Name + " " + StudentUser.Level.Name;

            return View();
        }



        [HttpGet]
        public async Task<IActionResult> RegisterCourse()
        {
            var user = await GetCurrentUserAsync();
          
            var StudentUser = await _userManager.Users
                        .Include(i => i.Department)
                        .Include(i => i.EntryYear)
                        .Include(i => i.Semester)
                        .Include(i => i.Level)
                        .Include(i => i.StudentCourse)
                            .ThenInclude(e => e.Course)
                        .Include(i => i.CarryOverStudentCourse)
                            .ThenInclude(e => e.Course)
                           
                        /* .Include(i => i.StudentCourse)
                            .ThenInclude(e => e.EntryYear)
                        .Include(i => i.StudentCourse)
                            .ThenInclude(e => e.Semester) */

                        .AsNoTracking()
                .SingleOrDefaultAsync(m => m.Id == user.Id);

            

            PopulateAssignedCourseData(StudentUser);

            ViewData["DepartmentID"] = new SelectList(_context.Department.OrderBy(m => m.Name), "DepartmentID", "Name");
            ViewData["EntryYearID"] = new SelectList(_context.EntryYear.OrderByDescending(m => m.Name), "EntryYearID", "Name");
            ViewData["SemesterID"] = new SelectList(_context.Semester.OrderByDescending(m => m.Name), "SemesterID", "Name");

            return View(StudentUser);
        }



        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> RegisterCourse(string[] selectedCourses, ApplicationUser ApplicationUsers)
        {
            var user = await GetCurrentUserAsync();

            // string modelid = _userManager.GetUserId(HttpContext.User);

            var StudentUser = await _userManager.Users
                        .Include(i => i.Department)
                        .Include(i => i.EntryYear)
                        .Include(i => i.Semester)
                        .Include(i => i.Level)
                        .Include(i => i.ViewStudentCourse)
                        .Include(i => i.StudentCourse)
                            .ThenInclude(e => e.Course)
                            
                /* .Include(i => i.StudentCourse)
                    .ThenInclude(e => e.EntryYear)
                .Include(i => i.StudentCourse)
                    .ThenInclude(e => e.Semester) */

                //.AsNoTracking()

                .SingleOrDefaultAsync(m => m.Id == user.Id);


            if (await TryUpdateModelAsync<ApplicationUser>(
                    StudentUser,
                    ""))
            {
                


                UpdateStudentCourse(selectedCourses, StudentUser);

               


                await UpdateViewStudentCourse(StudentUser,StudentUser.EntryYear.Name);



                try
                {
                    
                    await _userManager.UpdateAsync(StudentUser);
                    
                }
                catch (DbUpdateException /* ex */)
                {
                    //Log the error (uncomment ex variable name and write a log.)
                    ModelState.AddModelError("", "Unable to save changes. " +
                    "Try again, and if the problem persists, " +
                    "see your system administrator.");
                }


                return RedirectToAction("RegisterCourse");
            }

            return View(StudentUser);
        }






        [HttpGet]
        public async Task<IActionResult> CoursePrint()
        {
            var user = await GetCurrentUserAsync();

            //var modelid = _userManager.GetUserId(HttpContext.User);

            var StudentUser = await _userManager.Users
                        .Include(i => i.Department)
                        .Include(i => i.EntryYear)
                        .Include(i => i.Semester)
                        .Include(i => i.Level)
                        .Include(i => i.StudentCourse)
                            .ThenInclude(e => e.Course)
                        /* .Include(i => i.StudentCourse)
                            .ThenInclude(e => e.EntryYear)
                        .Include(i => i.StudentCourse)
                            .ThenInclude(e => e.Semester) */

                        .AsNoTracking()
                .SingleOrDefaultAsync(m => m.Id == user.Id);



            GeneratedAssignedCourseData(StudentUser);

            ViewData["DepartmentID"] = new SelectList(_context.Department.OrderBy(m => m.Name), "DepartmentID", "Name");
            ViewData["EntryYearID"] = new SelectList(_context.EntryYear.OrderByDescending(m => m.Name), "EntryYearID", "Name");
            ViewData["SemesterID"] = new SelectList(_context.Semester.OrderByDescending(m => m.Name), "SemesterID", "Name");

            return View(StudentUser);
        }



        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CoursePrint(string[] selectedCourses, ApplicationUser ApplicationUsers)
        {
            var user = await GetCurrentUserAsync();

            // string modelid = _userManager.GetUserId(HttpContext.User);

            var StudentUser = await _userManager.Users
                        .Include(i => i.Department)
                        .Include(i => i.EntryYear)
                        .Include(i => i.Semester)
                        .Include(i => i.Level)
                        .Include(i => i.ViewStudentCourse)
                        .Include(i => i.StudentCourse)
                            .ThenInclude(e => e.Course)
                        .Include(i => i.GeneratedStudentCourse)
                            .ThenInclude(e => e.Course)

                /* .Include(i => i.StudentCourse)
                    .ThenInclude(e => e.EntryYear)
                .Include(i => i.StudentCourse)
                    .ThenInclude(e => e.Semester) */

                //.AsNoTracking()

                .SingleOrDefaultAsync(m => m.Id == user.Id);


            if (await TryUpdateModelAsync<ApplicationUser>(
                    StudentUser,
                    ""))
            {



                GeneratedStudentCourse(selectedCourses, StudentUser);
              


                try
                {

                    await _userManager.UpdateAsync(StudentUser);

                }
                catch (DbUpdateException /* ex */)
                {
                    //Log the error (uncomment ex variable name and write a log.)
                    ModelState.AddModelError("", "Unable to save changes. " +
                    "Try again, and if the problem persists, " +
                    "see your system administrator.");
                }


                return RedirectToAction("Index");
            }

            return View(StudentUser);
        }





        private void PopulateAssignedCourseData(ApplicationUser Student)
        {
            string SearchString = Student.DepartmentID + " " + Student.Semester.Name + " " + Student.Level.Name;

            string SearchStringcarryoverCourses = Student.Id + Student.Semester.Name + "F";


            var allCourses = from s in _context.Course.Include(m => m.Department)
                             select s;

            var carryoverCourses = from s in _context.CarryOverStudentCourse.Include(m => m.Course)
                                   select s;

            if (!String.IsNullOrEmpty(SearchString))
            {
                allCourses = allCourses.Where(s => s.FullName.Contains(SearchString));
            }


            if (!String.IsNullOrEmpty(SearchStringcarryoverCourses))
            {
                carryoverCourses = carryoverCourses.Where(s => s.ApplicationIdSemesterGrade.Contains(SearchStringcarryoverCourses));
            }

            var instructorCourses = new HashSet<int>(Student.StudentCourse.Select(c => c.Course.CourseID));
            var viewModel = new List<AssignedCourseData>();
            foreach (var course in allCourses)
            {
                viewModel.Add(new AssignedCourseData
                {
                    CourseID = course.CourseID,
                    Names = course.Name,
                    Levels = course.Level,
                    CourseCode = course.CourseCode,
                    Departments = course.Department.Name,
                    Semesters = course.Semester,
                    FullName = course.FullName,
                    Assigned = instructorCourses.Contains(course.CourseID)
                });
            }

            foreach (var carry in carryoverCourses)
            {
                viewModel.Add(new AssignedCourseData
                {
                    CourseID = carry.CourseID,
                    CourseCode = carry.Course.CourseCode,
                    Names = carry.Course.Name,
                    //CarryIdentity = carry.CarryOverStudentCourseID,
                    Assigned = instructorCourses.Contains(carry.CourseID)
                });
            }
            ViewData["Courses"] = viewModel;
        }








        private void UpdateStudentCourse(string[] selectedCourses, ApplicationUser ApplicationUser)
        {

            if (selectedCourses == null)
            {
                ApplicationUser.StudentCourse = new List<StudentCourse>();
                return;
            }

           
            var selectedCoursesHS = new HashSet<string>(selectedCourses);
            var StudentCourses = new HashSet<int>
            (ApplicationUser.StudentCourse.Select(c => c.Course.CourseID));


            foreach (var course in _context.Course)
            {
                if (selectedCoursesHS.Contains(course.CourseID.ToString()))
                {
                    if (!StudentCourses.Contains(course.CourseID))
                    {
                        ApplicationUser.StudentCourse.Add(new StudentCourse
                        {
                            ApplicationUserId = ApplicationUser.Id,
                            CourseID = course.CourseID,
                            EntryYearID = ApplicationUser.EntryYearID,
                            SemesterID = ApplicationUser.SemesterID,
                            FullName = course.FullName,
                            ApplicationIdCourseId = ApplicationUser.Id + course.CourseID

                        });
                      
                    }
                }
                else
                {
                    if (StudentCourses.Contains(course.CourseID))
                    {
                        StudentCourse courseToRemove = ApplicationUser.StudentCourse.SingleOrDefault(i => i.CourseID ==
                        course.CourseID);
                        _context.Remove(courseToRemove);
                    }
                }
            }


        }

   
        




        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> UpdateViewStudentCourse(ApplicationUser ApplicationUser,string id)
        {
           // var  = new ViewStudentCourse();

            var ViewStudentCourse = _context.ViewStudentCourse;

            var StudentCourses = new HashSet<string>
           (ViewStudentCourse.Select(c => c.FindCollection));

            var FullNamess = ApplicationUser.DepartmentID + " " + ApplicationUser.Semester.Name+ " " + ApplicationUser.Level.Name;
            var FindCollectionss = ApplicationUser.Id + " " + FullNamess;

            if (!StudentCourses.Contains(FindCollectionss) )
            {
                
                var model = new ViewStudentCourse()
                {

                    ApplicationUserId = ApplicationUser.Id,
                    Semester = ApplicationUser.Semester.Name,
                    Level = ApplicationUser.Level.Name,
                    Name = ApplicationUser.Department.DepartmentID,
                    FullName = FullNamess,
                    FindCollection = FindCollectionss,
                    EntryYear = ApplicationUser.EntryYear.Name


                };

                _context.Add(model);
                await _context.SaveChangesAsync();
                return View(ApplicationUser);
            }

            else if(StudentCourses.Contains(FindCollectionss) && !StudentCourses.Contains(FindCollectionss))
            {
               
                
                    ViewStudentCourse courses = await _context.ViewStudentCourse
                                                    .SingleOrDefaultAsync(m => m.FindCollection == id);
                    _context.ViewStudentCourse.Remove(courses);
                    await _context.SaveChangesAsync();
                    
                
            }
            return View();
        }



        private void GeneratedAssignedCourseData(ApplicationUser Student)
        {
            var allCourses = _context.Course.Include(m => m.Department);
                                    
            var instructorCourses = new HashSet<int>(Student.StudentCourse.Select(c => c.Course.CourseID));
            var viewModel = new List<AssignedCourseData>();
            foreach (var course in allCourses)
            {
                viewModel.Add(new AssignedCourseData
                {
                    CourseID = course.CourseID,
                    Names = course.Name,
                    Levels = course.Level,
                    CourseCode = course.CourseCode,
                    Departments = course.Department.Name,
                    Semesters = course.Semester,
                    FullName = course.FullName,
                    Assigned = instructorCourses.Contains(course.CourseID)
                });
            }
            ViewData["Courses"] = viewModel;
        }


        private void GeneratedStudentCourse(string[] selectedCourses, ApplicationUser ApplicationUser)
        {

            if (selectedCourses == null)
            {
                ApplicationUser.GeneratedStudentCourse = new List<GeneratedStudentCourse>();
                return;
            }


            var selectedCoursesHS = new HashSet<string>(selectedCourses);
            var StudentCourses = new HashSet<int>
            (ApplicationUser.GeneratedStudentCourse.Select(c => c.Course.CourseID));


            foreach (var course in _context.Course)
            {
                if (selectedCoursesHS.Contains(course.CourseID.ToString()))
                {
                    if (!StudentCourses.Contains(course.CourseID))
                    {
                        ApplicationUser.GeneratedStudentCourse.Add(new GeneratedStudentCourse
                        {
                            ApplicationUserId = ApplicationUser.Id,
                            CourseID = course.CourseID,
                            EntryYearID = ApplicationUser.EntryYearID,
                            SemesterID = ApplicationUser.SemesterID,
                            FullName = course.FullName,
                            ApplicationIdCourseId = ApplicationUser.Id + course.Name
                        });

                    }
                }
                else
                {
                    if (StudentCourses.Contains(course.CourseID)&& !StudentCourses.Contains(course.CourseID))
                    {
                        GeneratedStudentCourse courseToRemove = ApplicationUser.GeneratedStudentCourse.SingleOrDefault(i => i.CourseID ==
                        course.CourseID);
                        _context.Remove(courseToRemove);
                    }
                }
            }


        }






        private Task<ApplicationUser> GetCurrentUserAsync()
        {
            return _userManager.GetUserAsync(HttpContext.User);
        }
    }
}