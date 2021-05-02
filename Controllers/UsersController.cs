using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MyAspTest.Domain;
using MyAspTest.Models;
using MyAspTest.ViewModel;

namespace MyAspTest.Controllers
{
    public class UsersController : Controller
    {
        private readonly AppDbContext _context;

        public UsersController(AppDbContext context)
        {
            _context = context;
        }

        public ActionResult FilteredIndex(int? company, string name)
        {
            IQueryable<User> users = _context.Users.Include(u => u.Position).Include(u => u.Status);
            if (company != null && company != 0)
            {
                users = users.Where(p => p.PositionId == company);
            }
            if (!String.IsNullOrEmpty(name))
            {
                users = users.Where(p => p.Name.Contains(name));
            }

            List<Position> positions = _context.Positions.ToList();
            
            positions.Insert(0, new Position() { Name = "Все", Id = 0 });

            List<Status> status = _context.Statuses.ToList();
            status.Insert(0, new Status { Name = "Все", Id = 0 });
            

            UserFilterViewModel viewModel = new UserFilterViewModel
            {
                Users = users.ToList(),
                PositionSelectList = new SelectList(positions, "Id", "Name"),
                StatusList = new SelectList(status, "Id", "Name") 
            };
            return View(viewModel);
        }

        // GET: Users
        public async Task<IActionResult> Index(SortState sortOrder = SortState.NameAsc)
        {
            IQueryable<User> users = _context.Users.Include(u => u.Position).Include(u => u.Status);

            users = sortOrder switch
            {
                SortState.NameDesc => users.OrderByDescending(s => s.Name),
                SortState.SurNameAsc => users.OrderBy(s => s.Surname),
                SortState.SurNameDesc => users.OrderByDescending(s => s.Surname),
                _ => users.OrderBy(s => s.Name),
            };
            IndexViewModel viewModel = new IndexViewModel
            {
                Users = await users.AsNoTracking().ToListAsync(),
                SortViewModel = new SortViewModel(sortOrder)
            };

            //var appDbContext = _context.Users.Include(u => u.Position).Include(u => u.Status);
            //await appDbContext.ToListAsync()
            return View(viewModel);
        }

        // GET: Users/Details
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var user = await _context.Users
                .Include(u => u.Position)
                .Include(u => u.Status)
                .FirstOrDefaultAsync(m => m.ID == id);
            if (user == null)
            {
                return NotFound();
            }

            return View(user);
        }

        // GET: Users/Create
        public IActionResult Create()
        {
            ViewData["PositionId"] = new SelectList(_context.Positions, "Id", "Name");
            ViewData["StatusId"] = new SelectList(_context.Statuses, "Id", "Name");
            return View();
        }

        // POST: Users/Create        /    
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,Name,Surname,Phone,PositionId,StatusId")] User user)
        {
            if (ModelState.IsValid)
            {
                _context.Add(user);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["PositionId"] = new SelectList(_context.Positions, "Id", "Name", user.PositionId);
            ViewData["StatusId"] = new SelectList(_context.Statuses, "Id", "Name", user.StatusId);
            return View(user);
        }

        // GET: Users/Edit
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var user = await _context.Users.FindAsync(id);
            if (user == null)
            {
                return NotFound();
            }
            ViewData["PositionId"] = new SelectList(_context.Positions, "Id", "Name", user.PositionId);
            ViewData["StatusId"] = new SelectList(_context.Statuses, "Id", "Name", user.StatusId);
            return View(user);
        }

        // POST: Users/Edit        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,Name,Surname,Phone,PositionId,StatusId")] User user)
        {
            if (id != user.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(user);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!UserExists(user.ID))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["PositionId"] = new SelectList(_context.Positions, "Id", "Name", user.PositionId);
            ViewData["StatusId"] = new SelectList(_context.Statuses, "Id", "Name", user.StatusId);
            return View(user);
        }

        // GET: Users/Delete
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var user = await _context.Users
                .Include(u => u.Position)
                .Include(u => u.Status)
                .FirstOrDefaultAsync(m => m.ID == id);
            if (user == null)
            {
                return NotFound();
            }

            return View(user);
        }

        // POST: Users/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var user = await _context.Users.FindAsync(id);
            _context.Users.Remove(user);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool UserExists(int id)
        {
            return _context.Users.Any(e => e.ID == id);
        }
    }
}
