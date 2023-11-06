using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

#nullable disable

namespace BusinessObject
{
    public partial class Order
    {
        public int Id { get; set; }
        public int Total { get; set; }
        public string Note { get; set; }
        public DateTime Date { get; set; }
        public int? AccountId { get; set; }

        public virtual Account Account { get; set; }
        
        [NotMapped]
        public virtual IEnumerable<OrderDetail> OrderDetails { get; set; }
    }
}
