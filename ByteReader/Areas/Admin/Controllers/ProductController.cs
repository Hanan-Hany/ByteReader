
using ByteReader.Models;

using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using ByteReader.DataAccess.Repository.IRepository;
using ByteReader.Models.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using ByteReader.Models.ViewModel;
using Humanizer;


namespace Luky_web.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ProductController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IWebHostEnvironment _webHostEnvironment;
        public ProductController(IUnitOfWork unitOfWork, IWebHostEnvironment webHostEnvironment)
        {
            _unitOfWork = unitOfWork;
            _webHostEnvironment = webHostEnvironment;
        }


        public IActionResult Index()
        {

            List<Product> products = _unitOfWork.Product.GetAll(includeProperties: "category").ToList();
           
            return View(products);
        }

        public IActionResult Upsert(int ?id) //Upd ateIn sert
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
            if (id == null || id == 0)
            {
                //Create Product
                return View(productVM);
            }
            else
            {
                //Update Product
                productVM.product = _unitOfWork.Product.Get(u => u.Id == id);
                return View(productVM);
            }
           
        }
        
        [HttpPost]
        public IActionResult Upsert(ProductVM productVM ,IFormFile ? file)
        {
            if (productVM.product.Title == productVM.product.ISBN.ToString())
            {
                 ModelState.AddModelError("Title", "The Title Cannot exactly match the ISBN");
            }
            if (ModelState.IsValid)
            {
                string wwwRootPath = _webHostEnvironment.WebRootPath;
                if (file != null)
                {
                    string fileName = Guid.NewGuid().ToString()+ Path.GetExtension(file.FileName);
                    string productPath = Path.Combine(wwwRootPath, @"images\product");


                    if (!string.IsNullOrEmpty(productVM.product.ImageUrl)) 
                    { 
                        var oldImagePath = Path.Combine(wwwRootPath, productVM.product.ImageUrl.TrimStart('\\'));
                        if (System.IO.File.Exists(oldImagePath))
                        {
                            System.IO.File.Delete(oldImagePath);
                        }

                    }
                    using (var fileStreams = new FileStream(Path.Combine(productPath, fileName ), FileMode.Create))
                    {
                        file.CopyTo(fileStreams);
                    }
                    productVM.product.ImageUrl = @"\images\product\" + fileName ;
                }
                if(productVM.product.Id == 0) 
                {
                    _unitOfWork.Product.Add(productVM.product);
                }
                else 
                {
                    _unitOfWork.Product.Update(productVM.product);
                }

                
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
