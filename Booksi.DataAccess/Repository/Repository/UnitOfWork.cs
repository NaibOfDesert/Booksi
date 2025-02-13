using Booksi.DataAccess.Data;
using Booksi.DataAccess.Repository.IRepository;
using Booski.DataAccess.Repository.IRepository;
using Booksi.Models;

namespace Booksi.DataAccess.Repository.Repository{
    public class UnitOfWork : IUnitOfWork{
        public ApplicationDbContext _db;
        public IAppUserRepository appUserRepository { get; private set; }
        public ICategoryRepository categoryRepository {get; private set;} 
        public IBookRepository bookRepository {get; private set;}
        public IShoppingCardRepository shoppingCardRepository { get; private set; }
        public IOrderRepository orderRepository { get; private set; }
        public IOrderSummaryRepository orderSummaryRepository { get; private set; }


        public UnitOfWork(ApplicationDbContext db){
            this._db = db;
            appUserRepository = new AppUserRepository(db);
            categoryRepository = new CategoryRepository(db);
            bookRepository = new BookRepository(db);
            shoppingCardRepository = new ShoppingCardRepository(db);
            orderRepository = new OrderRepository(db);
            orderSummaryRepository = new OrderSummaryRepository(db);    

        }

        public void Save(){
            _db.SaveChanges();
        }
    }
}