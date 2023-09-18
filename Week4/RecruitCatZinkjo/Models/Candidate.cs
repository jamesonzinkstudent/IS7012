using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace RecruitCatZinkjo.Models
{
    public class Candidate
    {
        [StringLength(30)]
        [Required(ErrorMessage = "This field is required")]
        [DisplayName("First Name")]
        public string FirstName { get; set; }

        [StringLength(30)]
        [Required(ErrorMessage = "This field is required")]
        [DisplayName("Last Name")]
        public string LastName { get; set; }

        [DisplayName("Full Name")]
        public string FullName
        {
            get
            {
                return $"{FirstName} {LastName}";
            }
        }
        [Range(10000.00, 999999.99)]
        [DisplayName("Target Salary")]
        public decimal TargetSalary { get; set; }
     
        [DataType(DataType.Date)]
        [DisplayName("Start Date")]
        public DateTime StartDate { get; set; }

        public Company? Company { get; set; }

        [DisplayName("Company Id")]
        public int? CompanyId { get; set; }

        public int Id { get; set; }
        [DisplayName("Job Title")]
        public JobTitle Title { get; set; }
        [DisplayName("Title Id")]
        public int TitleId { get; set; }

        public Industry Industry { get; set; }
        [DisplayName("Industry Id")]
        public int IndustryId { get; set; }
        [DataType(DataType.Date)]
        [DisplayName("Date of Birth")]
        public DateTime? DOB { get; set; }

        [StringLength(30)]
        [Required(ErrorMessage = "This field is required")]
        [DisplayName("Highest Education Level Completed")]
        public string EducationLevel { get; set; }

        [StringLength(11, MinimumLength = 9, ErrorMessage = "Please Enter Valid SSN")]
        [RegularExpression("^\\d{3}-?\\d{2}-?\\d{4}$", ErrorMessage = "Please Enter Valid SSN")]
        [Required(ErrorMessage = "This field is required")]
        [DisplayName("Social Security Number")]
        public string SSN { get; set; }

        [EmailAddress(ErrorMessage = "Please Enter Valid Email")]
        public string Email { get; set; }
    }
}
