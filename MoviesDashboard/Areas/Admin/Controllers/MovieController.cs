using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MoviesDashboard.Data;
using MoviesDashboard.Models;
using MoviesDashboard.ViewModels;
using NuGet.Protocol;

namespace MoviesDashboard.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class MovieController : Controller
    {
        private readonly AppDbContext _context;
        public MovieController(AppDbContext context)
        {
            _context = context;
        }
        public IActionResult Index(int currentNumber = 1)
        {
            var movies = _context.Movies.AsNoTracking();
            ViewData["currentNumber"] = currentNumber;
            ViewData["pageNumbers"] = Math.Ceiling(movies.Count() / 8.0);
            movies = movies.Skip((currentNumber - 1) * 8).Take(8);

            return View(movies.AsEnumerable());
        }

        [HttpGet]
        public IActionResult Create()
        {
            MovieVM createMovieVM = new()
            {
                Movie = new Movie(),
                Categories = new SelectList(_context.Categories, "Id", "Name"),
                Cinemas = new SelectList(_context.Cinemas, "Id", "Name")
            };
            return View(createMovieVM);
        }

        [HttpPost]
        public IActionResult Create(Movie movie, List<IFormFile> file, IFormFile mainImage)
        {
            List<string> fileNames = [];
            string fileName = "No Image";

            // الصورة الاساسية
            if (mainImage is not null && mainImage.Length > 0)
            {
                // توليد guid + extension
                fileName = Guid.NewGuid().ToString() + Path.GetExtension(mainImage.FileName);
                // وضعها في ال path الخاص بيها
                var filePathMainImage = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot//images//Movies", fileName);
                // حفظ الصورة في المسار
                using var stream = System.IO.File.Create(filePathMainImage);
                mainImage.CopyTo(stream);
            }

            // الصور الفرعيه
            if (file is not null && file.Count > 0)
            {
                for (int i = 0; i < file.Count(); i++)
                {
                    fileNames.Add(Guid.NewGuid().ToString() + Path.GetExtension(file[i].FileName));

                    var filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot//images//Movies", fileNames[i]);

                    using var stream = System.IO.File.Create(filePath);
                    file[i].CopyTo(stream);
                }
            }

            // حفظ الفلم والصور الفرعية 
            if (movie is not null)
            {
                var areaName = RouteData.Values["area"]?.ToString() ?? "System";

                movie.CreatedBy = areaName;
                movie.LastModifiedBy = areaName;
                movie.CreatedOn = DateTime.Now;
                movie.LastModifiedOn = DateTime.Now;
                movie.MainImg = fileName;

                _context.Movies.Add(movie);
                _context.SaveChanges();

                // حفظ الصور الفرعية
                for (int i = 0; i < fileNames.Count; i++)
                {
                    MovieImage movieImage = new()
                    {
                        MovieId = movie.Id,
                        ImageUrl = fileNames[i],
                        Order = 1
                    };
                    _context.MovieImages.Add(movieImage);
                    _context.SaveChanges();
                }

                var totalItems = _context.Movies.Count();
                var lastPage = Math.Ceiling(totalItems / 8.0);

                return RedirectToAction(nameof(Index), new { currentNumber = lastPage });
            }


            return RedirectToAction();
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var movie = _context.Movies.Find(id);
            MovieVM EditMovieVM = new()
            {
                Movie = movie,
                Categories = new SelectList(_context.Categories, "Id", "Name"),
                Cinemas = new SelectList(_context.Cinemas, "Id", "Name")
            };
            if (movie is null)
                return RedirectToAction(nameof(Index));

            return View(EditMovieVM);
        }

        [HttpPost]
        public IActionResult Edit(Movie movie, List<IFormFile> file, IFormFile mainImage)
        {
            List<string> fileNames = [];
            string fileName = "No Image";
            var oldMovie = _context.Movies.AsNoTracking().FirstOrDefault(m => m.Id == movie.Id);

            if (movie is not null)
            {
                // الصورة الاساسية
                if (mainImage is not null && mainImage.Length > 0)
                {
                    // توليد guid + extension
                    fileName = Guid.NewGuid().ToString() + Path.GetExtension(mainImage.FileName);
                    // وضعها في ال path الخاص بيها
                    var filePathMainImage = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot//images//Movies", fileName);
                    // 
                    using var stream = System.IO.File.Create(filePathMainImage);
                    mainImage.CopyTo(stream);
                    movie.MainImg = fileName;
                }
                else
                {
                    if (oldMovie is not null)
                    {
                        movie.MainImg = oldMovie.MainImg;
                    }
                }

                // الصور الفرعية
                if (file is not null && file.Count > 0)
                {
                    // 1. حفظ الملفات على السيرفر
                    for (int i = 0; i < file.Count; i++)
                    {
                        fileName = Guid.NewGuid().ToString() + Path.GetExtension(file[i].FileName);
                        fileNames.Add(fileName);

                        var filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot//images//Movies", fileName);
                        using var stream = System.IO.File.Create(filePath);
                        file[i].CopyTo(stream);
                    }

                    // 2. حذف الصور القديمة (لو عايز تستبدلها)
                    var oldImages = _context.MovieImages.Where(m => m.MovieId == movie.Id).ToList();
                    if (oldImages.Any())
                    {
                        _context.MovieImages.RemoveRange(oldImages);
                    }

                    // 3. إضافة الصور الجديدة
                    var newImages = fileNames.Select(fn => new MovieImage
                    {
                        MovieId = movie.Id,
                        ImageUrl = fn,
                        Order = 2
                    }).ToList();

                    _context.MovieImages.AddRange(newImages);
                    _context.SaveChanges();
                }

                _context.Movies.Update(movie);
                _context.SaveChanges();
            }
            var totalItems = _context.Movies.Count();
            var lastPage = Math.Ceiling(totalItems / 8.0);

            return RedirectToAction(nameof(Index), new { currentNumber = lastPage });
        }


        public IActionResult Delete(int id)
        {
            var movie = _context.Movies.Find(id);
            if (movie is not null)
            {
                _context.Remove(movie);
                _context.SaveChanges();
            }
            var totalItems = _context.Movies.Count();
            var lastPage = Math.Ceiling(totalItems / 8.0);

            return RedirectToAction(nameof(Index), new { currentNumber = lastPage });
        }
    }
}
