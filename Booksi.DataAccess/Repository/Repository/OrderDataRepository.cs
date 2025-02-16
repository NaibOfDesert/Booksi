using Booksi.DataAccess.Repository.IRepository;
using Booksi.DataAccess.Data;
using Booksi.Models.Model;

namespace Booksi.DataAccess.Repository.Repository{
    public class OrderDataRepository : Repository<OrderData>, IOrderDataRepository
    {
        private readonly ApplicationDbContext _db;
        public OrderDataRepository(ApplicationDbContext db) : base(db){
           this._db = db;
        }
    }
}