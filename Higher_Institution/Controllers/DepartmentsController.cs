using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Higher_Institution.Data;
using Microsoft.EntityFrameworkCore;

namespace Higher_Institution.Controllers
{
    public class DepartmentsController : Controller
    {

        private readonly ApplicationDbContext _context;

        public DepartmentsController ( ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var model = _context.Department
                                    .OrderBy(c => c.Name);
            return View(await model.ToListAsync());
        }


        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }


            var model =  await _context.Department
                            .Include(m => m.Instructor)
                                .SingleOrDefaultAsync(m => m.DepartmentID == id);

            return View(model);
        }
    }
}