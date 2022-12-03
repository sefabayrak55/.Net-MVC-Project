using Entities.Models;
using Microsoft.AspNetCore.Mvc;
using Repositories.EFCore;

namespace ProductApp.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ProductController : Controller
    {
        private readonly RepositoryContext _context;

        public ProductController(RepositoryContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var products = _context.Products.ToList();
            return View(products);
        }


        [HttpGet]
        public IActionResult CreateOneProduct()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult CreateOneProduct(Product product)
        {
            if (ModelState.IsValid)
            {
                _context.Products.Add(product);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }

            return View();
        }

        [HttpGet]
        public IActionResult UpdateOneProduct(int id)
        {
            var product = _context
                 .Products
                 .Where(p => p.Id.Equals(id))
                 .SingleOrDefault();
            return View("UpdateOneProduct", product);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult UpdateOneProduct(Product product)
        {
            if (ModelState.IsValid)
            {
                _context.Products.Update(product);
                _context.SaveChanges();


                return RedirectToAction("Index");
            }
            return View();
        }

        [HttpPost]
        //public IActionResult DeleteOneProduct(int id)
        //{
        //    _context.Products.Remove(new Product { Id = id });
        //    _context.SaveChanges();

        //    return RedirectToAction("Index");
        //}
        public IActionResult DeleteOneProduct(Product product)
        {
            _context.Products.Remove(product);
            _context.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}
