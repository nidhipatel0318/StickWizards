using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using StickWizards.Data;
using StickWizards.Models;

namespace StickWizards.Controllers
{
    public class SticksController : Controller
    {
        private readonly StickWizardsContext _context;

        public SticksController(StickWizardsContext context)
        {
            _context = context;
        }

        // GET: Sticks
        
        public async Task<IActionResult> Index(string StickTexture, string searchString)
        {
            // Use LINQ to get list of genres.
            IQueryable<string> genreQuery = from m in _context.Stick
                                            orderby m.Texture
                                            select m.Texture;

            var movies = from m in _context.Stick
                         select m;

            if (!string.IsNullOrEmpty(searchString))
            {
                movies = movies.Where(s => s.Material.Contains(searchString));
            }

            if (!string.IsNullOrEmpty(StickTexture))
            {
                movies = movies.Where(x => x.Texture == StickTexture);
            }

            var movieGenreVM = new StickTextureViewModel
            {
                Texture = new SelectList(await genreQuery.Distinct().ToListAsync()),
                Sticks = await movies.ToListAsync()
            };

            return View(movieGenreVM);
        }
        // GET: Sticks/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var stick = await _context.Stick
                .FirstOrDefaultAsync(m => m.Id == id);
            if (stick == null)
            {
                return NotFound();
            }

            return View(stick);
        }

        // GET: Sticks/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Sticks/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Length,Material,Texture,Weight")] Stick stick)
        {
            if (ModelState.IsValid)
            {
                _context.Add(stick);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(stick);
        }

        // GET: Sticks/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var stick = await _context.Stick.FindAsync(id);
            if (stick == null)
            {
                return NotFound();
            }
            return View(stick);
        }

        // POST: Sticks/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Length,Material,Texture,Weight")] Stick stick)
        {
            if (id != stick.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(stick);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!StickExists(stick.Id))
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
            return View(stick);
        }

        // GET: Sticks/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var stick = await _context.Stick
                .FirstOrDefaultAsync(m => m.Id == id);
            if (stick == null)
            {
                return NotFound();
            }

            return View(stick);
        }

        // POST: Sticks/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var stick = await _context.Stick.FindAsync(id);
            _context.Stick.Remove(stick);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool StickExists(int id)
        {
            return _context.Stick.Any(e => e.Id == id);
        }
    }
}
