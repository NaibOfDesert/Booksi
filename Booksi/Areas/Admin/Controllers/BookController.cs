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
    public class BookController : Controller
    {
        private readonly ILogger<BookController> _logger;
        private readonly IUnitOfWork _unitOfWork;
        public BookController(ILogger<BookController> logger, IUnitOfWork unitOfWork)
        {
            _logger = logger;
            _unitOfWork = unitOfWork;
        }

        public IActionResult Index(){
            IEnumerable<Book> books = _unitOfWork.bookRepository.GetAll().ToList();
            return View(books);
        }
        
        public IActionResult Create(){
            IEnumerable<SelectListItem> categories = _unitOfWork.categoryRepository.GetAll().Select(
                x => new SelectListItem{ 
                    Text = x.Name, 
                    Value = x.Id.ToString() 
                });
            ViewBag.categories = categories;
            BookVM bookVM = new (){
                Book = new Book(),
                Categories = categories
            };
            return View(bookVM);
        }
        
        [HttpPost]
        public IActionResult Create(BookVM bookVM){
            int result;
            if(int.TryParse(bookVM.Book.Title, out result)){
                ModelState.AddModelError("", "Title cannot be a number");
            }
            if(ModelState.IsValid){
                _unitOfWork.bookRepository.Add(bookVM.Book);
                _unitOfWork.Save();
                TempData["Success"] = "Book Succesfully Created"; 
                return RedirectToAction("Index");
            }
            else return View();
        }

        public IActionResult Edit(int? id){
            if(id == null || id == 0){
                return NotFound();
            }
            Book? book = _unitOfWork.bookRepository.Get(x => x.Id == id);
            if(book == null){
                return NotFound();
            }

            IEnumerable<SelectListItem> categories = _unitOfWork.categoryRepository.GetAll().Select(
                x => new SelectListItem{ 
                    Text = x.Name, 
                    Value = x.Id.ToString() 
                });
            ViewBag.categories = categories;

            BookVM bookVM = new(){
                Book = book,
                Categories = categories 
            };
            return View(bookVM);
        }
        
        [HttpPost]
        public IActionResult Edit(BookVM bookVM){
            int result;
            if(int.TryParse(bookVM.Book.Title,out result)){
                ModelState.AddModelError("", "Title cannot be a number");
            }
            if(ModelState.IsValid){
                _unitOfWork.bookRepository.Update(bookVM.Book);
                _unitOfWork.Save();
                TempData["Success"] = "Book Succesfully Edited"; 

                return RedirectToAction("Index");
            }
            else return View();
        }
        

        [ActionName("Delete")]
        public IActionResult Delete(int? id){
            if(id == null || id ==0){
                return NotFound();
            }
            Book? book= _unitOfWork.bookRepository.Get(x => x.Id == id);
            if(book == null){
                return NotFound();
            }
            _unitOfWork.bookRepository.Delete(book); 
            _unitOfWork.Save();
            TempData["Success"] = "Book Succesfully Deleted"; 
            return RedirectToAction ("Index"); 
        }
    }


}
