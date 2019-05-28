using System;
using System.Collections.Generic;
using System.Text;

namespace Persistence.Models
{
  public class Product
  {
    public int ID { get; set; }

    public string Name { get; set; }

    public string Desc { get; set; }

    public double Price { get; set; }

    public ICollection<ProductOrder> ProductOrders { get; set; }
  }
}
