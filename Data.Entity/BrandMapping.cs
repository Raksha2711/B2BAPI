using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Data.Entity
{
    [Table("BrandMapping", Schema = "dbo")]
    public partial class BrandMapping
    {
        public int Id { get; set; }
        [MaxLength(50)]
        public string Name { get; set; }
        public int? Status { get; set; }
        public int? Brand { get; set; }
        public int? CreatedBy { get; set; }
        public int? ModifiedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? ModifiedDate { get; set; }
    }
}
