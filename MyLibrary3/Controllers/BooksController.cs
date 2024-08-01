using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MyLibrary3.Data;
using MyLibrary3.Models;

namespace MyLibrary3.Controllers
{
    public class BooksController : Controller
    {
        private readonly MyLibrary3Context _context;

        public BooksController(MyLibrary3Context context)
        {
            _context = context;
        }

        // GET: Books
        public async Task<IActionResult> Index()
        {
            var myLibrary3Context = _context.Book.Include(b => b.Shelf);
            return View(await myLibrary3Context.ToListAsync());
        }

        // GET: Books/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var book = await _context.Book
                .Include(b => b.Shelf)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (book == null)
            {
                return NotFound();
            }

            return View(book);
        }

        // GET: Books/Create
        public IActionResult Create()
        {
            ViewData["ShelfId"] = new SelectList(_context.Shelf, "Id", "Id");
            ViewData["GenreId"] = new SelectList(_context.Library, "Id", "Name");
            return View();
        }

        // POST: Books/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598[HttpPost]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,GenerId,ShelfId,Name,Width,Height,IsSetBooks")] Book book)
        {
            ModelState.Remove("Shelf");

            // שליפת המדף הרלוונטי
            var shelf = await _context.Shelf.Include(s => s.Books).FirstOrDefaultAsync(s => s.Id == book.ShelfId);
            if (shelf == null)
            {
                ModelState.AddModelError("ShelfId", "המדף לא נמצא.");
                ViewData["ShelfId"] = new SelectList(_context.Shelf, "Id", "Id", book.ShelfId);
                ViewData["GenreId"] = new SelectList(_context.Library, "Id", "Name");
                return View(book);
            }

            // בדיקת גובה הספר לעומת גובה המדף
            if (book.Height > shelf.Height)
            {
                ModelState.AddModelError("Height", "גובה הספר עולה על גובה המדף.");
            }
            else if (shelf.Height - book.Height > 10)
            {
                // ספר קטן ב-10 ס"מ פחות מגובה המדף
                TempData["ConfirmationMessage"] = "גובה הספר קטן ב-10 ס\"מ מגובה המדף. האם אתה בטוח שברצונך להוסיף אותו?";
            }

            // בדיקת רוחב המדף
            var totalBooksWidth = shelf.Books.Sum(b => b.Width);
            var availableWidth = shelf.Width - totalBooksWidth;
            if (book.Width > availableWidth)
            {
                ModelState.AddModelError("Width", "אין מספיק מקום על המדף לספר הזה.");
            }

            // אם כל התנאים לא עברו, נציג הודעות מתאימות
            if (!ModelState.IsValid)
            {
                ViewData["ShelfId"] = new SelectList(_context.Shelf, "Id", "Id", book.ShelfId);
                ViewData["GenreId"] = new SelectList(_context.Library, "Id", "Name");
                return View(book);
            }

            // במידה וכל התנאים תקינים
            _context.Add(book);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }



        // GET: Books/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var book = await _context.Book.FindAsync(id);
            if (book == null)
            {
                return NotFound();
            }
            ViewData["ShelfId"] = new SelectList(_context.Shelf, "Id", "Id", book.ShelfId);
            ViewData["GenreId"] = new SelectList(_context.Library, "Id", "Name");
            return View(book);
        }

        // POST: Books/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,GenerId,ShelfId,Name,Width,Height,IsSetBooks")] Book book)
        {
            if (id != book.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(book);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BookExists(book.Id))
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
            ViewData["ShelfId"] = new SelectList(_context.Shelf, "Id", "Id", book.ShelfId);
            ViewData["GenreId"] = new SelectList(_context.Library, "Id", "Name");
            return View(book);
        }

        // GET: Books/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var book = await _context.Book
                .Include(b => b.Shelf)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (book == null)
            {
                return NotFound();
            }

            return View(book);
        }

        // POST: Books/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var book = await _context.Book.FindAsync(id);
            if (book != null)
            {
                _context.Book.Remove(book);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool BookExists(int id)
        {
            return _context.Book.Any(e => e.Id == id);
        }
    }
}
