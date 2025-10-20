using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MoviesDashboard.Data;
using MoviesDashboard.Models;

namespace MoviesDashboard.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CinemaController : Controller
    {
        private readonly AppDbContext _context;

        public CinemaController(AppDbContext context)
        {
            _context = context;
        }


        // GET: CinemaController
        public ActionResult Index(int currentNumber = 1)
        {
            var cinemas = _context.Cinemas.AsNoTracking().AsEnumerable();
            ViewData["CurrentNumber"] = currentNumber;
            ViewData["pageNumbers"] = Math.Ceiling(cinemas.Count() / 8.0);
            cinemas = cinemas.Skip((currentNumber - 1) * 8).Take(8);

            return View(cinemas);
        }




        // GET: CinemaController/Create
        public ActionResult Create()
        {
            Cinema cinema = new();
            return View(cinema);
        }

        // POST: CinemaController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Cinema cinema, IFormFile image)
        {
            try
            {
                string fileName;
                if (image is not null)
                {
                    fileName = Guid.NewGuid().ToString() + Path.GetExtension(image.FileName);
                    var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot//Images//Cinemas", fileName);
                    using var stream = System.IO.File.Create(path);
                    image.CopyTo(stream);
                    cinema.Img = fileName;
                }
                var areaName = RouteData.Values["area"]?.ToString() ?? "System";

                cinema.CreatedOn = DateTime.Now;
                cinema.CreatedBy = areaName;
                cinema.LastModifiedBy = areaName;
                cinema.LastModifiedOn = DateTime.Now;

                _context.Add(cinema);
                _context.SaveChanges();

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }




        // GET: CinemaController/Edit/5
        public ActionResult Edit(int id)
        {
            var cinema = _context.Cinemas.Find(id);
            return View(cinema);
        }

        // POST: CinemaController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Cinema cinema, IFormFile image)
        {
            try
            {
                string fileName;
                var oldCinema = _context.Cinemas.AsNoTracking().FirstOrDefault(c => c.Id == cinema.Id);
                if (image is not null)
                {
                    fileName = Guid.NewGuid().ToString() + Path.GetExtension(image.FileName);
                    var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot//Images//Cinemas", fileName);
                    using var stream = System.IO.File.Create(path);
                    image.CopyTo(stream);
                    cinema.Img = fileName;
                }
                else
                    cinema.Img = oldCinema?.Img;

                if (cinema is not null && oldCinema is not null)
                {
                    var areaName = RouteData.Values["area"]?.ToString() ?? "System";
                    cinema.CreatedBy = oldCinema.CreatedBy;
                    cinema.CreatedOn = oldCinema.CreatedOn;
                    cinema.LastModifiedBy = areaName;
                    cinema.LastModifiedOn = DateTime.Now;

                    _context.Update(cinema);
                    _context.SaveChanges();
                }

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: CinemaController/Delete/5
        public ActionResult Delete(int id)
        {
            var cinema = _context.Cinemas.Find(id);
            if (cinema is not null)
            {
                _context.Remove(cinema);
                _context.SaveChanges();
            }
            return RedirectToAction(nameof(Index));
        }
    }
}
