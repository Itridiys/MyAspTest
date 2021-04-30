using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using MyAspTest.Domain;
using MyAspTest.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyAspTest.Controllers
{
    public class PositionViewmodelController : Controller
    {
        private readonly AppDbContext _context;

        public PositionViewmodelController(AppDbContext context)
        {
            _context = context;
        }

        // GET: PositionViewmodelController
        public ActionResult Index()
        {
            return View();
        }

        // GET: PositionViewmodelController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: PositionViewmodelController/Create
        public IActionResult Create()
        {
            ViewData["DepartmentId"] = new SelectList(_context.Departments, "Id", "Name");
            return View();
        }

        // POST: PositionViewmodelController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create ([Bind("Id,Name,Salary,MaxNumber,DepartmentId")] Position position, [Bind("Id,Name")] Department department)
        {
            if (ModelState.IsValid)
            {
                position.DepartmentId = department.Id;

                _context.AddRange(position,department);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["DepartmentId"] = new SelectList(_context.Departments, "Id", "Name", position.DepartmentId);
            return View();
            
        }

        // GET: PositionViewmodelController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: PositionViewmodelController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: PositionViewmodelController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: PositionViewmodelController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
