using System;
using System.Collections.Generic;
using System.Text;
using Data.Entity;

namespace Admin.BusinessService
{
    public class SupplierService : Repository<SupplierMaster>, ISupplierService
    {
    }
}
