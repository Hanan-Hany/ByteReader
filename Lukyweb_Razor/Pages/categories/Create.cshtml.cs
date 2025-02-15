using Lukyweb_Razor.Data;
using Lukyweb_Razor.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Lukyweb_Razor.Pages.categories
{
  [BindProperties]
    public class CreateModel : PageModel
    {
        private readonly ApplicaionDbContext _db;
       
        public Category Category { get; set; }

        public CreateModel(ApplicaionDbContext db)
        {
            _db = db;
        }
        public void OnGet()
        {
        }
        public IActionResult OnPost() 
        { _db.Categories.Add(Category);
            _db.SaveChanges();
            TempData["success"] = "Category Created Successfuly";
            return RedirectToPage("Index");
        }
    }
}
