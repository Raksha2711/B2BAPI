﻿using System;
using System.Collections.Generic;
using System.Text;
using Data.Db;
using Data.Entity;

namespace B2b.BusinessService
{
    public class StateService : Repository<StateMaster>, IStateService
    {
        public StateService(B2bDbContext dbContext) : base(dbContext) { }
    }
}
