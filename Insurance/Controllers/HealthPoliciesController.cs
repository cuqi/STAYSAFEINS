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
    public class HealthPoliciesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public HealthPoliciesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: HealthPolicies
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.HealthPolicy.Include(h => h.Insured).Include(h => h.Policy);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: HealthPolicies/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var healthPolicy = await _context.HealthPolicy
                .Include(h => h.Insured)
                .Include(h => h.Policy)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (healthPolicy == null)
            {
                return NotFound();
            }

            return View(healthPolicy);
        }

        // GET: HealthPolicies/Create
        public IActionResult Create()
        {
            ViewData["InsuredId"] = new SelectList(_context.User, "Id", "EMBG");
            ViewData["PolicyId"] = new SelectList(_context.Policy, "Id", "PolicyNumber");
            return View();
        }

        // POST: HealthPolicies/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,TypeHealth,Premium,AgreeDate,InsuredId,PolicyId")] HealthPolicy healthPolicy)
        {
            if (ModelState.IsValid)
            {
                _context.Add(healthPolicy);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["InsuredId"] = new SelectList(_context.User, "Id", "EMBG", healthPolicy.InsuredId);
            ViewData["PolicyId"] = new SelectList(_context.Policy, "Id", "PolicyNumber", healthPolicy.PolicyId);
            return View(healthPolicy);
        }

        // GET: HealthPolicies/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var healthPolicy = await _context.HealthPolicy.FindAsync(id);
            if (healthPolicy == null)
            {
                return NotFound();
            }
            ViewData["InsuredId"] = new SelectList(_context.User, "Id", "EMBG", healthPolicy.InsuredId);
            ViewData["PolicyId"] = new SelectList(_context.Policy, "Id", "PolicyNumber", healthPolicy.PolicyId);
            return View(healthPolicy);
        }

        // POST: HealthPolicies/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,TypeHealth,Premium,AgreeDate,InsuredId,PolicyId")] HealthPolicy healthPolicy)
        {
            if (id != healthPolicy.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(healthPolicy);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!HealthPolicyExists(healthPolicy.Id))
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
            ViewData["InsuredId"] = new SelectList(_context.User, "Id", "EMBG", healthPolicy.InsuredId);
            ViewData["PolicyId"] = new SelectList(_context.Policy, "Id", "PolicyNumber", healthPolicy.PolicyId);
            return View(healthPolicy);
        }

        // GET: HealthPolicies/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var healthPolicy = await _context.HealthPolicy
                .Include(h => h.Insured)
                .Include(h => h.Policy)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (healthPolicy == null)
            {
                return NotFound();
            }

            return View(healthPolicy);
        }

        // POST: HealthPolicies/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var healthPolicy = await _context.HealthPolicy.FindAsync(id);
            _context.HealthPolicy.Remove(healthPolicy);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool HealthPolicyExists(int id)
        {
            return _context.HealthPolicy.Any(e => e.Id == id);
        }
    }
}
