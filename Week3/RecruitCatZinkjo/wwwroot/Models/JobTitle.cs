namespace RecruitCatZinkjo.wwwroot.Models
{
    public class JobTitle
    {
        public string Title { get; set; }

        public decimal MinimumSalary { get; set; }

        public decimal MaximumSalary { get; set; }

        public int Id { get; set; }

        public List<Candidate> Candidates { get; set; }

        public string Description { get; set; }
    }
}
