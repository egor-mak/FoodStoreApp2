﻿using FoodStoreApp2.Data;
using FoodStoreApp2.Models;
using Microsoft.AspNetCore.Mvc;

namespace FoodStoreApp2.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ApplicationDbContext _db;

        public CategoryController(ApplicationDbContext db)
        {
            _db = db;
        }

        public IActionResult Index()
        {
            IEnumerable<Category> categoryList = _db.Category;
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
            var cat = _db.Category.Find(id);
            if (cat == null)
            {
                return NotFound();
            }
            return View(cat);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Category cat)
        {
            if (ModelState.IsValid)
            {
                _db.Category.Update(cat);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(cat);
        }

        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var cat = _db.Category.Find(id);
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
            var cat = _db.Category.Find(id);
            if (cat == null)
            {
                return NotFound();
            }
            _db.Category.Remove(cat);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}