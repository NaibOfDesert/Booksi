using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.AspNetCore.Mvc.Rendering;
using Booksi.DataAccess.Data;
using Booksi.DataAccess.Repository.Repository;
using Booksi.DataAccess.Repository.IRepository;
using Booski.DataAccess.Repository.IRepository;
using Booksi.Models.Model;
using Booksi.Models.ViewModel;

namespace Booksi.Areas.Admin.Controllers{
    [Area("Admin")]
    public class CategoryController : Controller
    {
        private readonly ILogger<CategoryController> _logger;
        private readonly IUnitOfWork _unitOfWork;
        public CategoryController(ILogger<CategoryController> logger, IUnitOfWork unitOfWork)
        {
            _logger = logger;
            _unitOfWork = unitOfWork;
        }

        public IActionResult Index(){
            IEnumerable<Category> categories = _unitOfWork.categoryRepository.GetAll().ToList();
            return View(categories);
        }

        public IActionResult Upsert(int? id){
            Category? category = new Category();
            if(id == null || id == 0){
                // Create
                return View(category);
            }
            else {
                // Update
                category = _unitOfWork.categoryRepository.Get(x => x.Id == id);
                if(category == null){
                    return NotFound();
                }
                return View(category);
            }
        }

        [HttpPost]
        public IActionResult Upsert(Category category){
            int result;
            if(int.TryParse(category.Name,out result)){
                ModelState.AddModelError("", "Name cannot be a number");
            }
            if(ModelState.IsValid){
                if(category.Id == null || category.Id == 0){
                    // Create
                    _unitOfWork.categoryRepository.Add(category);
                    TempData["Success"] = "Book Succesfully Created"; 
                }
                else {
                    // Update
                    _unitOfWork.categoryRepository.Update(category);
                    TempData["Success"] = "Book Succesfully Updated"; 
                }
                _unitOfWork.Save();
                return RedirectToAction("Index");
            }
            else return View();
        }

        [ActionName("Delete")]
        public IActionResult Delete(int? id){
            if(id == null || id ==0){
                return NotFound();
            }
            Category? category= _unitOfWork.categoryRepository.Get(x => x.Id == id);
            if(category == null){
                return NotFound();
            }
            _unitOfWork.categoryRepository.Delete(category); 
            _unitOfWork.Save();
            TempData["Success"] = "Category Succesfully Deleted"; 
            return RedirectToAction ("Index"); 
        }
    }


}
