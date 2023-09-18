using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace RecruitCatZinkjo.Models
{
    public class Industry
    {
        [StringLength(100)]
        [Required(ErrorMessage = "This field is required")]
        [DisplayName("Industry Type")]
        public string Name { get; set; }

        public int Id { get; set; }

        public List<Company> Companies { get; set; }

        public List<Candidate> Candidates { get; set; }
    }
}
