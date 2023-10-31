using System;
using System.Collections.Generic;

#nullable disable

namespace BusinessObject
{
    public partial class OrderDetail
    {
        public int? OrderId { get; set; }
        public int? BookId { get; set; }
        public int Quantity { get; set; }
        public int Price { get; set; }

        public virtual Book Book { get; set; }
        public virtual Order Order { get; set; }
    }
}
