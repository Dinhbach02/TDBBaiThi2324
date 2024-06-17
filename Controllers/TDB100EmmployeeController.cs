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
    public class TDB100EmmployeeController : Controller
    {
        private readonly PersonData _context;

        public TDB100EmmployeeController(PersonData context)
        {
            _context = context;
        }

        // GET: TDB100Emmployee
        public async Task<IActionResult> Index()
        {
            return View(await _context.TDB100Emmployee.ToListAsync());
        }

        // GET: TDB100Emmployee/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tDB100Emmployee = await _context.TDB100Emmployee
                .FirstOrDefaultAsync(m => m.PersonID == id);
            if (tDB100Emmployee == null)
            {
                return NotFound();
            }

            return View(tDB100Emmployee);
        }

        // GET: TDB100Emmployee/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: TDB100Emmployee/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("PersonID,FullName,Age")] TDB100Emmployee tDB100Emmployee)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tDB100Emmployee);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(tDB100Emmployee);
        }

        // GET: TDB100Emmployee/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tDB100Emmployee = await _context.TDB100Emmployee.FindAsync(id);
            if (tDB100Emmployee == null)
            {
                return NotFound();
            }
            return View(tDB100Emmployee);
        }

        // POST: TDB100Emmployee/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("PersonID,FullName,Age")] TDB100Emmployee tDB100Emmployee)
        {
            if (id != tDB100Emmployee.PersonID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tDB100Emmployee);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TDB100EmmployeeExists(tDB100Emmployee.PersonID))
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
            return View(tDB100Emmployee);
        }

        // GET: TDB100Emmployee/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tDB100Emmployee = await _context.TDB100Emmployee
                .FirstOrDefaultAsync(m => m.PersonID == id);
            if (tDB100Emmployee == null)
            {
                return NotFound();
            }

            return View(tDB100Emmployee);
        }

        // POST: TDB100Emmployee/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var tDB100Emmployee = await _context.TDB100Emmployee.FindAsync(id);
            if (tDB100Emmployee != null)
            {
                _context.TDB100Emmployee.Remove(tDB100Emmployee);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TDB100EmmployeeExists(string id)
        {
            return _context.TDB100Emmployee.Any(e => e.PersonID == id);
        }
    }
}
