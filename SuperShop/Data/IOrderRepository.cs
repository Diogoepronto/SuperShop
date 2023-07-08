using SuperShop.Data.Entities;
using SuperShop.Models;
using System.Linq;
using System.Threading.Tasks;

namespace SuperShop.Data
{
    public interface IOrderRepository : IGenericRepository<Order>
    {
        Task<IQueryable<Order>> GetOrderAsync(string username);

        Task<IQueryable<OrderDetailTemp>> GetDetailsTempAsync(string username);

        Task AddItemToOrderAsync(AddItemViewModel model, string username);

        Task ModifyOrderDetailTempQuantityAsync(int id, double quantity);

        Task DeleteDetailTempAsync(int id);

        Task<bool> ConfirmOrderAsync(string username);

        Task DeliverOrder(DeliveryViewModel model);

        Task<Order> GetOrderAsync(int id);
    }
}
