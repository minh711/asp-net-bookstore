using BusinessObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public  class OrderDAO
    {
        private static OrderDAO instance = null;
        private static readonly object instanceLock = new object();
        public static OrderDAO Instance
        {
            get
            {
                lock (instanceLock)
                {
                    if (instance == null)
                    {
                        instance = new OrderDAO();
                    }
                    return instance;
                }
            }
        }

        public IEnumerable<Order> GetOrders()
        {
            var orders = new List<Order>();
            try
            {
                using var context = new PRN_Group03Context();
                orders = context.Orders.ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return orders;
        }

        public IEnumerable<Order> GetOrdersByAccountId(int AccountId)
        {
            var orders = GetOrders();
            try
            {
               orders = orders.Where(item => item.AccountId == AccountId).ToList();
               
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return orders;
        }

        public Order GetOrderById(int id)
        {
            Order order = null;
            try
            {
                using var context = new PRN_Group03Context();
                order = context.Orders.SingleOrDefault(c => c.Id== id);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return order;
        }

        public void AddOrder(Order order)
        {
            try
            {
                Order tem = GetOrderById(order.Id);
                if (tem == null)
                {
                    using var context = new PRN_Group03Context();
                    context.Orders.Add(order);
                    context.SaveChanges();
                }
                else
                {
                    throw new Exception("The Order already exist");
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public void UpdateOrder(Order order)
        {
            try
            {
                Order tem = GetOrderById(order.Id);
                if (tem != null)
                {
                    using var context = new PRN_Group03Context();
                    context.Orders.Update(order);
                    context.SaveChanges();
                }
                else
                {
                    throw new Exception("The Order does not already exist");
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void RemoveOrder(int id)
        {
            try
            {
                Order tem = GetOrderById(id);
                if (tem != null)
                {
                    using var context = new PRN_Group03Context();
                    context.Orders.Remove(tem);
                    context.SaveChanges();
                }
                else
                {
                    throw new Exception("The Order does not already exist");
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
