using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MoviesDashboard.Data;
using MoviesDashboard.Models;
using MoviesDashboard.ViewModels;

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
            CategoryVM category = new();
            return View(category);
        }

        // POST: CategoryController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(CategoryVM category)
        {
            if (!ModelState.IsValid)
            {
                return View(category);
            }

            if (category is not null)
            {
                Category newCategory = new()
                {
                    Name = category.Name,
                    Status = category.Status,
                    CreatedOn = DateTime.Now,
                    CreatedBy = RouteData.Values["area"]?.ToString() ?? "System",
                    LastModifiedBy = RouteData.Values["area"]?.ToString() ?? "System",
                    LastModifiedOn = DateTime.Now
                };

                _context.Add(newCategory);
                _context.SaveChanges();
            }
            return RedirectToAction(nameof(Index));

        }

        // GET: CategoryController/Edit/5
        public ActionResult Edit(int id)
        {
            var category = _context.Categories.Find(id);
            if (category is null)
            {
                return NotFound();
            }
            return View(category);
        }

        // POST: CategoryController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Category category)
        {
            if (category is null)
            {
                return NotFound();
            }

            var oldCategory = _context.Categories.Find(category.Id);
            if (oldCategory is not null)
            {
                oldCategory.Name = category.Name;
                oldCategory.Status = category.Status;
                oldCategory.LastModifiedBy = RouteData.Values["area"]?.ToString() ?? "System";
                oldCategory.LastModifiedOn = DateTime.Now;

                _context.Update(oldCategory);
                _context.SaveChanges();
            }

            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(int id)
        {
            var category = _context.Categories.Include(c => c.Movies).FirstOrDefault(c => c.Id == id);

            if (category == null)
                return NotFound();

            if (category.Movies.Count != 0)
            {
                // 🔴 هنا بتضيف رسالة خطأ على ModelState
                ModelState.AddModelError(string.Empty, "لا يمكن حذف هذا التصنيف لأنه يحتوي على أفلام مرتبطة به.");

                // 👇 رجّع المستخدم لنفس صفحة الـ Index مع عرض كل التصنيفات
                var categories = _context.Categories.ToList();
                return View("Index", categories);
            }

            _context.Categories.Remove(category);
            _context.SaveChanges();

            return RedirectToAction(nameof(Index));
        }

    }
}
