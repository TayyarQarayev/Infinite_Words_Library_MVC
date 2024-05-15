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
                ModelState.AddModelError("name","Name cannot be equal to displayOrder");
            }
            if (ModelState.IsValid) 
            {
                _db.Catagories.Add(obj);
                _db.SaveChanges();
                return RedirectToAction("Index");
            } 
            return View();
        }
    }
}
