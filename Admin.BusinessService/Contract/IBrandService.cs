﻿using System;
using System.Collections.Generic;
using System.Text;
using Data.Entity;

namespace Admin.BusinessService
{
    public interface IBrandService : IRepository<BrandMaster>
    {
    }
}