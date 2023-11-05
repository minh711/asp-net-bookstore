using BusinessObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class CartDAO
    {
        private static CartDAO instance = null;
        private static readonly object instanceLock = new object();

        public static CartDAO Instance
        {
            get
            {
                lock (instanceLock)
                {
                    if (instance == null)
                    { instance = new CartDAO(); }

                    return instance;
                }
            }
        }

        //GET CART-----------------------------------

        public IEnumerable<Cart> GetCart(int accountId)
        {
            var cart = new List<Cart>();
            try
            {
                using var context = new PRN_Group03Context();
                cart = context.Carts.Where(cart => cart.AccountId == accountId)
                    .ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return cart;
        }

        //ADD NEW-----------------------------------
        public void AddNew(Cart cart)
        {
            try
            {
                    using var context = new PRN_Group03Context();
                    context.Carts.Add(cart);
                    context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }

        //UPDATE CART----------------------------------------------------------
        public void Update(Cart cart)
        {
            try
            {
                var oldCart = GetCart((int)cart.AccountId);
                if (oldCart != null)
                {
                    using var context = new PRN_Group03Context();
                    context.Carts.Update(cart);
                    context.SaveChanges();
                }
                else
                {
                    throw new Exception("The cart does not already exist.");
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        //------------------------------
        //Remove a car
        public void Delete(Cart cart)
        {
            try
            {
                var oldCart = GetCart((int)cart.AccountId);
                if (oldCart != null)
                {
                    using var context = new PRN_Group03Context();
                        context.Carts.Remove(cart);
                        context.SaveChanges();
                }
                else
                {
                    throw new Exception("The cart does not exist.");
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

    }
}
