using System;
using System.Collections.Generic;

namespace Data.Entity
{
    public partial class TransactionData
    {
        public int Id { get; set; }
        public string ItemId { get; set; }
        public string CategoryId { get; set; }
        public string BrandId { get; set; }
        public string SupplierId { get; set; }
        public string SupplierType { get; set; }
        public int? Status { get; set; }
    }
}
