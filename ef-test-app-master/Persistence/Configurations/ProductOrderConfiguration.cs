using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Persistence.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Persistence.Configurations
{
  public class ProductOrderConfiguration : IEntityTypeConfiguration<ProductOrder>
  {
    public void Configure(EntityTypeBuilder<ProductOrder> builder)
    {
      builder.HasKey(x => new { x.OrderID, x.ProductID });
    }
  }
}
