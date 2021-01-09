using System;
using System.Collections.Generic;
using System.Text;

namespace Data.Entity
{
    public class SupplierMaster
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public int Status { get; set; }
        public string Address { get; set; }
        public string Pincode { get; set; }
        public string ContactPerson1 { get; set; }

        public string Mobile1 { get; set; }
        public string ContactPerson2 { get; set; }
        public string Mobile2 { get; set; }
        public string EmailId { get; set; }
        
        public int CreatedBy { get; set; }
        public int ModifiedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime ModifiedDate { get; set; }
    }
}
