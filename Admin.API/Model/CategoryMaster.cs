using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Admin.API.Model
{
    [Table("CategoryMaster")]
    public class CategoryMaster
    {
        
        public int Id { get; set; }
        [ModelBinder(Name = "Title")]
        public string Name { get; set; }
    }
}
