using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Nicholas_Jokes_App.Data;
using Nicholas_Jokes_App.Models;

namespace Nicholas_Jokes_App.Controllers
{
    public class JokesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public JokesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Jokes
        public async Task<IActionResult> Index()
        {
              return _context.JokesContain != null ? 
                          View(await _context.JokesContain.ToListAsync()) :
                          Problem("Entity set 'ApplicationDbContext.JokesContain'  is null.");
        }

        public Task<IActionResult> SearchForm()
        {
            return Task.FromResult<IActionResult>(View());
        }

        public async Task<IActionResult> SearchResults()
        {
            return _context.JokesContain != null ?
                        View(await _context.JokesContain.ToListAsync()) :
                        Problem("Entity set 'ApplicationDbContext.JokesContain'  is null.");
        }


        // GET: Jokes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.JokesContain == null)
            {
                return NotFound();
            }

            var jokesContain = await _context.JokesContain
                .FirstOrDefaultAsync(m => m.ID == id);
            if (jokesContain == null)
            {
                return NotFound();
            }

            return View(jokesContain);
        }

        // GET: Jokes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Jokes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,JokeAnswer,JokeQuestion")] JokesContain jokesContain)
        {
            if (ModelState.IsValid)
            {
                _context.Add(jokesContain);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(jokesContain);
        }

        // GET: Jokes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.JokesContain == null)
            {
                return NotFound();
            }

            var jokesContain = await _context.JokesContain.FindAsync(id);
            if (jokesContain == null)
            {
                return NotFound();
            }
            return View(jokesContain);
        }

        // POST: Jokes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,JokeAnswer,JokeQuestion")] JokesContain jokesContain)
        {
            if (id != jokesContain.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(jokesContain);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!JokesContainExists(jokesContain.ID))
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
            return View(jokesContain);
        }

        // GET: Jokes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.JokesContain == null)
            {
                return NotFound();
            }

            var jokesContain = await _context.JokesContain
                .FirstOrDefaultAsync(m => m.ID == id);
            if (jokesContain == null)
            {
                return NotFound();
            }

            return View(jokesContain);
        }

        // POST: Jokes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.JokesContain == null)
            {
                return Problem("Entity set 'ApplicationDbContext.JokesContain'  is null.");
            }
            var jokesContain = await _context.JokesContain.FindAsync(id);
            if (jokesContain != null)
            {
                _context.JokesContain.Remove(jokesContain);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool JokesContainExists(int id)
        {
          return (_context.JokesContain?.Any(e => e.ID == id)).GetValueOrDefault();
        }
    }
}
