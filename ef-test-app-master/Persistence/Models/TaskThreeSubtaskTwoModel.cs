using System;
using System.Collections.Generic;
using System.Text;

namespace Persistence.Models
{
    public class TaskThreeSubtaskTwoModel
    {
        public int CustomerId { get; set; }

        public int LicenseId { get; set; }

        public string CreatedBy { get; set; }

        public List<int> ProductIds { get; set; }

        public List<int> ProductCount { get; set; }
    }
}
