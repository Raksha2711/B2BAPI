using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Data.Entity
{
    [Table("Area", Schema = "master")]
    public class AreaMaster
    {
        [Key]
        public int Id { get; set; }
        //[DataType]
        public string Name { get; set; }

        public int Status { get; set; }

        public int StateId { get; set; }

        public int CreatedBy { get; set; }
        public int ModifiedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime ModifiedDate { get; set; }
    }
}
