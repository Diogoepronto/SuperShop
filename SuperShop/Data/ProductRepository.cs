using Microsoft.EntityFrameworkCore;
using SuperShop.Data.Entities;
using System.Linq;

namespace SuperShop.Data
{
    public class ProductRepository : GenericRepository<Product>, IProductRepository
    {
        private readonly DataContext _context;

        public ProductRepository(DataContext context) : base(context)
        {
            _context = context;
        }

        public IQueryable GetAllWithUsers()
        {
            return _context.Products.Include(p => p.User);
        }
    }
}
