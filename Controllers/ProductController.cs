using FoodStoreApp2.Data;
using FoodStoreApp2.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace FoodStoreApp2.Controllers
{

    public class ProductController : Controller
    {
        private readonly ApplicationDbContext _db;
        public ProductController(ApplicationDbContext db)
        {
            _db = db;
        }


        public IActionResult Index()
        {
            IEnumerable<Product> productList = _db.Product;

            foreach (var product in productList)
            {
                product.Category = _db.Category.FirstOrDefault(u => u.Id == product.CategoryId);
            };

            return View(productList);
        }


        public IActionResult Upsert(int? id)
        {
            IEnumerable<SelectListItem> CategoryDropDown = _db.Category.Select(
                item => new SelectListItem()
                {
                    Text = item.Title,
                    Value = item.Description,
                });

            ViewBag.CategoryDropDown = CategoryDropDown;

            Product product = new();
            if (id == null)
            {
                return View(product);
            }
            else
            {
                product = _db.Product.Find(id);
                if (product == null)
                    return NotFound();

                return View(product);
            }
        }
    }
}