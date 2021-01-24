using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Data.Entity
{
    [Table("SubCategory", Schema = "mapping")]
    public partial class SubCategoryMapping
    {
        public int Id { get; set; }
        public int? Brand { get; set; }
        public int? Category { get; set; }
        public string ContactPerson { get; set; }
        public decimal? ContactNo { get; set; }
        public int? Area { get; set; }
        public int? Status { get; set; }
        public int? Designation { get; set; }
        public string VisibleDesg { get; set; }
        public int? CreatedBy { get; set; }
        public int? ModifiedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public string VisibleContact { get; set; }
        public string VisibleEmail { get; set; }
        public string VisiblePerson { get; set; }
    }
}
