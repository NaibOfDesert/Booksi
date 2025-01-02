

namespace Booski.DataAccess.Repository.IRepository{
    internal interface IUnitOfWork{
        ICategoryRepository categoryRepository {get;}

        void Save(); 
    }

}