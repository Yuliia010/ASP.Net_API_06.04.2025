using System.ComponentModel.DataAnnotations;

namespace ASP.Net_API_06._04._2025.Model
{
    public class StudentDto
    {
        public Guid Id { get; set; }
        [Required(ErrorMessage = "Name is required")]
        [StringLength(100, MinimumLength = 2, ErrorMessage = "Name must be between 2 and 100 characters")]
        public string FullName { get; set; }
        [Required(ErrorMessage = "Group is required")]
        [StringLength(100, MinimumLength = 2, ErrorMessage = "Group must be between 2 and 100 characters")]
        public string Group { get; set; }
    }
}
