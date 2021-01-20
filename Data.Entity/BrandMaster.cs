using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Data.Entity
{
    public class BrandMaster
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Status { get; set; }
        public string Website { get; set; }
        public string TollFreeNo { get; set; }
        public int CreatedBy { get; set; }
        public int ModifiedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime ModifiedDate { get; set; }
    }
}
