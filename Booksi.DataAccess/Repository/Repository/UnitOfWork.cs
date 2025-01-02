
using Booksi.DataAccess.Repository.IRepository;
using Booksi.DataAccess.Data;

namespace Booksi.DataAccess.Repository.Repository{
    public class UnitOfWork() : IUnitOfWork{
        public ApplicationDbContext _db; 
        public ICategoryRepository categoryRepository {get; private set;} 


        public UnitOfWork(ApplicationDbContext db){
            this._db = db;
            categoryRepository = new CategoryRepository(db);
        }

        public void Save(){
            _db.SaveChanges();
        }
    }
}