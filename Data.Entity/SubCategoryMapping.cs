using System;
using System.Collections.Generic;
using System.Text;

namespace Data.Entity
{
    public class SubCategoryMapping
    {
        public int Id { get; set; }

        public int Brand { get; set; }

        public int Category { get; set; }

        public string ContactPerson { get; set; }
        public string ContactNo { get; set; }
        public int Area { get; set; }
        public int Status { get; set; }
        public int Designation { get; set; }
        public char Visible { get; set; }
        public int CreatedBy { get; set; }
        public int ModifiedBy { get; set; }

        public DateTime CreatedDate { get; set; }
        public DateTime ModifiedDate { get; set; }

    }
}
