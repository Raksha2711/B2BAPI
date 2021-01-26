using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Data.Entity
{
    [Table("SubCategory", Schema = "master")]
    public partial class SubCategoryMaster
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int? Status { get; set; }
        public int? CreatedBy { get; set; }
        public int? ModifiedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public string Remark { get; set; }
        public string Image { get; set; }
    }
}
