using Infinite_Words_Library_MVC.Data;
using Infinite_Words_Library_MVC.Models;
using Microsoft.AspNetCore.Mvc;

namespace Infinite_Words_Library_MVC.Controllers
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
            List<Category> objCategoryList = _db.Catagories.ToList();
            return View(objCategoryList);
        }
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Category obj)
        {
            if (obj.Name == obj.DisplayOrder.ToString())
            {
                ModelState.AddModelError("name", "Name cannot be equal to displayOrder");
            }
            if (obj.Name is null)
            {
                ModelState.AddModelError("", "Name is not NULL");
            }
            if (ModelState.IsValid)
            {
                _db.Catagories.Add(obj);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View();
        }

        public IActionResult Edit(int? id)
        {
            if (id is null || id==0)
            {
                return NotFound();
            }
            Category categoryFromDb = _db.Catagories.Find(id);
            //Category categoryFromDb1 = _db.Catagories.FirstOrDefault(u=>u.Id==id);
            //Category categoryFromDb2 = _db.Catagories.Where(u=>u.Id==id).FirstOrDefault();
            if (categoryFromDb == null) 
            {
                return NotFound();
            }
            return View(categoryFromDb);
        }

        [HttpPost]
        public IActionResult Edit(Category obj)
        {
            if (ModelState.IsValid)
            {
                _db.Catagories.Update(obj);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View();
        }

        public IActionResult Delete(int? id)
        {
            if (id is null || id == 0)
            {
                return NotFound();
            }
            Category categoryFromDb = _db.Catagories.Find(id);
            if (categoryFromDb == null)
            {
                return NotFound();
            }
            return View(categoryFromDb);
        }

        [HttpPost,ActionName("Delete")]
        public IActionResult DeletePOST(int? id)
        {
            Category obj = _db.Catagories.Find(id);
            if (obj == null)
            {
                NotFound();
            }
            _db.Catagories.Remove(obj);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
