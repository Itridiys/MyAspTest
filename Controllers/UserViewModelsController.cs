using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyAspTest.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.View;
using MyAspTest.Models;
using MyAspTest.ViewModel;

namespace MyAspTest.Controllers
{
    public class UserViewModelsController : Controller
    {
        private readonly AppDbContext _context;
        
        public UserViewModelsController(AppDbContext context)
        {
            _context = context;

        }

        // GET: UserViewModelsController
        public ActionResult Index()
        {
            return View();
        }

        // GET: UserViewModelsController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: UserViewModelsController/Create
        public IActionResult Create()
        {
            ViewData["PositionId"] = new SelectList(_context.Positions, "Id", "Name");
            ViewData["StatusId"] = new SelectList(_context.Statuses, "Id", "Name");
            return View();
        }

        // POST: UserViewModelsController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,Name,Surname,Phone,PositionId,StatusId,UserInfoId")] User user, 
            [Bind("Id,HireTime,CurrentTime,FireTime,IsWorking,UserId")] UserInfo userInfo)
        {
            if (ModelState.IsValid)
            {
                userInfo.IsWorking = true;
                userInfo.CurrentTime = DateTime.Now;


                if (user.StatusId == 4)
                {
                    userInfo.FireTime = DateTime.Now;
                }

                _context.Add(userInfo);
                await _context.SaveChangesAsync();
                user.UserInfoId = userInfo.Id;
                _context.Add(user);
                await _context.SaveChangesAsync();

                return RedirectToAction("Index", "Users");
            }

            ViewData["PositionId"] = new SelectList(_context.Positions, "Id", "Name");
            ViewData["StatusId"] = new SelectList(_context.Statuses, "Id", "Name");
            return View();
            
        }

        // GET: UserViewModelsController/Edit/5
        public async Task<IActionResult> Edit(int? id, int? infoId)
        {
            if (id == null)
            {
                return NotFound();
            }

            var user = await _context.Users.FindAsync(id);
            var info = await _context.UserInfos.FirstOrDefaultAsync(u => u.Id == user.UserInfoId);
            var confUser = new MapperConfiguration(cfg => cfg.CreateMap<User, UserViewModel>() );

            var mapper = new Mapper(confUser);
            var viewUsers = mapper.Map<User, UserViewModel>(user);

            viewUsers.CurrentTime = info.CurrentTime;
            viewUsers.HireTime = info.HireTime;
            viewUsers.FireTime = info.FireTime;

            

            if (user == null)
            {
                return NotFound();
            }
            ViewData["PositionId"] = new SelectList(_context.Positions, "Id", "Name", user.PositionId);
            ViewData["StatusId"] = new SelectList(_context.Statuses, "Id", "Name", user.StatusId);
            return View(viewUsers);
        }

        // POST: UserViewModelsController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id,  [Bind("ID,Name,Surname,Phone,PositionId,StatusId")] User user,
            [Bind("Id,HireTime,CurrentTime,FireTime,IsWorking")] UserInfo userInfo)
        {
            if (id != user.ID )
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    var infoId = DataWorker.GetUserById(id);
                    userInfo.IsWorking = true;
                    user.ID = id;
                    user.UserInfoId = infoId.UserInfoId;
                    userInfo.Id = infoId.UserInfoId;
                    userInfo.CurrentTime = DateTime.Now;

                    if (user.StatusId == 4)
                    {
                        userInfo.FireTime = DateTime.Now;
                        userInfo.IsWorking = false;
                    }

                    _context.UpdateRange(user,userInfo);
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
                return RedirectToAction("Index", "Users");
            }
            ViewData["PositionId"] = new SelectList(_context.Positions, "Id", "Name", user.PositionId);
            ViewData["StatusId"] = new SelectList(_context.Statuses, "Id", "Name", user.StatusId);
            return View();
        }

        // GET: UserViewModelsController/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var user = await _context.Users
                .Include(u => u.Position)
                .FirstOrDefaultAsync(m => m.ID == id);
            if (user == null)
            {
                return NotFound();
            }
            ViewData["PositionId"] = new SelectList(_context.Positions, "Id", "Name", user.PositionId);
            ViewData["StatusId"] = new SelectList(_context.Statuses, "Id", "Name", user.StatusId);
            return View(user);
        }

        // POST: UserViewModelsController/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id)
        {
            var user = await _context.Users.FindAsync(id);
            var info = await _context.UserInfos.FindAsync(user.UserInfoId);
            //_context.Users.Remove(user);
            _context.RemoveRange(user,info);
            await _context.SaveChangesAsync();
            
            return RedirectToAction("Index", "Users");
        }

        private bool UserExists(int id)
        {
            return _context.Users.Any(e => e.ID == id);
        }
    }
}
