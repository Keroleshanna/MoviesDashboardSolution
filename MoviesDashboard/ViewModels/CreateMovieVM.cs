using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

public class CreateMovieVM
{
    [Required(ErrorMessage = "اسم الفيلم مطلوب")]
    [StringLength(100)]
    public string Name { get; set; }

    [StringLength(200)]
    public string? Descrption { get; set; }


    [Range(100, 1000, ErrorMessage = "السعر يجب أن يكون بين 100 و1000")]
    [Required]
    public decimal? Price { get; set; }
    public bool Status { get; set; }
    [Required]
    public DateOnly? Date { get; set; }
    [Required]
    public TimeOnly? Time { get; set; }


    [Required(ErrorMessage = "اختيار فئة الفيلم مطلوب")]
    public int? CategoryId { get; set; }
    public IEnumerable<SelectListItem> Categories { get; set; }
    [Required(ErrorMessage = "اختيار السينما مطلوب")]
    public int? CinemaId { get; set; }
    public IEnumerable<SelectListItem> Cinemas { get; set; }


    [Required(ErrorMessage = "الصورة الأساسية مطلوبة")]
    public IFormFile? MainImage { get; set; }
    public List<IFormFile>? SubImages { get; set; }
}
