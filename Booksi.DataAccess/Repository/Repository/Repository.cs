using System.Linq.Expressions; 
using Microsoft.EntityFrameworkCore; 
using Booksi.DataAccess.Repository.IRepository;
using Booksi.DataAccess.Data;
using Booksi.Models;

namespace Booksi.DataAccess.Repository.Repository{
    public class Repository<T> : IRepository<T> where T : class
    {
        // Dependency Injection
        private readonly ApplicationDbContext _db; 
        internal DbSet<T> dbSet;
        public Repository(ApplicationDbContext db){
            this._db = db;
            this.dbSet = _db.Set<T>();
        }
        public T Get(Expression<Func<T, bool>> filter){
            IEnumerable<T> query = dbSet.Where(filter);
            return query.FirstOrDefault();
        }
        public IEnumerable<T> GetAll(){
            return dbSet;
        }
        public void Add(T item){
            dbSet.Add(item);
        }
        public void Update(T item){
            dbSet.Update(item);
        }
        public void Delete(T item){
            dbSet.Remove(item);
        }
        public void DeleteMany(IEnumerable<T> items){
            dbSet.RemoveRange(items);
        }
    }
}
