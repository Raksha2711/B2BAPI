using Microsoft.EntityFrameworkCore;


namespace Admin.API.Model
{
   
        public class TodoContext : DbContext
        {
            public TodoContext(DbContextOptions<TodoContext> options)
                : base(options)
            {
            }

            public DbSet<CategoryMaster> CategoryMaster { get; set; }

            public DbSet<BrandMaster> BrandMaster { get; set; }

            public DbSet<SubCategoryMaster> SubCategoryMaster { get; set; }
        }
    
}
