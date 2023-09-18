using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Runtime.CompilerServices;

namespace RecruitCatZinkjo.Models
{
    public class JobTitle
    {
        [StringLength(100)]
        [Required(ErrorMessage = "This field is required")]
        [DisplayName("Job Title")]
        public string Title { get; set; }
        [Range(10000.00, 999999.99)]
        [DisplayName("Minimum Salary")]
        public decimal MinimumSalary { get; set; }
        [Range(10000.00, 999999.99)]
        [DisplayName("Maximum Salary")]
        public decimal MaximumSalary { get; set; }

        public int Id { get; set; }

        public List<Candidate> Candidates { get; set; }

        [StringLength(500)]
        [Required(ErrorMessage = "This field is required")]
        public string Description { get; set; }
    }
}
