using Lukyweb_Razor.Data;
using Lukyweb_Razor.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace Lukyweb_Razor.Pages.categories
{
    public class EditModel : PageModel
    {
        private readonly ApplicaionDbContext _db;
        [BindProperty]
        
         public Category? Category { get; set; }
        public EditModel(ApplicaionDbContext db)
        {
            _db = db;
        }
        public void OnGet(int? id)
        {if(id!=null&&id!=0)
           Category = _db.Categories.Find(id);
        }
        public IActionResult OnPost()
        {

            if (ModelState.IsValid)
            {
                _db.Categories.Update(Category);
                _db.SaveChanges();
                TempData["success"] = "Category Updated Successfuly";
                return RedirectToPage("Index");
            }
            return Page();
        }
    }
}
