using BusinessObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repository
{
    public interface IOrderRepository
    {
        public IEnumerable<Order> GetAll();
        public IEnumerable<Order> GetAllByAccountId(int accountId);
        public Order GetOrder(int orderId);
        public void AddNew(Order order);
        public void Delete(int orderId);
        public void Update(Order order);
    }
}
