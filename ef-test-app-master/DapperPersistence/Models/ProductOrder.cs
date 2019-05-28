using System;
using System.Collections.Generic;
using System.Text;

namespace DapperPersistence.Models
{
    public class ProductOrder
    {
        public int ProductID { get; set; }

        public int OrderID { get; set; }

        public int Amount { get; set; }
    }
}
