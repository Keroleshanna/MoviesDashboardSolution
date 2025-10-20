using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MoviesDashboard.Data;
using MoviesDashboard.Models;

namespace MoviesDashboard.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CategoryController : Controller
    {
        private readonly AppDbContext _context;

        public CategoryController(AppDbContext context)
        {
            _context = context;
        }



        // GET: CategoryController
        public ActionResult Index(int currentNumber = 1)
        {
            var categories = _context.Categories.AsNoTracking().AsEnumerable();
            ViewData["PageNumbers"] = Math.Ceiling(categories.Count() / 8.0);
            ViewData["CurrentNumber"] = currentNumber;
            categories = categories.Skip((currentNumber - 1) * 8).Take(8);
            return View(categories);
        }

        // GET: CategoryController/Create
        public ActionResult Create()
        {
            Category category = new();
            return View(category);
        }

        // POST: CategoryController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Category category)
        {
            try
            {
                var areaName = RouteData.Values["area"]?.ToString() ?? "System";

                if (category is not null)
                {
                    category.CreatedOn = DateTime.Now;
                    category.CreatedBy = areaName;
                    category.LastModifiedBy = areaName;
                    category.LastModifiedOn = DateTime.Now;

                    _context.Add(category);
                    _context.SaveChanges();
                }
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: CategoryController/Edit/5
        public ActionResult Edit(int id)
        {
            var category = _context.Categories.Find(id);

            return View(category);
        }

        // POST: CategoryController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Category category)
        {
            try
            {
                if (category is not null)
                {
                    var areaName = RouteData.Values["area"]?.ToString() ?? "System";
                    var oldCategory = _context.Categories.AsNoTracking().FirstOrDefault(c => c.Id == category.Id);
                    
                    if (oldCategory is not null)
                    {
                        category.CreatedBy = oldCategory.CreatedBy;
                        category.CreatedOn = oldCategory.CreatedOn;
                        category.LastModifiedBy = areaName;
                        category.LastModifiedOn = DateTime.Now;

                        _context.Update(category);
                        _context.SaveChanges();
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: CategoryController/Delete/5
        public ActionResult Delete(int id)
        {
            var category = _context.Categories.Find(id);
            if (category is not null)
            {
                _context.Remove(category);
                _context.SaveChanges();
            }
            return RedirectToAction(nameof(Index));
        }

    }
}
