using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace RecruitCatZinkjo.Models
{
    public class Company
    {
        [StringLength(100)]
        [Required(ErrorMessage = "This field is required")]
        [DisplayName("Company Name")]
        public string Name { get; set; }

        [StringLength(100)]
        [Required(ErrorMessage = "This field is required")]
        public string Position { get; set; }
        [Range(10000.00, 999999.99)]
        [DisplayName("Minimum Salary")]
        public decimal MinimumSalary { get; set; }
        [Range(10000.00, 999999.99)]
        [DisplayName("Maximum Salary")]
        public decimal MaximumSalary { get; set; }
        [DataType(DataType.Date)]
        [DisplayName("Start Date")]
        public DateTime? StartDate { get; set; }

        [StringLength(100)]
        [Required(ErrorMessage = "This field is required")]
        public string Location { get; set; }

        public int Id { get; set; }
        [DisplayName("Industry Id")]
        public int IndustryId { get; set; }

        public Industry Industry { get; set; }

        public List<Candidate> Candidates { get; set; }
        [DisplayName("Total Employees")]
        public int TotalEmployees { get; set; }

        [Required(ErrorMessage = "This field is required")]
        public string Description { get; set; }

        [Range(1, 10)]
        public int Performance { get; set; }
    }
}
