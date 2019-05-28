using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace DapperPersistence.Models
{
    [Table("Licenses")]
    public class License
    {
        [Key]
        public Guid ID { get; set; }

        public int? CustomerId { get; set; }

        public string CreatedBy { get; set; }
    }
}
