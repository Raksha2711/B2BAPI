using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Data.Entity
{
    [Table("BrandMaster", Schema = "dbo")]
    public partial class BrandMaster
    {
        public int Id { get; set; }
        [MaxLength(50)]
        public string Name { get; set; }
        [MaxLength(50)]
        public string Status { get; set; }
        [MaxLength(50)]
        public string Website { get; set; }
        [Column(TypeName = "numeric(11, 0)")]
        public decimal? TollFreeNo { get; set; }
        public int? CreatedBy { get; set; }
        public int? ModifiedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public string Image { get; set; }
        [MaxLength(250)]
        public string Remark { get; set; }
    }
}
