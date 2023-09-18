using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using RecruitCatZinkjo.Data;
using RecruitCatZinkjo.Models;

namespace RecruitCatZinkjo.Pages.Candidates
{
    public class EditModel : PageModel
    {
        private readonly RecruitCatZinkjo.Data.RecruitCatZinkjoContext _context;

        public EditModel(RecruitCatZinkjo.Data.RecruitCatZinkjoContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Candidate Candidate { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Candidate == null)
            {
                return NotFound();
            }

            var candidate =  await _context.Candidate.FirstOrDefaultAsync(m => m.Id == id);
            if (candidate == null)
            {
                return NotFound();
            }
            Candidate = candidate;
           ViewData["CompanyId"] = new SelectList(_context.Set<Company>(), "Id", "Description");
           ViewData["IndustryId"] = new SelectList(_context.Set<Industry>(), "Id", "Name");
           ViewData["TitleId"] = new SelectList(_context.Set<JobTitle>(), "Id", "Description");
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Candidate).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CandidateExists(Candidate.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool CandidateExists(int id)
        {
          return (_context.Candidate?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
