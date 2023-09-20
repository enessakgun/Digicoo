using Core.Entities.Concrate;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Conrete.EntityFramework
{
    public class StockContext:DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=(localdb)\MSSQLLocalDB;Database=Dıgıcoo;Trusted_Connection=True");
        }

        public DbSet<User> Users { get; set; }

        public DbSet<OperationClaim> operationClaims { get; set; }

        public DbSet<UserOperationClaim> userOperationClaims { get; set; }
    }
}
