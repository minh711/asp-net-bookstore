using System;
using System.Collections.Generic;

#nullable disable

namespace BusinessObject
{
    public partial class Book
    {
        public Book()
        {
            Carts = new HashSet<Cart>();
        }

        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Picture { get; set; }
        public int Price { get; set; }
        public int Quantity { get; set; }

        public virtual ICollection<Cart> Carts { get; set; }
    }
}
