using FoodStoreApp2.Data;
using FoodStoreApp2.Models;
using Microsoft.AspNetCore.Mvc;

namespace FoodStoreApp2.Controllers
{
    public class ManufacturerController : Controller
    {
        private readonly ApplicationDbContext _db;

        public ManufacturerController(ApplicationDbContext db)
        {
            _db = db;
        }

        public IActionResult Index()
        {
            IEnumerable<Manufacturer> categoryList = _db.Manufacturer;
            return View(categoryList);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Category cat)
        {
            if (ModelState.IsValid)
            {
                _db.Category.Add(cat);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(cat);
        }

        public IActionResult Edit(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var cat = _db.Manufacturer.Find(id);
            if (cat == null)
            {
                return NotFound();
            }
            return View(cat);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Manufacturer man)
        {
            if (ModelState.IsValid)
            {
                _db.Manufacturer.Update(man);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(man);

        }

        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var cat = _db.Manufacturer.Find(id);
            if (cat == null)
            {
                return NotFound();
            }

            return View(cat);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DeletePost(int? id)
        {
            var man = _db.Manufacturer.Find(id);
            if (man == null)
            {
                return NotFound();
            }
            _db.Manufacturer.Remove(man);
            _db.SaveChanges();
            return RedirectToAction("Index");


        }
    }
}