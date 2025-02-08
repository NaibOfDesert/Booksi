
using Booksi.DataAccess.Repository.IRepository;
using Booksi.Models.Model;

namespace Booski.DataAccess.Repository.IRepository{
    public interface IUnitOfWork{
        IAppUserRepository appUserRepository { get; }
        ICategoryRepository categoryRepository {get;}
        IBookRepository bookRepository {get;}
        IShoppingCardRepository shoppingCardRepository { get; }

        void Save(); 
    }

}