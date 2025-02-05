using System;
using Booksi.DataAccess.Repository.IRepository;
using Booksi.DataAccess.Data;
using Booksi.Models.Model;

namespace Booksi.DataAccess.Repository.Repository
{
	public class ShoppingCardRepository : Repository<ShoppingCard>, IShoppingCardRepository
    {
        private readonly ApplicationDbContext _db;
        public ShoppingCardRepository(ApplicationDbContext db) : base(db)
        {
            this._db = db;
        }
	}
}

