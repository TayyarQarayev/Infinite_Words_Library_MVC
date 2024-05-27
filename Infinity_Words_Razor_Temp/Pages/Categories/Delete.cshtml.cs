using Infinity_Words_Razor_Temp.Data;
using Infinity_Words_Razor_Temp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Infinity_Words_Razor_Temp.Pages.Categories
{
    [BindProperties]
    public class DeleteModel : PageModel
    {
        private readonly ApplicationDbContext _db;
        public Category Category { get; set; }
        public DeleteModel(ApplicationDbContext db)
        {
            _db = db;
        }
        public void OnGet(int? id)
        {
            if (id != null && id != 0)
            {
                Category = _db.Catagories.Find(id);
            }
        }
        public IActionResult OnPost()
        {
            Category? obj = _db.Catagories.Find(Category.Id);
            if (obj == null)
            {
                NotFound();
            }
            _db.Catagories.Remove(obj);
            _db.SaveChanges();
            return RedirectToPage("Index");
        }
    }
}
