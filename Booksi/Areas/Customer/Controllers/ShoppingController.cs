using System.Security.Claims;
using Booksi.Models.Model;
using Booksi.Models.ViewModel;
using Booski.DataAccess.Repository.IRepository;
using Microsoft.AspNetCore.Mvc;

namespace Booksi.Areas.Customer.Controllers
{
    [Area("Customer")]
    public class ShoppingController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IUnitOfWork _unitOfWork;

        public ShoppingController(ILogger<HomeController> logger, IUnitOfWork unitOfWork)
        {
            _logger = logger;
            _unitOfWork = unitOfWork;
        }


        public IActionResult Index()
        {
            var identity = (ClaimsIdentity)User.Identity;
            var userId = identity.FindFirst(ClaimTypes.NameIdentifier).Value;
            IEnumerable<ShoppingCard> shoppingCards = _unitOfWork.shoppingCardRepository.GetAll(include:"Book").Where(x => x.AppUserId == userId).ToList();
        
            ShoppingCardVM shoppingCardVM = new (){
                shoppingCards = shoppingCards,
                totalPrice = Calculate(shoppingCards)
            };

            return View(shoppingCardVM);

            double Calculate(IEnumerable<ShoppingCard> shoppingCards){
                double totalPrice = 0;
                foreach (var s in shoppingCards){
                    totalPrice += s.Book.Price * s.BooksCount;
                }
                return totalPrice; 
            }
            
        }

        public IActionResult Incremet(int Id)
        {
            ShoppingCard shoppingCard = _unitOfWork.shoppingCardRepository.Get(x => x.Id == Id);
            shoppingCard.BooksCount += 1;
            _unitOfWork.shoppingCardRepository.Update(shoppingCard);
            _unitOfWork.Save();

            return RedirectToAction(nameof(Index));            
        }

        public IActionResult Decrement(int Id)
        {
            ShoppingCard shoppingCard = _unitOfWork.shoppingCardRepository.Get(x => x.Id == Id);
            shoppingCard.BooksCount -= 1;
            _unitOfWork.shoppingCardRepository.Update(shoppingCard);
            _unitOfWork.Save();

            return RedirectToAction(nameof(Index));    
        }

        public IActionResult Delete(int Id)
        {
            ShoppingCard shoppingCard = _unitOfWork.shoppingCardRepository.Get(x => x.Id == Id);
            _unitOfWork.shoppingCardRepository.Delete(shoppingCard);
            _unitOfWork.Save();

            return RedirectToAction(nameof(Index));    
        }

        public IActionResult Summary(){
            var identity = (ClaimsIdentity)User.Identity;
            var userId = identity.FindFirst(ClaimTypes.NameIdentifier).Value;


            return View();
        }
    }
}
