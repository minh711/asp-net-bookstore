using System;
using System.Collections.Generic;

#nullable disable

namespace BusinessObject
{
    public partial class Account
    {
        public Account()
        {
            Carts = new HashSet<Cart>();
            Orders = new HashSet<Order>();
        }

        public int Id { get; set; }
        public string FullName { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string Gender { get; set; }
        public DateTime Birthday { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Address { get; set; }

        public virtual ICollection<Cart> Carts { get; set; }
        public virtual ICollection<Order> Orders { get; set; }
    }
}
