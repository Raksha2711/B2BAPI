using System;
using System.Collections.Generic;
using System.Text;

namespace Data.Entity
{
    public class BrandMapping
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public int Status { get; set; }
        public int Brand { get; set; }
        public int CreatedBy { get; set; }
        public int ModifiedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime ModifiedDate { get; set; }
    }
}
