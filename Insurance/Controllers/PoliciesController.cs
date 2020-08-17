using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Insurance.Data;
using Insurance.Models;
using Insurance.ViewModels;

namespace Insurance.Controllers
{
    public class PoliciesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public PoliciesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Policies
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Policy.Include(p => p.Agent).Include(p => p.Owner);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Policies/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var policy = await _context.Policy
                .Include(p => p.Agent)
                .Include(p => p.Owner)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (policy == null)
            {
                return NotFound();
            }

            return View(policy);
        }

        // GET: Policies/Create
        public IActionResult Create()
        {
            ViewData["AgentId"] = new SelectList(_context.Agent, "Id", "AgentNumber");
            ViewData["OwnerId"] = new SelectList(_context.User, "Id", "EMBG");
            return View();
        }

        // POST: Policies/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,PolicyNumber,PolicyType,OwnerId,AgentId")] Policy policy)
        {
            if (ModelState.IsValid)
            {
                _context.Add(policy);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["AgentId"] = new SelectList(_context.Agent, "Id", "AgentNumber", policy.AgentId);
            ViewData["OwnerId"] = new SelectList(_context.User, "Id", "EMBG", policy.OwnerId);
            return View(policy);
        }

        // GET: Policies/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var policy = await _context.Policy.FindAsync(id);
            if (policy == null)
            {
                return NotFound();
            }
            ViewData["AgentId"] = new SelectList(_context.Agent, "Id", "AgentNumber", policy.AgentId);
            ViewData["OwnerId"] = new SelectList(_context.User, "Id", "EMBG", policy.OwnerId);
            return View(policy);
        }

        // POST: Policies/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,PolicyNumber,PolicyType,OwnerId,AgentId")] Policy policy)
        {
            if (id != policy.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(policy);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PolicyExists(policy.Id))
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
            ViewData["AgentId"] = new SelectList(_context.Agent, "Id", "AgentNumber", policy.AgentId);
            ViewData["OwnerId"] = new SelectList(_context.User, "Id", "EMBG", policy.OwnerId);
            return View(policy);
        }

        // GET: Policies/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var policy = await _context.Policy
                .Include(p => p.Agent)
                .Include(p => p.Owner)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (policy == null)
            {
                return NotFound();
            }

            return View(policy);
        }

        // POST: Policies/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var policy = await _context.Policy.FindAsync(id);
            _context.Policy.Remove(policy);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PolicyExists(int id)
        {
            return _context.Policy.Any(e => e.Id == id);
        }


        public async Task<IActionResult> CreatePolicy(int id)
        {
            IQueryable<Agent> agents = _context.Agent;
            IQueryable<User> users = _context.User.Where(s => s.Id == id);

            IQueryable<Policy> policies = _context.Policy;
            var createPolicyViewModel = new CreatePolicyViewModel
            {
                Agents = new SelectList(await agents.ToListAsync(), "Id", "FirstName")
            };

            return View(createPolicyViewModel);
        }

        //[HttpPost]
        //[ValidateAntiForgeryToken]
        /*public async Task<IActionResult> CreatePolicy(CreatePolicyViewModel entry)
        {
            //Agent agent = await _context.Agent.FirstOrDefault(c => c.Id == entry.)
            if (ModelState.IsValid)
            {
                foreach (int sId in entry.AgentIds)
                {

                }
            }
        }*/
    }
}
