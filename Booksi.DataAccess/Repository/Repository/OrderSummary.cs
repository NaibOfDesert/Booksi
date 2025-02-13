using Booksi.DataAccess.Repository.IRepository;
using Booksi.DataAccess.Data;
using Booksi.Models.Model;

namespace Booksi.DataAccess.Repository.Repository{
    public class OrderSummaryRepository : Repository<OrderSummary>, IOrderSummaryRepository
    {
        private readonly ApplicationDbContext _db;
        public OrderSummaryRepository(ApplicationDbContext db) : base(db){
           this._db = db;
        }
    }
}