using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Admin.API.Model
{
    public interface ICategoryRepository : IRepositoryBase<CategoryMaster>
    {
       // IEnumerable<CategoryMaster> GetCategory(OwnerParameters ownerParameters);

      //  CategoryMaster GetOwnerById(Guid ownerId);
       // OwnerExtended GetOwnerWithDetails(Guid ownerId);
        //void CreateOwner(CategoryMaster owner);
        //void UpdateOwner(CategoryMaster dbOwner, CategoryMaster owner);
        //void DeleteOwner(CategoryMaster owner);
    }
}
