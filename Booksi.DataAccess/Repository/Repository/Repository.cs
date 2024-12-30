using System.Linq.Expressions; 
using Booksi.DataAccess.Repository.IRepository;

namespace Booksi.DataAccess.Repository.Repository{
    public class Repository<T> : IRepository<T> where T : class
    {
        // Dependency Injection
        private readonly ApplicationDbContext _db; 

        public Repository(ApplicationDbContext db){
            _db = db;
        }
        public T Get(Expression<Func<T, bool>> filter){
            throw new NotImplementedException();
        }
        public IEnumerable<T> GetAll(){
            throw new NotImplementedException();
        }
        public void Add(T item){

        }
        public void Update(T item){

        }
        public void Delete(T item){

        }
        public void DeleteMany(IEnumerable<T> items){
            
        }
    }
}
