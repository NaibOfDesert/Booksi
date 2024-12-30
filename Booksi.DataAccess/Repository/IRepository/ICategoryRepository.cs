using Booksi.Models; 

namespace Booksi.DataAccess.Repository.IRepository{
    internal interface ICategoryRepository: IRepository<Category>{
        void Save(); 
    }
}