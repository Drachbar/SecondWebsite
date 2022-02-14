#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MVCWebsite.Data;
using Website.Models;

namespace MVCWebsite.Controllers
{
    public class UserChatRoomsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public UserChatRoomsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: UserChatRooms
        public async Task<IActionResult> Index()
        {
            return View(await _context.UserChatRoom.ToListAsync());
        }

        // GET: UserChatRooms/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var userChatRoom = await _context.UserChatRoom
                .FirstOrDefaultAsync(m => m.Id == id);
            if (userChatRoom == null)
            {
                return NotFound();
            }

            return View(userChatRoom);
        }

        // GET: UserChatRooms/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: UserChatRooms/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,UserId,ChatRoomId")] UserChatRoom userChatRoom)
        {
            if (ModelState.IsValid)
            {
                _context.Add(userChatRoom);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(userChatRoom);
        }

        // GET: UserChatRooms/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var userChatRoom = await _context.UserChatRoom.FindAsync(id);
            if (userChatRoom == null)
            {
                return NotFound();
            }
            return View(userChatRoom);
        }

        // POST: UserChatRooms/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,UserId,ChatRoomId")] UserChatRoom userChatRoom)
        {
            if (id != userChatRoom.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(userChatRoom);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!UserChatRoomExists(userChatRoom.Id))
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
            return View(userChatRoom);
        }

        // GET: UserChatRooms/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var userChatRoom = await _context.UserChatRoom
                .FirstOrDefaultAsync(m => m.Id == id);
            if (userChatRoom == null)
            {
                return NotFound();
            }

            return View(userChatRoom);
        }

        // POST: UserChatRooms/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var userChatRoom = await _context.UserChatRoom.FindAsync(id);
            _context.UserChatRoom.Remove(userChatRoom);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool UserChatRoomExists(int id)
        {
            return _context.UserChatRoom.Any(e => e.Id == id);
        }
    }
}
