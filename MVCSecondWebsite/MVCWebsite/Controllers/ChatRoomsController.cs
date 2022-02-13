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
    public class ChatRoomsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ChatRoomsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: ChatRooms
        public async Task<IActionResult> Index()
        {
            return View(await _context.ChatRoom.ToListAsync());
        }

        // GET: ChatRooms/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var chatRoom = await _context.ChatRoom
                .FirstOrDefaultAsync(m => m.Id == id);
            if (chatRoom == null)
            {
                return NotFound();
            }

            return View(chatRoom);
        }

        // GET: ChatRooms/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: ChatRooms/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id")] ChatRoom chatRoom)
        {
            if (ModelState.IsValid)
            {
                _context.Add(chatRoom);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(chatRoom);
        }

        // GET: ChatRooms/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var chatRoom = await _context.ChatRoom.FindAsync(id);
            if (chatRoom == null)
            {
                return NotFound();
            }
            return View(chatRoom);
        }

        // POST: ChatRooms/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id")] ChatRoom chatRoom)
        {
            if (id != chatRoom.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(chatRoom);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ChatRoomExists(chatRoom.Id))
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
            return View(chatRoom);
        }

        // GET: ChatRooms/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var chatRoom = await _context.ChatRoom
                .FirstOrDefaultAsync(m => m.Id == id);
            if (chatRoom == null)
            {
                return NotFound();
            }

            return View(chatRoom);
        }

        // POST: ChatRooms/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var chatRoom = await _context.ChatRoom.FindAsync(id);
            _context.ChatRoom.Remove(chatRoom);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ChatRoomExists(int id)
        {
            return _context.ChatRoom.Any(e => e.Id == id);
        }
    }
}
