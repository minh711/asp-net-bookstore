using BusinessObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repository
{
    public class CartRepository : ICartRepository
    {
        public IEnumerable<Cart> GetCart(int accountId) => CartDAO.Instance.GetCart(accountId);

        public void AddNew(Cart cart) => CartDAO.Instance.AddNew(cart);
        public void Delete(Cart cart) => CartDAO.Instance.Delete(cart);
        public void Update(Cart cart) => CartDAO.Instance.Update(cart);

        public int CountTotal(int accountId) => CartDAO.Instance.CountTotal(accountId);
    }
}
