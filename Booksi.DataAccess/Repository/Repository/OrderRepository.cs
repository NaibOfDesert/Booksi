using Booksi.DataAccess.Repository.IRepository;
using Booksi.DataAccess.Data;
using Booksi.Models.Model;

namespace Booksi.DataAccess.Repository.Repository{
    public class OrderRepository : Repository<Order>, IOrderRepository
    {
        private readonly ApplicationDbContext _db;
        public OrderRepository(ApplicationDbContext db) : base(db){
           this._db = db;
        }
    }
}