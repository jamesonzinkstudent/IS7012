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
    public class IndexModel : PageModel
    {
        private readonly RecruitCatZinkjo.Data.RecruitCatZinkjoContext _context;

        public IndexModel(RecruitCatZinkjo.Data.RecruitCatZinkjoContext context)
        {
            _context = context;
        }

        public IList<JobTitle> JobTitle { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.JobTitle != null)
            {
                JobTitle = await _context.JobTitle.ToListAsync();
            }
        }
    }
}
