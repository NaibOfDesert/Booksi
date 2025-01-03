

using Booksi.DataAccess.Repository.IRepository;

namespace Booski.DataAccess.Repository.IRepository{
    public interface IUnitOfWork{
        ICategoryRepository categoryRepository {get;}

        void Save(); 
    }

}