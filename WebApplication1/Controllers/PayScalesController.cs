using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class PayScalesController : Controller
    {
        private readonly Day49PayScaleContext _context;

        public PayScalesController(Day49PayScaleContext context)
        {
            _context = context;
        }

        // GET: PayScales
        public async Task<IActionResult> Index()
        {
            return View(await _context.PayScale.ToListAsync());
        }

        // GET: PayScales/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var payScale = await _context.PayScale
                .FirstOrDefaultAsync(m => m.PayBand == id);
            if (payScale == null)
            {
                return NotFound();
            }

            return View(payScale);
        }

        // GET: PayScales/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: PayScales/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("PayBand,BasicSalary")] PayScale payScale)
        {
            if (ModelState.IsValid)
            {
                _context.Add(payScale);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(payScale);
        }

        // GET: PayScales/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var payScale = await _context.PayScale.FindAsync(id);
            if (payScale == null)
            {
                return NotFound();
            }
            return View(payScale);
        }

        // POST: PayScales/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("PayBand,BasicSalary")] PayScale payScale)
        {
            if (id != payScale.PayBand)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(payScale);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PayScaleExists(payScale.PayBand))
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
            return View(payScale);
        }

        // GET: PayScales/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var payScale = await _context.PayScale
                .FirstOrDefaultAsync(m => m.PayBand == id);
            if (payScale == null)
            {
                return NotFound();
            }

            return View(payScale);
        }

        // POST: PayScales/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var payScale = await _context.PayScale.FindAsync(id);
            _context.PayScale.Remove(payScale);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PayScaleExists(string id)
        {
            return _context.PayScale.Any(e => e.PayBand == id);
        }
    }
}
