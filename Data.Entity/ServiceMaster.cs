using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Data.Entity
{
    [Table("Service", Schema = "master")]
    public partial class ServiceMaster
    {
        public int Id { get; set; }
        [MaxLength(100)]
        public string Name { get; set; }
        public string Address { get; set; }
        [Column(TypeName = "numeric(11, 0)")]
        public decimal? ContactNo { get; set; }
        [MaxLength(100)]
        public string Email { get; set; }
        [MaxLength(100)]
        public string Area { get; set; }
        public int? Status { get; set; }
        public int? Brand { get; set; }
        public int? CreatedBy { get; set; }
        public int? ModifiedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public string Remarks { get; set; }
    }
}
