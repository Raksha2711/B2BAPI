using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Admin.API.Model
{


    public class RepositoryWrapper : IRepositoryWrapper
    {
        private TodoContext _repoContext;
        private ICategoryRepository _category;
        // private IAccountRepository _account;
        public ICategoryRepository Category
        {
            get
            {
                if (_category == null)
                {
                    _category = new CategoryRepository(_repoContext);
                }
                return _category;
            }
        }
        //public IAccountRepository Account
        //{
        //    get
        //    {
        //        if (_account == null)
        //        {
        //            _account = new AccountRepository(_repoContext);
        //        }
        //        return _account;
        //    }
        //}
        public RepositoryWrapper(TodoContext repositoryContext)
        {
            _repoContext = repositoryContext;
        }
        public void Save()
        {
            _repoContext.SaveChanges();
        }
    }
}