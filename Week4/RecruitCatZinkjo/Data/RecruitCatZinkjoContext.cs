using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using RecruitCatZinkjo.Models;

namespace RecruitCatZinkjo.Data
{
    public class RecruitCatZinkjoContext : DbContext
    {
        public RecruitCatZinkjoContext (DbContextOptions<RecruitCatZinkjoContext> options)
            : base(options)
        {
        }

        public DbSet<RecruitCatZinkjo.Models.Candidate> Candidate { get; set; } = default!;

        public DbSet<RecruitCatZinkjo.Models.Company> Company { get; set; } = default!;

        public DbSet<RecruitCatZinkjo.Models.Industry> Industry { get; set; } = default!;

        public DbSet<RecruitCatZinkjo.Models.JobTitle> JobTitle { get; set; } = default!;
    }
}
