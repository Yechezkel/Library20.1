using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Library10.Models;
using Library20.Data;

namespace Library20.Controllers
{
    public class ShelvesController : Controller
    {
        private readonly Library20Context _context;

        public ShelvesController(Library20Context context)
        {
            _context = context;
        }

        // GET: Shelves
        public async Task<IActionResult> Index()
        {
            var library20Context = _context.Shelf.Include(s => s.Library);
            return View(await library20Context.ToListAsync());
        }

        // GET: Shelves/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var shelf = await _context.Shelf
                .Include(s => s.Library)
                .FirstOrDefaultAsync(m => m.ShelfId == id);
            if (shelf == null)
            {
                return NotFound();
            }

            return View(shelf);
        }

        // GET: Shelves/Create
        public IActionResult Create()
        {
            ViewData["LibraryId"] = new SelectList(_context.Library, "LibraryId", "LibraryName");
            return View();
        }

        // POST: Shelves/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ShelfId,LibraryId,ShelfHeight,ShelfWidth")] Shelf shelf)
        {
            if (ModelState.IsValid)
            {
                _context.Add(shelf);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["LibraryId"] = new SelectList(_context.Library, "LibraryId", "LibraryName", shelf.LibraryId);
            return View(shelf);
        }

        // GET: Shelves/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var shelf = await _context.Shelf.FindAsync(id);
            if (shelf == null)
            {
                return NotFound();
            }
            ViewData["LibraryId"] = new SelectList(_context.Library, "LibraryId", "LibraryName", shelf.LibraryId);
            return View(shelf);
        }

        // POST: Shelves/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ShelfId,LibraryId,ShelfHeight,ShelfWidth")] Shelf shelf)
        {
            if (id != shelf.ShelfId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(shelf);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ShelfExists(shelf.ShelfId))
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
            ViewData["LibraryId"] = new SelectList(_context.Library, "LibraryId", "LibraryName", shelf.LibraryId);
            return View(shelf);
        }

        // GET: Shelves/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var shelf = await _context.Shelf
                .Include(s => s.Library)
                .FirstOrDefaultAsync(m => m.ShelfId == id);
            if (shelf == null)
            {
                return NotFound();
            }

            return View(shelf);
        }

        // POST: Shelves/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var shelf = await _context.Shelf.FindAsync(id);
            if (shelf != null)
            {
                _context.Shelf.Remove(shelf);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ShelfExists(int id)
        {
            return _context.Shelf.Any(e => e.ShelfId == id);
        }
    }
}
