using Microsoft.AspNetCore.Mvc.Rendering;

namespace MoviesDashboard.ViewModels
{
    public class EditMovieVM
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string? Descrption { get; set; }
        public decimal? Price { get; set; }
        public bool Status { get; set; }
        public DateOnly? Date { get; set; }
        public TimeOnly? Time { get; set; }

        // الصورة الرئيسية
        public string? MainImg { get; set; } // علشان تحفظ اسم الملف في قاعدة البيانات
        public IFormFile? MainImageFile { get; set; } // لاستقبال الصورة الجديدة (بدلًا من string بس)



        // الصور القديمة لعرضها في الصفحة
        public List<MovieImageVM>? SubImages { get; set; } 
        // الصور الجديدة اللي المستخدم هيضيفها
        public List<IFormFile>? NewSubImages { get; set; }



        // العلاقات
        public int? CategoryId { get; set; }
        public IEnumerable<SelectListItem>? Categories { get; set; }

        public int? CinemaId { get; set; }
        public IEnumerable<SelectListItem>? Cinemas { get; set; }
    }

    public class MovieImageVM
    {
        public string ImageUrl { get; set; }
        public int Order { get; set; }
    }
}
