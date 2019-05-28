using System;
using System.Collections.Generic;
using System.Text;

namespace DapperPersistence.Models
{
    public class Product
    {
        public int ID { get; set; }

        public string Name { get; set; }

        public string Desc { get; set; }

        public double Price { get; set; }
    }
}
