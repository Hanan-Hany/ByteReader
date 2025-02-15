using Lukyweb_Razor.Data;
using Lukyweb_Razor.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace Lukyweb_Razor.Pages.categories
{
    [BindProperties]
    public class DeleteModel : PageModel
    {
        private readonly ApplicaionDbContext _db;

        public Category? Category { get; set; }

        public DeleteModel(ApplicaionDbContext db)
        {
            _db = db;
        }
        public void OnGet(int ? id)
        {
            if (id != null && id != 0)
                Category = _db.Categories.Find(id);
        }
        public IActionResult OnPost()
        {
            Category? categories = _db.Categories.Find(Category.Id);
            if (categories==null)
            {
                return NotFound();
            }
            _db.Categories.Remove(categories);
            _db.SaveChanges();
            TempData["success"] = "Category Deleted Successfuly";
            return RedirectToPage("Index");
        }
    }
}
