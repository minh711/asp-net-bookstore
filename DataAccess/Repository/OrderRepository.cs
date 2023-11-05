using BusinessObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repository
{
    public class OrderRepository : IOrderRepository
    {
        public void AddNew(Order order) => OrderDAO.Instance.AddOrder(order);
       

        public void Delete(int orderId) => OrderDAO.Instance.RemoveOrder(orderId);



        public IEnumerable<Order> GetAll() => OrderDAO.Instance.GetOrders();



        public IEnumerable<Order> GetAllByAccountId(int accountId) => OrderDAO.Instance.GetOrdersByAccountId(accountId);



        public Order GetOrder(int orderId) => OrderDAO.Instance.GetOrderById(orderId);



        public void Update(Order order) => OrderDAO.Instance.UpdateOrder(order);


    }
}
