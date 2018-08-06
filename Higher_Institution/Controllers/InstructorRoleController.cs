using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Higher_Institution.Data;
using Higher_Institution.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Higher_Institution.Controllers
{
    public class InstructorRoleController : Controller
    {
        private readonly InstructorDbContext _context;
        private readonly UserManager<InstructorUser> _userManager;

        public InstructorRoleController(InstructorDbContext context,
            UserManager<InstructorUser> userManager,

            IOptions<IdentityCookieOptions> identityCookieOptions)
        {
            _context = context;
            _userManager = userManager;

        }


        public IActionResult IndexRole()
        {
            var Roles = _context.Roles.ToList();

            return View(Roles);
        }

        //GET
        public IActionResult CreateRole()
        {
            var Role = new IdentityRole();
            return View(Role);
        }

        //POST
        [HttpPost]
        public async Task<IActionResult> CreateRole(IdentityRole Role)
        {
            _context.Roles.Add(Role);
            await _context.SaveChangesAsync();
            return RedirectToAction("IndexRole");
        }

        //GET
        public IActionResult EditRole(string id)
        {
            var item = _context.Roles.First(r => r.Name == id);

            //var Role = new IdentityRole();
            return View(item);
        }

        //POST
        [HttpPost]
        public IActionResult EditRole(IdentityRole Role, string id)
        {
            if (ModelState.IsValid)
            {
                var role = _context.Roles.First(r => r.Name == id);

                role.Name = Role.Name;
                role.NormalizedName = Role.NormalizedName;

                _context.Entry(role).State = EntityState.Modified;
                _context.SaveChanges();
                return RedirectToAction("IndexRole");
            }

            return View(Role);
        }
    }
}