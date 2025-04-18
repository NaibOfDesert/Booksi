using System.Linq.Expressions; 

namespace Booksi.DataAccess.Repository.IRepository{
    public interface IRepository<T> where T : class{
        T Get(Expression<Func<T, bool>> filter, string? include = null); 
        IEnumerable<T> GetAll(string? include = null); 
        void Add(T item);
        void Update(T item);
        void Delete(T item);
        void DeleteMany(IEnumerable<T> items);
    }
}
