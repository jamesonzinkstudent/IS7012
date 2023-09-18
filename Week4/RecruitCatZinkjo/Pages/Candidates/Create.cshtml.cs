using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using RecruitCatZinkjo.Data;
using RecruitCatZinkjo.Models;

namespace RecruitCatZinkjo.Pages.Candidates
{
    public class CreateModel : PageModel
    {
        private readonly RecruitCatZinkjo.Data.RecruitCatZinkjoContext _context;

        public CreateModel(RecruitCatZinkjo.Data.RecruitCatZinkjoContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
        ViewData["CompanyId"] = new SelectList(_context.Set<Company>(), "Id", "Description");
        ViewData["IndustryId"] = new SelectList(_context.Set<Industry>(), "Id", "Name");
        ViewData["TitleId"] = new SelectList(_context.Set<JobTitle>(), "Id", "Description");
            return Page();
        }

        [BindProperty]
        public Candidate Candidate { get; set; } = default!;
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid || _context.Candidate == null || Candidate == null)
            {
                return Page();
            }

            _context.Candidate.Add(Candidate);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
