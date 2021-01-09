using System;
using System.Collections.Generic;
using System.Text;

namespace Data.Entity
{
   public class ServiceMaster
    {
        public int Id { get; set; }

        public string Name { get; set; }
        public string Address { get; set; }
        public string ContactNo { get; set; }
        public string Email { get; set; }
        public string Area { get; set; }
        
        public int Brand { get; set; }
        public int Status { get; set; }
        public int CreatedBy { get; set; }
        public int ModifiedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime ModifiedDate { get; set; }
    }
}
