using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Insurance.Data;
using Insurance.Models;

namespace Insurance.Controllers
{
    public class CascoPoliciesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public CascoPoliciesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: CascoPolicies
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.CascoPolicy.Include(c => c.Policy);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: CascoPolicies/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cascoPolicy = await _context.CascoPolicy
                .Include(c => c.Policy)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (cascoPolicy == null)
            {
                return NotFound();
            }

            return View(cascoPolicy);
        }

        // GET: CascoPolicies/Create
        public IActionResult Create()
        {
            ViewData["PolicyId"] = new SelectList(_context.Policy, "Id", "PolicyNumber");
            return View();
        }

        // POST: CascoPolicies/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Chassis,Registration,Power,Volume,Premium,VehicleColor,AgreeDate,PolicyId")] CascoPolicy cascoPolicy)
        {
            if (ModelState.IsValid)
            {
                _context.Add(cascoPolicy);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["PolicyId"] = new SelectList(_context.Policy, "Id", "PolicyNumber", cascoPolicy.PolicyId);
            return View(cascoPolicy);
        }

        // GET: CascoPolicies/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cascoPolicy = await _context.CascoPolicy.FindAsync(id);
            if (cascoPolicy == null)
            {
                return NotFound();
            }
            ViewData["PolicyId"] = new SelectList(_context.Policy, "Id", "PolicyNumber", cascoPolicy.PolicyId);
            return View(cascoPolicy);
        }

        // POST: CascoPolicies/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Chassis,Registration,Power,Volume,Premium,VehicleColor,AgreeDate,PolicyId")] CascoPolicy cascoPolicy)
        {
            if (id != cascoPolicy.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(cascoPolicy);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CascoPolicyExists(cascoPolicy.Id))
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
            ViewData["PolicyId"] = new SelectList(_context.Policy, "Id", "PolicyNumber", cascoPolicy.PolicyId);
            return View(cascoPolicy);
        }

        // GET: CascoPolicies/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cascoPolicy = await _context.CascoPolicy
                .Include(c => c.Policy)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (cascoPolicy == null)
            {
                return NotFound();
            }

            return View(cascoPolicy);
        }

        // POST: CascoPolicies/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var cascoPolicy = await _context.CascoPolicy.FindAsync(id);
            _context.CascoPolicy.Remove(cascoPolicy);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CascoPolicyExists(int id)
        {
            return _context.CascoPolicy.Any(e => e.Id == id);
        }
    }
}
