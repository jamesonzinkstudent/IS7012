﻿namespace RecruitCatZinkjo.wwwroot.Models
{
    public class Company
    {
        public string Name { get; set; }

        public string Position { get; set; }

        public decimal MinimumSalary { get; set; }

        public decimal MaximumSalary { get; set; }

        public DateTime? StartDate { get; set; }

        public string Location { get; set; }

        public int Id { get; set; }

        public int IndustryId { get; set; }

        public Industry Industry { get; set; }

        public List<Candidate> Candidates { get; set; }

        public int TotalEmployees { get; set; }

        public string Description { get; set; }

        public int Performance { get; set; }
    }
}
