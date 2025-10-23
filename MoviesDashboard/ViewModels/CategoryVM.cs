using System.ComponentModel.DataAnnotations;

namespace MoviesDashboard.ViewModels
{
    public class CategoryVM
    {
        [Required]
        [StringLength(100)]
        public string Name { get; set; }
        [Required]
        public bool Status { get; set; }
    }
}
