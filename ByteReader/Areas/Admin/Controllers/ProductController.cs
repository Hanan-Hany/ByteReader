
using ByteReader.Models;

using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using ByteReader.DataAccess.Repository.IRepository;
using ByteReader.Models.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using ByteReader.Models.ViewModel;


namespace Luky_web.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ProductController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        public ProductController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;

        }


        public IActionResult Index()
        {

            List<Product> products = _unitOfWork.Product.GetAll().ToList();
           
            return View(products);
        }

        public IActionResult Create()
        {
        
            ProductVM productVM = new ()
            {
                product = new Product(),
                CategoryList = _unitOfWork.Category.GetAll().Select(u => new SelectListItem
                {
                    Text = u.Name,
                    Value = u.Id.ToString()

                })
            };
            return View(productVM);
        }
        [HttpPost]
        public IActionResult Create(ProductVM productVM)
        {
            if (productVM.product.Title == productVM.product.ISBN.ToString())
            {
                 ModelState.AddModelError("Title", "The Title Cannot exactly match the ISBN");
            }
            if (ModelState.IsValid)
            {
                _unitOfWork.Product.Add(productVM.product);
                _unitOfWork.Save();
                TempData["success"] = "Product Created successfuly";
                return RedirectToAction("Index");
            }
            else
            {


                productVM.CategoryList = _unitOfWork.Category.GetAll().Select(u => new SelectListItem
                {
                    Text = u.Name,
                    Value = u.Id.ToString()

                });
                return View(productVM);

            }
            
        }

        public IActionResult Edit(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            Product? product = _unitOfWork.Product.Get(u => u.Id == id);

            if (product == null)
            {
                return NotFound();
            }
            return View(product);

        }
        [HttpPost]
        public IActionResult Edit(Product product)
        {

            if (ModelState.IsValid)
            {
                _unitOfWork.Product.Update(product);
                _unitOfWork.Save();
                TempData["success"] = "Product Updated Successfuly";
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
            Product? product = _unitOfWork.Product.Get(u => u.Id == id);

            if (product == null)
            {
                return NotFound();
            }
            return View(product);

        }
        [HttpPost, ActionName("Delete")]
        public IActionResult DeletePost(int? id)
        {
            Product? product = _unitOfWork.Product.Get(u => u.Id == id);
            if (product == null)
            {
                return NotFound();
            }


            _unitOfWork.Product.Remove(product);
            _unitOfWork.Save();
            TempData["success"] = "Product Deleted Successfuly";
            return RedirectToAction("Index");


        }

    }
}
