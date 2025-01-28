using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Authorization;
using Booksi.DataAccess.Data;
using Booksi.DataAccess.Repository.Repository;
using Booksi.DataAccess.Repository.IRepository;
using Booski.DataAccess.Repository.IRepository;
using Booksi.Models.Model;
using Booksi.Models.ViewModel;
using Booksi.Utility;

namespace Booksi.Areas.Admin.Controllers{
    [Area("Admin")]
    [Authorize(Roles = RolesStatic.RoleUserAppAdmin)]
    public class BookController : Controller
    {
        private readonly ILogger<BookController> _logger;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IWebHostEnvironment _webHostEnvironment;
        public BookController(IWebHostEnvironment webHostEnvironment, ILogger<BookController> logger, IUnitOfWork unitOfWork)
        {
            _webHostEnvironment = webHostEnvironment;
            _logger = logger;
            _unitOfWork = unitOfWork;
        }

        public IActionResult Index(){
            IEnumerable<Book> books = _unitOfWork.bookRepository.GetAll(include:"Category").ToList();
            return View(books);
        }
        
        public IActionResult Upsert(int? id){
            BookVM bookVM = new (){
                Book = new Book(),
                Categories = _unitOfWork.categoryRepository.GetAll().Select(
                    x => new SelectListItem{ 
                        Text = x.Name, 
                        Value = x.Id.ToString() 
                })
            };

            if(id == null || id == 0){
                // Create
                return View(bookVM);
            }
            else {
                // Update
                bookVM.Book = _unitOfWork.bookRepository.Get(x => x.Id == id);
                if(bookVM.Book == null){
                    return NotFound();
                }
                return View(bookVM);
            }
        }
        
        [HttpPost]
        public IActionResult Upsert(BookVM bookVM, IFormFile? image){
            int result;
            if(int.TryParse(bookVM.Book.Title, out result)){
                ModelState.AddModelError("", "Title cannot be a number");
            }
            if(ModelState.IsValid){
                if(image != null){
                    string wwwRootPath = _webHostEnvironment.WebRootPath; 
                    if(!string.IsNullOrEmpty(bookVM.Book.ImageUrl)){
                        string imageUrl = Path.Combine(wwwRootPath, bookVM.Book.ImageUrl.TrimStart('/'));
                        if(System.IO.File.Exists(imageUrl)){
                            System.IO.File.Delete(imageUrl);
                        }
                    }
                    string imageName = Guid.NewGuid().ToString() + Path.GetExtension(image.FileName);
                    string bookImagePath = Path.Combine(wwwRootPath, @"img/Books");
                    using (var fileStream = new FileStream(Path.Combine(bookImagePath, imageName), FileMode.Create)){
                        image.CopyTo(fileStream);
                    };
                    bookVM.Book.ImageUrl = @"/img/Books/" + imageName;
                }

                if(bookVM.Book.Id == null || bookVM.Book.Id == 0){
                    // Create
                    _unitOfWork.bookRepository.Add(bookVM.Book);
                    TempData["Success"] = "Book Succesfully Created"; 
                }
                else {
                    // Update
                    _unitOfWork.bookRepository.Update(bookVM.Book);
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
                TempData["Error"] = "Error while Book Deleting - not founded."; 
                return RedirectToAction ("Index"); 
            }
            Book? book= _unitOfWork.bookRepository.Get(x => x.Id == id);
            if(book == null){
                TempData["Error"] = "Error while Book Deleting - not founded."; 
                return RedirectToAction ("Index"); 
            }
            if(!string.IsNullOrEmpty(book.ImageUrl)){
                string wwwRootPath = _webHostEnvironment.WebRootPath; 
                string imageUrl = Path.Combine(wwwRootPath, book.ImageUrl.TrimStart('/'));
                if(System.IO.File.Exists(imageUrl)){
                    System.IO.File.Delete(imageUrl);
                }
            }
            _unitOfWork.bookRepository.Delete(book); 
            _unitOfWork.Save();
            TempData["Success"] = "Book Succesfully Deleted"; 
            return RedirectToAction ("Index"); 
        }
    }


}
