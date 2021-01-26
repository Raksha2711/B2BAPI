using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Data.Entity
{
    [Table("Staff", Schema = "master")]
    public partial class StaffMaster
    {
        public int Id { get; set; }
        [MaxLength(100)]
        
        public string Name { get; set; }
        [MaxLength(50)]
        public string Email { get; set; }
        public int? CreatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        public int? ModifiedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public int? Status { get; set; }
        [Column(TypeName = "numeric(11, 0)")]
        public decimal? ContactNo { get; set; }
        [MaxLength(250)]
        public string Remark { get; set; }
        public string Image { get; set; }
    }
}
