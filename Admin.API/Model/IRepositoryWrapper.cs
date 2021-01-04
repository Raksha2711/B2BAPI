using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Admin.API.Model
{
    
        public interface IRepositoryWrapper
        {
            ICategoryRepository Category { get; }
            void Save();
        }
    
}
