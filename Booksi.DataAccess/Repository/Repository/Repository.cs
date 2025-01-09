using System.Linq.Expressions; 
using Microsoft.EntityFrameworkCore; 
using Booksi.DataAccess.Repository.IRepository;
using Booksi.DataAccess.Data;
using Booksi.Models.Model;
using Microsoft.IdentityModel.Tokens;

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
        public T Get(Expression<Func<T, bool>> filter, string? include = null){
            IQueryable<T> query = dbSet.Where(filter);
            if(!string.IsNullOrEmpty(include)){
                foreach(var i in include.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries)){
                    query = query.Include(include);
                }
            }
            return query.FirstOrDefault();
        }
        public IEnumerable<T> GetAll(string? include = null){
            IQueryable<T> query = dbSet; 
            if(!string.IsNullOrEmpty(include)){
                foreach(var i in include.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries)){
                    query = query.Include(include);
                }
            }
            return query.ToList();
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
