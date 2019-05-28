using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DapperPersistence.Models
{
    [Table("Customers")]
    public class Customer
    {
        [Key]
        public int ID { get; set; }

        public string Name { get; set; }

        public string Location { get; set; }

        public Guid LicenseID { get; set; }

        public License License { get; set; }
    }
}
