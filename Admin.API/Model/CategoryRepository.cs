using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Admin.API.Model
{

    public class CategoryRepository : RepositoryBase<CategoryMaster>, ICategoryRepository
    {
        public CategoryRepository(TodoContext repositoryContext)
            : base(repositoryContext)
        {
        }
        //public IEnumerable<CategoryMaster> GetCategory(OwnerParameters ownerParameters)
        //{
        //    return FindAll()
        //        .OrderBy(on => on.Name)
        //        .Skip((ownerParameters.PageNumber - 1) * ownerParameters.PageSize)
        //        .Take(ownerParameters.PageSize)
        //        .ToList();

        //}
    }
}
   