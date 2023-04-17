using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.EntityFrameworkCore;

namespace GripFoodEntities.DesignTime
{
    internal class DesignTimeApplicationDbContext : IDesignTimeDbContextFactory<GripFoodDbContext>
    {
        public GripFoodDbContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<GripFoodDbContext>();
            optionsBuilder.UseSqlite("Data Source=local.db");
            var db = new GripFoodDbContext(optionsBuilder.Options);
            return db;
        }
    }
}
