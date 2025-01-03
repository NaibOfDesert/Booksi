using Booksi.DataAccess.Data;
using Booksi.DataAccess.Repository.IRepository;
using Booski.DataAccess.Repository.IRepository;
using Booksi.Models;

namespace Booksi.DataAccess.Repository.Repository{
    public class UnitOfWork : IUnitOfWork{
        public ApplicationDbContext _db; 
        public ICategoryRepository categoryRepository {get; private set;} 
        public IBookRepository bookRepository {get; private set;} 
        
        public UnitOfWork(ApplicationDbContext db){
            this._db = db;
            categoryRepository = new CategoryRepository(db);
            bookRepository = new BookRepository(db);

        }

        public void Save(){
            _db.SaveChanges();
        }
    }
}