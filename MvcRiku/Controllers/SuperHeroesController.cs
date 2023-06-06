using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MvcRiku.Models;

namespace MvcRiku.Controllers
{
    public class SuperHeroesController : Controller
    {
        private readonly MvcSuperHeroesContext _context;

        public SuperHeroesController(MvcSuperHeroesContext context)
        {
            _context = context;
        }

        // GET: SuperHeroes
        public async Task<IActionResult> Index()
        {
              return _context.SuperHeroe != null ? 
                          View(await _context.SuperHeroe.ToListAsync()) :
                          Problem("Entity set 'MvcSuperHeroesContext.SuperHeroe'  is null.");
        }

        // GET: SuperHeroes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.SuperHeroe == null)
            {
                return NotFound();
            }

            var superHeroe = await _context.SuperHeroe
                .FirstOrDefaultAsync(m => m.Id == id);
            if (superHeroe == null)
            {
                return NotFound();
            }

            return View(superHeroe);
        }

        // GET: SuperHeroes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: SuperHeroes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,CreationDate,Genre,Power,BestSeller")] SuperHeroe superHeroe)
        {
            if (ModelState.IsValid)
            {
                _context.Add(superHeroe);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(superHeroe);
        }

        // GET: SuperHeroes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.SuperHeroe == null)
            {
                return NotFound();
            }

            var superHeroe = await _context.SuperHeroe.FindAsync(id);
            if (superHeroe == null)
            {
                return NotFound();
            }
            return View(superHeroe);
        }

        // POST: SuperHeroes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,CreationDate,Genre,Power,BestSeller")] SuperHeroe superHeroe)
        {
            if (id != superHeroe.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(superHeroe);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SuperHeroeExists(superHeroe.Id))
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
            return View(superHeroe);
        }

        // GET: SuperHeroes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.SuperHeroe == null)
            {
                return NotFound();
            }

            var superHeroe = await _context.SuperHeroe
                .FirstOrDefaultAsync(m => m.Id == id);
            if (superHeroe == null)
            {
                return NotFound();
            }

            return View(superHeroe);
        }

        // POST: SuperHeroes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.SuperHeroe == null)
            {
                return Problem("Entity set 'MvcSuperHeroesContext.SuperHeroe'  is null.");
            }
            var superHeroe = await _context.SuperHeroe.FindAsync(id);
            if (superHeroe != null)
            {
                _context.SuperHeroe.Remove(superHeroe);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SuperHeroeExists(int id)
        {
          return (_context.SuperHeroe?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
