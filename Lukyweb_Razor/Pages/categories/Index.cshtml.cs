using Lukyweb_Razor.Data;
using Lukyweb_Razor.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Lukyweb_Razor.Pages.categories
{
    public class IndexModel : PageModel
    {
         private readonly ApplicaionDbContext _db;

        public List <Category> CategoryList { get; set; }

        public IndexModel(ApplicaionDbContext db)
        {
            _db = db;
        }
        public void OnGet()
        {
            CategoryList = _db.Categories.ToList();
        }
    }
}
