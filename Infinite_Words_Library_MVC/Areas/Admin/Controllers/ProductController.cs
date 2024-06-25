using A.DataAccessLayer.Data;
using A.DataAccessLayer.Repository.IRepository;
using A.Models.Models;
using Microsoft.AspNetCore.Mvc;

namespace Infinite_Words_Library_MVC.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ProductController : Controller
    {
        private readonly IProductRepository _productRepo;
        public ProductController(IProductRepository db)
        {
            _productRepo = db;
        }
        public IActionResult Index()
        {
            List<Product> objProductList = _productRepo.GetAll().ToList();
            return View(objProductList);
        }
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Product obj)
        {
            if (ModelState.IsValid)
            {
                _productRepo.Add(obj);
                _productRepo.Save();
                return RedirectToAction("Index");
            }
            return View();
        }

        public IActionResult Edit(int? id)
        {
            if (id is null || id == 0)
            {
                return NotFound();
            }
            Product productFromDb = _productRepo.Get(u => u.Id == id);
            if (productFromDb == null)
            {
                return NotFound();
            }
            return View(productFromDb);
        }

        [HttpPost]
        public IActionResult Edit(Product obj)
        {
            if (ModelState.IsValid)
            {
                _productRepo.Update(obj);
                _productRepo.Save();
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
            Product productFromDb = _productRepo.Get(u => u.Id == id);
            if (productFromDb == null)
            {
                return NotFound();
            }
            return View(productFromDb);
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult DeletePOST(int? id)
        {
            Product obj = _productRepo.Get(u => u.Id == id);
            if (obj == null)
            {
                NotFound();
            }
            _productRepo.Remove(obj);
            _productRepo.Save();
            return RedirectToAction("Index");
        }
    }
}
