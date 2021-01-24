using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Data.Entity
{
    [Table("Staff", Schema = "master")]
    public partial class StaffMaster
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public int? CreatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        public int? ModifiedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public int? Status { get; set; }
        public decimal? ContactNo { get; set; }
        public string Remark { get; set; }
        public string Image { get; set; }
    }
}
