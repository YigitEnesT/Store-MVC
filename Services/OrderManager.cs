using Entities.Models;
using Repositories.Contracts;
using Services.Contracts;

namespace Services
{
    public class OrderManager : IOrderService
    {
        private readonly IRepositoryManager _manager;

        public OrderManager(IRepositoryManager manager)
        {
            _manager = manager;
        }

        public IQueryable<Order> Orders => _manager.Order.Orders;

        public int NumberOfInProcess => _manager.Order.NumberOfInProcess;

        public void Complete(int id)
        {
            _manager.Order.Complete(id);
            _manager.Save();
        }

        public Order? GetOneOrder(int id)
        {
            return _manager.Order.GetOneOrder(id);
        }

        public IQueryable<Order> GetOrdersByUserId(string id)
        {
            return _manager
                .Order
                .Orders
                .Where(o => o.UserId.Equals(id));
        }

        public void SaveOrder(Order order)
        {
            int currentYear = DateTime.Now.Year;
            int orderCount = _manager.Order.Orders.Count(o => o.OrderedAt.Year == currentYear);

            string orderNumber = $"{currentYear}{(orderCount+1).ToString("D3")}";
            order.OrderNumber = orderNumber;

            _manager.Order.SaveOrder(order);
            _manager.Save();
        }
    }
}