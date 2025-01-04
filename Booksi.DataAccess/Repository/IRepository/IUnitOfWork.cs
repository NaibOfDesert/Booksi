
using Booksi.DataAccess.Repository.IRepository;
using Booksi.Models.Model;

namespace Booski.DataAccess.Repository.IRepository{
    public interface IUnitOfWork{
        ICategoryRepository categoryRepository {get;}
        IBookRepository bookRepository {get;}
        
        void Save(); 
    }

}