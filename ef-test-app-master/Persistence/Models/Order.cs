using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Persistence.Models
{
    public class Order
    {
        public int ID { get; set; }
    
        public DateTime CreatedDate { get; set; }

        public double TotalPrice { get; set; }

        [Column("Status")]
        public string StatusString
        {
            get
            {
                return this.Status.ToString();
            }

            set
            {
                string parseStirng = value;
                Enum.TryParse(typeof(Status), parseStirng, out object temp);
                this.Status = (Status)temp;
            }
        }

        [NotMapped]
        public Status Status { get; set; }

        public int CustomerID { get; set; }

        public Customer Customer { get; set; }

        public ICollection<ProductOrder> ProductOrders { get; set; }
    }

    public enum Status
    {
        Created = 0,
        InProgress = 1,
        Done = 2
    }
}
