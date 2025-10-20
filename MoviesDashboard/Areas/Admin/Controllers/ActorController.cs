using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MoviesDashboard.Data;
using MoviesDashboard.Models;
using MoviesDashboard.ViewModels;

namespace MoviesDashboard.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ActorController : Controller
    {
        private readonly AppDbContext _context;

        public ActorController(AppDbContext context)
        {
            _context = context;
        }
        // GET: ActorController
        public ActionResult Index(int currentNumber = 1)
        {
            var actor = _context.Actors.AsNoTracking();
            ViewData["CurrentNumber"] = currentNumber;
            ViewData["PageNumbers"] = Math.Ceiling(actor.Count() / 8.0);
            actor = actor.Skip((currentNumber - 1) * 8).Take(8);
            return View(actor.AsEnumerable());
        }



        // GET: ActorController/Create
        public ActionResult Create()
        {
            Actor actor = new();
            return View(actor);
        }

        // POST: ActorController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Actor actor, IFormFile img)
        {
            try
            {
                string fileName = null!;
                if (img is not null && img.Length > 0)
                {
                    fileName = Guid.NewGuid().ToString() + Path.GetExtension(img.FileName);
                    var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot//Images//Actors", fileName);
                    // حفظ الصورة في المسار
                    using var stream = System.IO.File.Create(path);
                    img.CopyTo(stream);
                }
                if (actor is not null)
                {
                    var areaName = RouteData.Values["area"]?.ToString() ?? "System";

                    actor.CreatedBy = areaName;
                    actor.LastModifiedBy = areaName;
                    actor.CreatedOn = DateTime.Now;
                    actor.LastModifiedOn = DateTime.Now;
                    actor.Img = fileName;

                    _context.Actors.Add(actor);
                    _context.SaveChanges();
                }
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }




        // GET: ActorController/Edit/5
        [HttpGet]
        public ActionResult Edit(int id)
        {
            var actor = _context.Actors.Find(id);
            return View(actor);
        }

        // POST: ActorController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Actor actor, IFormFile img)
        {
            if (actor is not null)
            {
                string fileName = "";
                if (img is not null && img.Length > 0)
                {
                    fileName = Guid.NewGuid().ToString() + Path.GetExtension(img.FileName);
                    var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot//Images//Actors", fileName);
                    using var stream = System.IO.File.Create(path);
                    img.CopyTo(stream);
                    actor.Img = fileName;
                }
                else
                {
                    var oldActor = _context.Actors.AsNoTracking().FirstOrDefault(d=> d.Id == actor.Id);
                    if (oldActor?.Img is not null)
                        fileName = oldActor.Img;
                }
                var areaName = RouteData.Values["area"]?.ToString() ?? "System";
                actor.LastModifiedOn = DateTime.Now;
                actor.LastModifiedBy = areaName;
                actor.Img = fileName;
                _context.Update(actor);
                _context.SaveChanges();
            }
            return RedirectToAction(nameof(Index));

        }




        public IActionResult Delete(int id)
        {
            var actor = _context.Actors.Find(id);
            if (actor is not null)
            {
                _context.Remove(actor);
                _context.SaveChanges();
            }
            return RedirectToAction(nameof(Index));
        }
    }
}
