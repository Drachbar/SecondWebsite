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
    public class ChatMessageController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ChatMessageController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: ChatMessagesModels
        public async Task<IActionResult> Index()
        {
            return View(await _context.ChatMessagesModel.ToListAsync());
        }

        // GET: ChatMessagesModels/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var chatMessagesModel = await _context.ChatMessagesModel
                .FirstOrDefaultAsync(m => m.Id == id);
            if (chatMessagesModel == null)
            {
                return NotFound();
            }

            return View(chatMessagesModel);
        }

        // GET: ChatMessagesModels/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: ChatMessagesModels/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,ChatRoomId,ChatMessage,DateTime,UserName,UserId")] ChatMessage chatMessagesModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(chatMessagesModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(chatMessagesModel);
        }

        // GET: ChatMessagesModels/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var chatMessagesModel = await _context.ChatMessagesModel.FindAsync(id);
            if (chatMessagesModel == null)
            {
                return NotFound();
            }
            return View(chatMessagesModel);
        }

        // POST: ChatMessagesModels/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,ChatRoomId,ChatMessage,DateTime,UserName,UserId")] ChatMessage chatMessagesModel)
        {
            if (id != chatMessagesModel.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(chatMessagesModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ChatMessagesModelExists(chatMessagesModel.Id))
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
            return View(chatMessagesModel);
        }

        // GET: ChatMessagesModels/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var chatMessagesModel = await _context.ChatMessagesModel
                .FirstOrDefaultAsync(m => m.Id == id);
            if (chatMessagesModel == null)
            {
                return NotFound();
            }

            return View(chatMessagesModel);
        }

        // POST: ChatMessagesModels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var chatMessagesModel = await _context.ChatMessagesModel.FindAsync(id);
            _context.ChatMessagesModel.Remove(chatMessagesModel);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ChatMessagesModelExists(int id)
        {
            return _context.ChatMessagesModel.Any(e => e.Id == id);
        }
    }
}
