using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using RecruitCatZinkjo.Data;
using RecruitCatZinkjo.Models;

namespace RecruitCatZinkjo.Pages.JobTitles
{
    public class DeleteModel : PageModel
    {
        private readonly RecruitCatZinkjo.Data.RecruitCatZinkjoContext _context;

        public DeleteModel(RecruitCatZinkjo.Data.RecruitCatZinkjoContext context)
        {
            _context = context;
        }

        [BindProperty]
      public JobTitle JobTitle { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.JobTitle == null)
            {
                return NotFound();
            }

            var jobtitle = await _context.JobTitle.FirstOrDefaultAsync(m => m.Id == id);

            if (jobtitle == null)
            {
                return NotFound();
            }
            else 
            {
                JobTitle = jobtitle;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.JobTitle == null)
            {
                return NotFound();
            }
            var jobtitle = await _context.JobTitle.FindAsync(id);

            if (jobtitle != null)
            {
                JobTitle = jobtitle;
                _context.JobTitle.Remove(JobTitle);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
