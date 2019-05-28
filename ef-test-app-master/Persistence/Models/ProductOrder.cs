using System;
using System.Collections.Generic;
using System.Text;

namespace Persistence.Models
{
  public class ProductOrder
  {
    public int ProductID { get; set; }

    public Product Product { get; set; }

    public int OrderID { get; set; }

    public Order Order { get; set; }

    public int Amount { get; set; }
  }
}
