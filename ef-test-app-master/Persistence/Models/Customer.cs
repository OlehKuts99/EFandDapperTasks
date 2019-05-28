using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Persistence.Models
{
  public class Customer
  {
    public int ID { get; set; }

    public string Name { get; set; }

    [MaxLength(20)]
    public string Location { get; set; }

    public Guid? LicenseId { get; set; }

    public License License { get; set; }

    public ICollection<Order> Orders { get; set; }
  }
}
