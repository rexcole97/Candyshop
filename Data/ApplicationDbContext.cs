using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using candyshop.Data;

namespace candyshop.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<candyshop.Data.candies> candies { get; set; }
        public DbSet<candyshop.Data.Cshop> Cshop { get; set; }
    }
}
