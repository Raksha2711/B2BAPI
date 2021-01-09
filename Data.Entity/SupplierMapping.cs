using System;
using System.Collections.Generic;
using System.Text;

namespace Data.Entity
{
    public class SupplierMapping
    {
        public int Id { get; set; }

        public string Name { get; set; }
        public string Type { get; set; }
        public int Status { get; set; }
        public string Brand { get; set; }
        public string SubCategory { get; set; }
        public int CreatedBy { get; set; }
        public int ModifiedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime ModifiedDate { get; set; }
    }
}
