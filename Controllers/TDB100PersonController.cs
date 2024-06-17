using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TDBBaiThi2324.Models;

namespace TDBBaiThi2324.Controllers
{
    public class TDB100PersonController : Controller
    {
        private readonly PersonData _context;

        public TDB100PersonController(PersonData context)
        {
            _context = context;
        }

        // GET: TDB100Person
        public async Task<IActionResult> Index()
        {
            return View(await _context.TDB100Person.ToListAsync());
        }

        // GET: TDB100Person/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tDB100Person = await _context.TDB100Person
                .FirstOrDefaultAsync(m => m.PersonID == id);
            if (tDB100Person == null)
            {
                return NotFound();
            }

            return View(tDB100Person);
        }

        // GET: TDB100Person/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: TDB100Person/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("PersonID,FullName,Age")] TDB100Person tDB100Person)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tDB100Person);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(tDB100Person);
        }

        // GET: TDB100Person/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tDB100Person = await _context.TDB100Person.FindAsync(id);
            if (tDB100Person == null)
            {
                return NotFound();
            }
            return View(tDB100Person);
        }

        // POST: TDB100Person/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("PersonID,FullName,Age")] TDB100Person tDB100Person)
        {
            if (id != tDB100Person.PersonID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tDB100Person);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TDB100PersonExists(tDB100Person.PersonID))
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
            return View(tDB100Person);
        }

        // GET: TDB100Person/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tDB100Person = await _context.TDB100Person
                .FirstOrDefaultAsync(m => m.PersonID == id);
            if (tDB100Person == null)
            {
                return NotFound();
            }

            return View(tDB100Person);
        }

        // POST: TDB100Person/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var tDB100Person = await _context.TDB100Person.FindAsync(id);
            if (tDB100Person != null)
            {
                _context.TDB100Person.Remove(tDB100Person);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TDB100PersonExists(string id)
        {
            return _context.TDB100Person.Any(e => e.PersonID == id);
        }
    }
}
