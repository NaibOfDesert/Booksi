
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Booksi.DataAccess.Data;
using Booksi.DataAccess.Repository.Repository;
using Booksi.DataAccess.Repository.IRepository;
using Booski.DataAccess.Repository.IRepository;

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
        
        public IActionResult Create(){
            return View();
        }
        
        [HttpPost]
        public IActionResult Create(Category category){
            int result;
            if(int.TryParse(category.Name,out result)){
                ModelState.AddModelError("", "Name cannot be a number");
            }
            if(ModelState.IsValid){
                _unitOfWork.categoryRepository.Add(category);
                _unitOfWork.Save();
                TempData["Success"] = "Category Succesfully Created"; 
                return RedirectToAction("Index");
            }
            else return View();
        }

        public IActionResult Edit(int? id){
            if(id == null || id == 0){
                return NotFound();
            }
            Category? category = _unitOfWork.categoryRepository.Get(x => x.Id == id);
            if(category == null){
                return NotFound();
            }
            return View(category);
        }
        
        [HttpPost]
        public IActionResult Edit(Category category){
            int result;
            if(int.TryParse(category.Name,out result)){
                ModelState.AddModelError("", "Name cannot be a number");
            }
            if(ModelState.IsValid){
                _unitOfWork.categoryRepository.Update(category);
                _unitOfWork.Save();
                TempData["Success"] = "Category Succesfully Edited"; 

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
