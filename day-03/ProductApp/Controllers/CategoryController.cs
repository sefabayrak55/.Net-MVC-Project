using Entities.Models;
using Microsoft.AspNetCore.Mvc;
using Repositories.EFCore;

namespace ProductApp.Controllers
{
    public class CategoryController : Controller
    {
        private readonly RepositoryContext _context;
        public CategoryController(RepositoryContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var categories = _context.Categories.ToList();
            return View(categories);
        }

        [HttpGet]
        public IActionResult CreateOneCategory()
        {
            return View();
        }

        [HttpPost]
        public IActionResult CreateOneCategory(Category category)
        {
            //if (ModelState.IsValid)
            //{
            //    _context.Categories.Add(category);
            //    _context.SaveChanges();
            //    return RedirectToAction("Index");
            //}
            if (category is null)
                throw new Exception();

            _context.Categories.Add(category);
            _context.SaveChanges();

            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult UpdateOneCategory(int id)
        {
            var category = _context
                .Categories
                .Where(c => c.Id.Equals(id))
                .SingleOrDefault();
            return View("UpdateOneCategory", category);
        }

        [HttpPost]
        public IActionResult UpdateOneCategory(Category category)
        {
            if (category is null)
                throw new Exception();

            _context.Categories.Update(category);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
