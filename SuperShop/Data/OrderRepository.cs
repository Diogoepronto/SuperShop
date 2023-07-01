using Microsoft.EntityFrameworkCore;
using SuperShop.Data.Entities;
using SuperShop.Helpers;
using System.Linq;
using System.Threading.Tasks;

namespace SuperShop.Data
{
    public class OrderRepository : GenericRepository<Order>, IOrderRepository
    {
        private readonly DataContext _context;
        private readonly IUserHelper _userHelper;

        public OrderRepository(DataContext context, IUserHelper userHelper) : base(context)
        {
            _context = context;
            _userHelper = userHelper;
        }

        public async Task<IQueryable<OrderDetailTemp>> GetDetailsTempAsync(string username)
        {
            var user = await _userHelper.GetUserByEmailAsync(username);

            if(user == null)
            {
                return null;
            }

            return _context.OrdersDetailsTemp
                .Include(p => p.Product)
                .Where(o => o.User == user)
                .OrderBy(o => o.Product.Name);
        }

        public async Task<IQueryable<Order>> GetOrderAsync(string username)
        {
            var user = await _userHelper.GetUserByEmailAsync(username);

            if(user == null)
            {
                return null;
            }

            if(await _userHelper.IsUserInRoleAsync(user, "Admin"))
            {
                return _context.Orders
                    .Include(o => o.Items)
                    .ThenInclude(p => p.Product)
                    .OrderByDescending(o => o.OrderDate);
            }

            return _context.Orders
                .Include(o => o.Items)
                .ThenInclude(p => p.Product)
                .Where(o => o.User == user)
                .OrderByDescending(o => o.OrderDate);
        }
    }
}
