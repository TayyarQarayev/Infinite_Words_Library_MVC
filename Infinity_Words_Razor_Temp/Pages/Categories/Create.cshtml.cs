using Infinity_Words_Razor_Temp.Data;
using Infinity_Words_Razor_Temp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Infinity_Words_Razor_Temp.Pages.Categories
{
    [BindProperties]
    public class CreateModel : PageModel
    {
        private readonly ApplicationDbContext _db;
        //[BindProperty]
        public Category Category { get; set; }
        public CreateModel(ApplicationDbContext db)
        {
            _db = db;
        }
        public void OnGet()
        {
        }
        public IActionResult OnPost(/*Category obj*/) 
        {
            _db.Catagories.Add(Category);
            _db.SaveChanges();
            return RedirectToPage("index");
        }


    }
}
