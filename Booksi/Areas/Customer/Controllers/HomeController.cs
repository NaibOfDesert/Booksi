using System.Diagnostics;
using Booski.DataAccess.Repository.IRepository;
using Microsoft.AspNetCore.Mvc;
using Booksi.DataAccess.Repository.IRepository;
using Booksi.DataAccess.Repository.Repository; 
using Booksi.Models.Model;
using Booksi.Models.ViewModel;
using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;

namespace Booksi.Areas.Customer.Controllers{
    [Area("Customer")]
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IUnitOfWork _unitOfWork;

        public HomeController(ILogger<HomeController> logger, IUnitOfWork unitOfWork)
        {
            _logger = logger;
            _unitOfWork = unitOfWork;
        }

        public IActionResult Index()
        {
            IEnumerable<Book> books = _unitOfWork.bookRepository.GetAll(include: "Category");
            return View(books);
        }

        public IActionResult Details(int? id){
            if(id == null || id == 0){
                return NotFound(); 
            }
            Book book = _unitOfWork.bookRepository.Get(x => x.Id == id, include: "Category");
            if(book == null){
                return NotFound();
            }
            ShoppingCard shoppingCard = new ()
            {
                Book = book,
                BookId = book.Id,
                BooksCount = 1
            };
            return View(shoppingCard);
        }

        [HttpPost]
        [Authorize]
        public IActionResult Details(ShoppingCard shoppingCard)
        {
            // INFO: shopping card defalut for db as 0 to tell db this is a new record.
            shoppingCard.Id = 0;
            var identity = (ClaimsIdentity)User.Identity;
            var userId = identity.FindFirst(ClaimTypes.NameIdentifier).Value;
            shoppingCard.AppUserId = userId;

            ShoppingCard shoppingCardDb = _unitOfWork.shoppingCardRepository.Get(x => x.AppUserId == userId && x.BookId ==shoppingCard.BookId);

            if (shoppingCardDb != null)
            {
                shoppingCardDb.BooksCount += shoppingCard.BooksCount;
                _unitOfWork.shoppingCardRepository.Update(shoppingCardDb);
            }
            else
            {
                _unitOfWork.shoppingCardRepository.Add(shoppingCard);
            }
            _unitOfWork.Save(); 

            return RedirectToAction("Index");
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new Booksi.Models.ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }


}

