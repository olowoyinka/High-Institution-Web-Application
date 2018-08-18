 using Higher_Institution.Data;
using Higher_Institution.Models;
using Higher_Institution.Models.AccountViewModels;
using Higher_Institution.Models.InstructorViewModels;
using Higher_Institution.Models.ViewModels;
using Higher_Institution.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Higher_Institution.Controllers
{
    [Authorize]
    public class InstructorsController : Controller
    {
        private readonly UserManager<InstructorUser> _userManager;
        private readonly SignInManager<InstructorUser> _signInManager;
        private readonly InstructorDbContext _Instructorcontext;
        private readonly ApplicationDbContext _context;
        private IHostingEnvironment _environment;
        private readonly IEmailSender _emailSender;
        private readonly ISmsSender _smsSender;
        private readonly ILogger _logger;
        private readonly string _externalCookieScheme;

        public InstructorsController(
           UserManager<InstructorUser> userManager,
           SignInManager<InstructorUser> signInManager,
           IOptions<IdentityCookieOptions> identityCookieOptions,
           InstructorDbContext Instructorcontext,
           ApplicationDbContext context,
           IHostingEnvironment environment,
           IEmailSender emailSender,
           ISmsSender smsSender,
           ILoggerFactory loggerFactory)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _externalCookieScheme = identityCookieOptions.Value.ExternalCookieAuthenticationScheme;
            _emailSender = emailSender;
            _smsSender = smsSender;
            _environment = environment;
            _context = context;
            _Instructorcontext = Instructorcontext;
            _logger = loggerFactory.CreateLogger<InstructorsController>();
        }





        //
        // GET: /Account/Register
        [HttpGet]
        [AllowAnonymous]
        public IActionResult Register(string returnUrl = null)
        {
            ViewData["DepartmentID"] = new SelectList(_context.Department.OrderBy(m => m.Name), "DepartmentID", "Name");
            
            ViewData["ReturnUrl"] = returnUrl;
            return View();
        }

        //
        // POST: /Account/Register
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(RegisterInstructorViewModel model, IFormFile ProfilePictureFile, string returnUrl = null)
        {
            ViewData["ReturnUrl"] = returnUrl;
            if (ModelState.IsValid)
            {
                if (ProfilePictureFile != null)
                {
                    var fnm = model.IdentityNumber;
                    var filename = fnm + DateTime.Now.ToString("MMddHHmmss") + ".jpg";

                    string uploadPath = Path.Combine(_environment.WebRootPath, "images/Instructor/");

                    if (filename.Contains('\\'))
                    {
                        filename = filename.Split('\\').Last();
                    }

                    using (FileStream fs = new FileStream(Path.Combine(uploadPath, filename), FileMode.Append))
                    {
                        await ProfilePictureFile.CopyToAsync(fs);
                    }

                    model.AvatarImage = filename;
                }


                var user = new InstructorUser

                {
                    UserName = model.IdentityNumber,
                    Email = model.Email,
                    IdentityNumber = model.IdentityNumber,
                    Surname = model.Surname,
                    FirstName = model.FirstName,
                    MiddleName = model.MiddleName,
                    FullName = model.FullName,
                    Gender = model.Gender,
                    DateofBirth = model.DateofBirth,
                    State = model.State,
                    Address = model.Address,
                    ParentName = model.ParentName,
                    ParentAddress = model.ParentAddress,
                    Image = model.AvatarImage,
                    DepartmentID = model.DepartmentID,
                    

                };
                var result = await _userManager.CreateAsync(user, model.Surname);
                if (result.Succeeded)
                {
                    //await _userManager.AddToRolesAsync(user, new[] { "Instructor" });
                    // For more information on how to enable account confirmation and password reset please visit https://go.microsoft.com/fwlink/?LinkID=532713
                    // Send an email with this link
                    //var code = await _userManager.GenerateEmailConfirmationTokenAsync(user);
                    //var callbackUrl = Url.Action(nameof(ConfirmEmail), "Account", new { userId = user.Id, code = code }, protocol: HttpContext.Request.Scheme);
                    //await _emailSender.SendEmailAsync(model.Email, "Confirm your account",
                    //    $"Please confirm your account by clicking this link: <a href='{callbackUrl}'>link</a>");
                    await _signInManager.SignInAsync(user, isPersistent: false);
                    _logger.LogInformation(3, "User created a new account with password.");
                    return RedirectToLocal(returnUrl);
                }
                AddErrors(result);
            }

            // If we got this far, something failed, redisplay form
            return View(model);
        }




        //
        // GET: /Account/Login
        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> Login(string returnUrl = null)
        {
            // Clear the existing external cookie to ensure a clean login process
            await HttpContext.Authentication.SignOutAsync(_externalCookieScheme);

            ViewData["ReturnUrl"] = returnUrl;
            return View();
        }

        //
        // POST: /Account/Login
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginInstructorViewModel model, string returnUrl = null)
        {
            ViewData["ReturnUrl"] = returnUrl;
            if (ModelState.IsValid)
            {
                // This doesn't count login failures towards account lockout
                // To enable password failures to trigger account lockout, set lockoutOnFailure: true
                var result = await _signInManager.PasswordSignInAsync(model.Email, model.Password, model.RememberMe, lockoutOnFailure: false);
                if (result.Succeeded)
                {
                    _logger.LogInformation(1, "User logged in.");
                    return RedirectToLocal(returnUrl);
                }
                if (result.RequiresTwoFactor)
                {
                    return RedirectToAction(nameof(SendCode), new { ReturnUrl = returnUrl, RememberMe = model.RememberMe });
                }
                if (result.IsLockedOut)
                {
                    _logger.LogWarning(2, "User account locked out.");
                    return View("Lockout");
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "Invalid login attempt.");
                    return View(model);
                }
            }

            // If we got this far, something failed, redisplay form
            return View(model);
        }




        [HttpGet]
        public async Task<IActionResult> RegisterCourse()
        {
            var user = await GetCurrentUserAsync();

            var StudentUser = await _userManager.Users
                        .Include(i => i.Department)                                                  
                        .Include(i => i.InstructorCourse)
                            .ThenInclude(e => e.Course)
                       .AsNoTracking()
                .SingleOrDefaultAsync(m => m.Id == user.Id);



            PopulateAssignedCourseData(StudentUser);

            ViewData["DepartmentID"] = new SelectList(_context.Department.OrderBy(m => m.Name), "DepartmentID", "Name");

            return View(StudentUser);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> RegisterCourse(string[] selectedCourses)
        {
            var user = await GetCurrentUserAsync();          
            var StudentUser = await _userManager.Users
                        .Include(i => i.Department)                                        
                        .Include(i => i.InstructorCourse)
                            .ThenInclude(e => e.Course)
                .SingleOrDefaultAsync(m => m.Id == user.Id);

            if (await TryUpdateModelAsync<InstructorUser>(
                    StudentUser,
                    ""))
            {
                UpdateStudentCourse(selectedCourses, StudentUser);
         
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
        public async Task<IActionResult> ViewCoursesAssign ()
        {
            var user = await GetCurrentUserAsync();

                var InstructorUser = await _userManager.Users
                                        .Include(i => i.Department)
                                        .Include(i => i.InstructorCourse)
                                            .ThenInclude(e => e.Course)                                 
                                        .SingleOrDefaultAsync(m => m.Id == user.Id);

            return View(InstructorUser);
        }

        [HttpPost]
        public async Task<IActionResult> ViewCoursesAssign(InstructorUser userdetails)
        {
            var user = await GetCurrentUserAsync();

            
            user.AssignCourse = userdetails.AssignCourse;

            var InstructorUser = await _userManager.Users
                                    .Include(i => i.Department)
                                    .Include(i => i.InstructorCourse)
                                        .ThenInclude(e => e.Course)
                                    .SingleOrDefaultAsync(m => m.Id == user.Id);

            var result =  await _userManager.UpdateAsync(user);

            if (result.Succeeded)
            {

                return RedirectToAction("CoursesAssignScore","Instructors");
            }

            return View(InstructorUser);
        }


        [HttpGet]
        public async Task<IActionResult> CoursesAssignScore()
        {

            var user = await GetCurrentUserAsync();

            string SearchString = user.AssignCourse;

            var ViewModel = new InstructorIndexData();

            ViewModel.InstructorUser = await _userManager.Users
                                    .Include(i => i.Department)
                                    .Include(i => i.InstructorCourse)
                                        .ThenInclude(e => e.Course)
                                          .ThenInclude(e => e.GeneratedStudentCourse)
                                    .AsNoTracking()
                                    .SingleOrDefaultAsync(m => m.Id == user.Id);

            var students = from s in _context.GeneratedStudentCourse
                                   .Include(i => i.ApplicationUser)
                                   .Include(i => i.Course)
                                      .OrderBy(m => m.ApplicationUser.IdentityNumber)
                           select s;

            if (!String.IsNullOrEmpty(SearchString))
            {
                students = students.Where(s => s.Course.Name.Contains(SearchString));
                                       
            }

            ViewModel.GeneratedStudentCourse = await students.AsNoTracking().ToListAsync();

            return View(ViewModel);
        }



        [HttpPost]
        public IActionResult UploadScore(InstructorIndexData model)
        {

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
            return RedirectToAction("SubmissionOfResult");
        }


        [HttpGet]
        public async Task<IActionResult> SubmissionOfResult()
        {
            var user = await GetCurrentUserAsync();

            var StudentUser = await _userManager.Users
                        .Include(i => i.Department)
                        .Include(i => i.InstructorCourse)
                            .ThenInclude(e => e.Course)
                                .ThenInclude(e => e.GeneratedStudentCourse)
                            .AsNoTracking()
                            .SingleOrDefaultAsync(m => m.Id == user.Id);


            PopulateAssignedSubmissionOfResult(StudentUser);

            

            return View(StudentUser);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> SubmissionOfResult(string[] selectedCourses)
        {
            var user = await GetCurrentUserAsync();
            var StudentUser = await _userManager.Users
                        .Include(i => i.Department)
                        .Include(i => i.CarryOverStudentCourse)
                        .Include(i => i.GeneratedStudentCourse)
                        .Include(i => i.InstructorCourse)
                            .ThenInclude(e => e.Course)
                .SingleOrDefaultAsync(m => m.Id == user.Id);

            if (await TryUpdateModelAsync<InstructorUser>(
                    StudentUser,
                    ""))
            {
                UpdateSubmissionOfResult(selectedCourses, StudentUser);

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



        //
        // GET: /Account/SendCode
        [HttpGet]
        [AllowAnonymous]
        public async Task<ActionResult> SendCode(string returnUrl = null, bool rememberMe = false)
        {
            var user = await _signInManager.GetTwoFactorAuthenticationUserAsync();
            if (user == null)
            {
                return View("Error");
            }
            var userFactors = await _userManager.GetValidTwoFactorProvidersAsync(user);
            var factorOptions = userFactors.Select(purpose => new SelectListItem { Text = purpose, Value = purpose }).ToList();
            return View(new SendCodeViewModel { Providers = factorOptions, ReturnUrl = returnUrl, RememberMe = rememberMe });
        }

        //
        // POST: /Account/SendCode
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> SendCode(SendCodeViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }

            var user = await _signInManager.GetTwoFactorAuthenticationUserAsync();
            if (user == null)
            {
                return View("Error");
            }

            // Generate the token and send it
            var code = await _userManager.GenerateTwoFactorTokenAsync(user, model.SelectedProvider);
            if (string.IsNullOrWhiteSpace(code))
            {
                return View("Error");
            }

            var message = "Your security code is: " + code;
            if (model.SelectedProvider == "Email")
            {
                await _emailSender.SendEmailAsync(await _userManager.GetEmailAsync(user), "Security Code", message);
            }
            else if (model.SelectedProvider == "Phone")
            {
                await _smsSender.SendSmsAsync(await _userManager.GetPhoneNumberAsync(user), message);
            }

            return RedirectToAction(nameof(VerifyCode), new { Provider = model.SelectedProvider, ReturnUrl = model.ReturnUrl, RememberMe = model.RememberMe });
        }

        //
        // GET: /Account/VerifyCode
        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> VerifyCode(string provider, bool rememberMe, string returnUrl = null)
        {
            // Require that the user has already logged in via username/password or external login
            var user = await _signInManager.GetTwoFactorAuthenticationUserAsync();
            if (user == null)
            {
                return View("Error");
            }
            return View(new VerifyCodeViewModel { Provider = provider, ReturnUrl = returnUrl, RememberMe = rememberMe });
        }

        //
        // POST: /Account/VerifyCode
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> VerifyCode(VerifyCodeViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            // The following code protects for brute force attacks against the two factor codes.
            // If a user enters incorrect codes for a specified amount of time then the user account
            // will be locked out for a specified amount of time.
            var result = await _signInManager.TwoFactorSignInAsync(model.Provider, model.Code, model.RememberMe, model.RememberBrowser);
            if (result.Succeeded)
            {
                return RedirectToLocal(model.ReturnUrl);
            }
            if (result.IsLockedOut)
            {
                _logger.LogWarning(7, "User account locked out.");
                return View("Lockout");
            }
            else
            {
                ModelState.AddModelError(string.Empty, "Invalid code.");
                return View(model);
            }
        }





        private void AddErrors(IdentityResult result)
        {
            foreach (var error in result.Errors)
            {
                ModelState.AddModelError(string.Empty, error.Description);
            }
        }



        private IActionResult RedirectToLocal(string returnUrl)
        {
            if (Url.IsLocalUrl(returnUrl))
            {
                return Redirect(returnUrl);
            }
            else
            {
                return RedirectToAction(nameof(HomeController.Index), "Home");
            }
        }



        private void PopulateAssignedCourseData(InstructorUser Student)
        {

            var allCourses = _context.Course.Include(m => m.Department);
                             
   

            var instructorCourses = new HashSet<int>(Student.InstructorCourse.Select(c => c.Course.CourseID));
            var viewModel = new List<AssignedCourseData>();
            foreach (var course in allCourses)
            {
                viewModel.Add(new AssignedCourseData
                {
                    CourseID = course.CourseID,
                    Names = course.Name,                    
                    CourseCode = course.CourseCode,
                    Departments = course.Department.Name,                                    
                    Assigned = instructorCourses.Contains(course.CourseID)
                });
            }

            ViewData["Courses"] = viewModel;
        }


        private void UpdateStudentCourse(string[] selectedCourses, InstructorUser ApplicationUser)
        {

            if (selectedCourses == null)
            {
                ApplicationUser.InstructorCourse = new List<InstructorCourse>();
                return;
            }


            var selectedCoursesHS = new HashSet<string>(selectedCourses);
            var StudentCourses = new HashSet<int>
            (ApplicationUser.InstructorCourse.Select(c => c.Course.CourseID));


            foreach (var course in _context.Course)
            {
                if (selectedCoursesHS.Contains(course.CourseID.ToString()))
                {
                    if (!StudentCourses.Contains(course.CourseID))
                    {
                        ApplicationUser.InstructorCourse.Add(new InstructorCourse
                        {
                            CourseID = course.CourseID,
                            InstructorUserId = ApplicationUser.Id,
                                                       
                        });

                    }
                }
                else
                {
                    if (StudentCourses.Contains(course.CourseID))
                    {
                        InstructorCourse courseToRemove = ApplicationUser.InstructorCourse.SingleOrDefault(i => i.CourseID ==
                        course.CourseID);
                        _Instructorcontext.Remove(courseToRemove);
                    }
                }
            }


        }


        private void PopulateAssignedSubmissionOfResult(InstructorUser Instructor)
        {
            string SearchString = Instructor.AssignCourse;


            var studentsallCourses = from s in _context.GeneratedStudentCourse
                                  .Include(i => i.ApplicationUser)
                                  .Include(i => i.Course)
                                     .OrderBy(m => m.ApplicationUser.IdentityNumber)
                           select s;

            if (!String.IsNullOrEmpty(SearchString))
            {
                studentsallCourses = studentsallCourses.Where(s => s.Course.Name.Contains(SearchString));

            }
            
            var instructorCourses = new HashSet<int>(studentsallCourses.Select(c => c.GeneratedStudentCourseID));

            var viewModel = new List<CarryOverAssigned>();

            foreach (var course in studentsallCourses)
            {
                viewModel.Add(new CarryOverAssigned
                {
                    ApplicationUserName = course.ApplicationUser.FullName,
                    GeneratedStudentCourseID = course.GeneratedStudentCourseID,
                    Grade = course.Grade,
                    ApplicationUserIdentityNumber = course.ApplicationUser.IdentityNumber,
                    Assigned = instructorCourses.Contains(course.GeneratedStudentCourseID)
                });
            }

            ViewData["Courses"] = viewModel;
        }




        private void UpdateSubmissionOfResult(string[] selectedCourses, InstructorUser ApplicationUser)
        {
            if (selectedCourses == null)
            {
                ApplicationUser.CarryOverStudentCourse = new List<CarryOverStudentCourse>();
                return;
            }


            var selectedCoursesHS = new HashSet<string>(selectedCourses);
            var StudentCourses = new HashSet<string>
            (ApplicationUser.CarryOverStudentCourse.Select(c => c.ApplicationIdCourseName));

           



            foreach (var course in _context.GeneratedStudentCourse.Include(c => c.Semester))
            {
                if (selectedCoursesHS.Contains(course.GeneratedStudentCourseID.ToString()))
                {
                    if (!StudentCourses.Contains(course.ApplicationIdCourseId))
                    {
                        ApplicationUser.CarryOverStudentCourse.Add(new CarryOverStudentCourse
                        {
                            InstructorUserId = ApplicationUser.Id,
                            ApplicationUserId = course.ApplicationUserId,
                            CourseID = course.CourseID,
                            EntryYearID = course.EntryYearID,
                            SemesterID = course.SemesterID,
                            FullName = course.FullName,
                            Grade = course.Grade,
                            ApplicationIdSemesterGrade = course.ApplicationUserId + course.Semester.Name + course.Grade,
                            ApplicationIdCourseName = course.ApplicationIdCourseId
                        });

                    }
                }
                else
                {
                    if (StudentCourses.Contains(course.ApplicationIdCourseId))
                    {

                        CarryOverStudentCourse courseToRemove = _context.CarryOverStudentCourse
                            .Include(a => a.Semester)
                            .Include(a => a.EntryYear)
                            .Include(a => a.ApplicationUser)
                            .Include(a => a.Course)
                            .Where(a => a.ApplicationIdCourseName.Equals(course.ApplicationIdCourseId)).FirstOrDefault();
                        _context.Remove(courseToRemove);

                        //DeleteConfirmed(course.ApplicationIdCourseId);


                        //var c = _context.CarryOverStudentCourse
                        //    .Include(a => a.Semester)
                        //    .Include(a => a.EntryYear)
                        //    .Include(a => a.ApplicationUser)
                        //    .Include(a => a.Course)
                        //    .Where(a => a.ApplicationIdCourseName.Equals(course.ApplicationIdCourseId)).FirstOrDefault();

                        //if (c != null)
                        //{

                    


                        //    c.Grade = course.Grade;
                        //}


                        // _context.SaveChanges();
                    }




                    //CarryOverStudentCourse courseToRemove = ApplicationUser.CarryOverStudentCourse.SingleOrDefault(i => i.ApplicationIdCourseName ==
                    //    course.ApplicationIdCourseId);
                    //_context.Remove(courseToRemove);

                    //DeleteConfirmed(course.ApplicationIdCourseId);

                }
            }

        }

        private  void DeleteConfirmed(string id)
        {
            var course = _context.CarryOverStudentCourse.SingleOrDefaultAsync(m => m.ApplicationIdCourseName == id);

            _context.Remove(course);

             _context.SaveChangesAsync();
            
        }

        private Task<InstructorUser> GetCurrentUserAsync()
        {
            return _userManager.GetUserAsync(HttpContext.User);
        }

    }
}