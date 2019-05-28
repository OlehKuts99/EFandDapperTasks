using System;
using System.Collections.Generic;
using System.Text;

namespace Persistence.Models
{
  public class License
  {
    public Guid ID { get; set; }

    public int? CustomerId { get; set; }
    
    public Customer Customer { get; set; }

    public string CreatedBy { get; set; }
  }
}
