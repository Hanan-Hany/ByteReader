
using ByteReader.Models;

using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using ByteReader.DataAccess.Repository.IRepository;


namespace ByteReader.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ICategoryRepository _categoryRepo;
        public CategoryController(ICategoryRepository context )
        {
            _categoryRepo = context;
           
        }
        List<Category> categories = new List<Category>();

        public IActionResult Index()
        {

            categories = _categoryRepo.GetAll().ToList();

            return View(categories);
        }

        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Category category)
        {
            if (category.Name==category.DisplayOrder.ToString())
            {
                ModelState.AddModelError ("Name", "The Name Cannot exactly match the Display order");
            }
            if (ModelState.IsValid)
            {
                _categoryRepo.Add(category);
                _categoryRepo.save();
                TempData["success"] = "Category Created successfuly";
                return RedirectToAction("Index");
            }
            return View();
        }

        public IActionResult Edit(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            Category? category = _categoryRepo.Get(u=>u.Id==id);

            if (category == null)
            {
                return NotFound();
            }
            return View(category);

        }
        [HttpPost]
        public IActionResult Edit(Category category)
        {
           
            if (ModelState.IsValid)
            {
                _categoryRepo.Update(category);
                _categoryRepo.save();
                TempData["success"] = "Category Updated Successfuly";
                return RedirectToAction("Index");
            }
            return View();
        }

        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            Category? category = _categoryRepo.Get(u => u.Id == id);

            if (category == null)
            {
                return NotFound();
            }
            return View(category);

        }
        [HttpPost,ActionName("Delete")]
        public IActionResult DeletePost( int ?id)
        {
            Category? category = _categoryRepo.Get(u => u.Id == id);
            if (category == null) 
            { return NotFound();
            }
           
            
                _categoryRepo.Remove(category);
                _categoryRepo.save();
            TempData["success"] = "Category Deleted Successfuly";
            return RedirectToAction("Index");
            
            
        }

    }
}
