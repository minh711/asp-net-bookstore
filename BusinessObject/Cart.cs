using System;
using System.Collections.Generic;

#nullable disable

namespace BusinessObject
{
    public partial class Cart
    {
        public int Id { get; set; }
        public int Quantity { get; set; }
        public int? BookId { get; set; }
        public int? AccountId { get; set; }

        public virtual Account Account { get; set; }
        public virtual Book Book { get; set; }
    }
}
