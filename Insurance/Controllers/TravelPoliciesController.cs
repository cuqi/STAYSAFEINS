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
    public class TravelPoliciesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public TravelPoliciesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: TravelPolicies
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.TravelPolicy.Include(t => t.Insured).Include(t => t.Policy);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: TravelPolicies/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var travelPolicy = await _context.TravelPolicy
                .Include(t => t.Insured)
                .Include(t => t.Policy)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (travelPolicy == null)
            {
                return NotFound();
            }

            return View(travelPolicy);
        }

        // GET: TravelPolicies/Create
        public IActionResult Create()
        {
            ViewData["InsuredId"] = new SelectList(_context.User, "Id", "EMBG");
            ViewData["PolicyId"] = new SelectList(_context.Policy, "Id", "PolicyNumber");
            return View();
        }

        // POST: TravelPolicies/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,TypeTravel,DayCount,Premium,AgreeDate,InsuredId,PolicyId")] TravelPolicy travelPolicy)
        {
            if (ModelState.IsValid)
            {
                _context.Add(travelPolicy);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["InsuredId"] = new SelectList(_context.User, "Id", "EMBG", travelPolicy.InsuredId);
            ViewData["PolicyId"] = new SelectList(_context.Policy, "Id", "PolicyNumber", travelPolicy.PolicyId);
            return View(travelPolicy);
        }

        // GET: TravelPolicies/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var travelPolicy = await _context.TravelPolicy.FindAsync(id);
            if (travelPolicy == null)
            {
                return NotFound();
            }
            ViewData["InsuredId"] = new SelectList(_context.User, "Id", "EMBG", travelPolicy.InsuredId);
            ViewData["PolicyId"] = new SelectList(_context.Policy, "Id", "PolicyNumber", travelPolicy.PolicyId);
            return View(travelPolicy);
        }

        // POST: TravelPolicies/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,TypeTravel,DayCount,Premium,AgreeDate,InsuredId,PolicyId")] TravelPolicy travelPolicy)
        {
            if (id != travelPolicy.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(travelPolicy);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TravelPolicyExists(travelPolicy.Id))
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
            ViewData["InsuredId"] = new SelectList(_context.User, "Id", "EMBG", travelPolicy.InsuredId);
            ViewData["PolicyId"] = new SelectList(_context.Policy, "Id", "PolicyNumber", travelPolicy.PolicyId);
            return View(travelPolicy);
        }

        // GET: TravelPolicies/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var travelPolicy = await _context.TravelPolicy
                .Include(t => t.Insured)
                .Include(t => t.Policy)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (travelPolicy == null)
            {
                return NotFound();
            }

            return View(travelPolicy);
        }

        // POST: TravelPolicies/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var travelPolicy = await _context.TravelPolicy.FindAsync(id);
            _context.TravelPolicy.Remove(travelPolicy);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TravelPolicyExists(int id)
        {
            return _context.TravelPolicy.Any(e => e.Id == id);
        }
    }
}
