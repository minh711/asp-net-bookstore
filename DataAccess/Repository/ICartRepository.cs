using BusinessObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repository
{
    public interface ICartRepository
    {
        public IEnumerable<Cart> GetCart(int accountId);
        public void AddNew(Cart cart);
        public void Delete(Cart cart);
        public void Update(Cart cart);
    }
}
