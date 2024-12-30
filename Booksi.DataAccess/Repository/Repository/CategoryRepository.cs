using Booksi.DataAccess.Repository.IRepository;
using Booksi.DataAccess.Data;

namespace Booksi.DataAccess.Repository.Repository{
    public class CategoryRepository : Repository<Category>, ICategoryRepository
    {
        private ApplicationDbContext _db;
        public CategoryRepository(ApplicationDbContext db) : base(db){
           this. _db = db;
        }
        public void Save(){
            _db.SaveChanges();
        }
    }
}