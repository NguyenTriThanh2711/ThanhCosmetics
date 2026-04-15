using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThanhCometics.Repository
{
    public class ThanhCometicsDBContext : DbContext
    {
        public ThanhCometicsDBContext(DbContextOptions<ThanhCometicsDBContext> options) : base(options){ }
        //public DbSet<U> Products { get; set; }
    }
}
