using System.Linq.Expressions; 

namespace Booksi.DataAccess.Repository.IRepository{
    internal interface IRepository<T> where T : class{
        T Get(Expression<Func<T, bool>> filter); 
        IEnumerable <T> GetAll(); 
        void Add(T item);
        void Update(T item);
        void Delete(T item);
        void DeleteMany(IEnumerable<T> items);
    }
}
