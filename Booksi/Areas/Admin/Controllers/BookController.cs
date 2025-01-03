using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Booksi.DataAccess.Data;
using Booksi.DataAccess.Repository.Repository;
using Booksi.DataAccess.Repository.IRepository;
using Booski.DataAccess.Repository.IRepository;
using Booksi.Models;

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
            return View();
        }
        
        [HttpPost]
        public IActionResult Create(Book book){
            int result;
            if(int.TryParse(book.Title,out result)){
                ModelState.AddModelError("", "Title cannot be a number");
            }
            if(ModelState.IsValid){
                _unitOfWork.bookRepository.Add(book);
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
            Book? book = _unitOfWork.bookRepository.Get(x => x.Id == id);
            if(book == null){
                return NotFound();
            }
            return View(book);
        }
        
        [HttpPost]
        public IActionResult Edit(Book book){
            int result;
            if(int.TryParse(book.Title,out result)){
                ModelState.AddModelError("", "Title cannot be a number");
            }
            if(ModelState.IsValid){
                _unitOfWork.bookRepository.Update(book);
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
            Book? book= _unitOfWork.bookRepository.Get(x => x.Id == id);
            if(book == null){
                return NotFound();
            }
            _unitOfWork.bookRepository.Delete(book); 
            _unitOfWork.Save();
            TempData["Success"] = "Category Succesfully Deleted"; 
            return RedirectToAction ("Index"); 
        }
    }


}
