using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using IST440Team3.Models;

namespace IST440Team3.Data
{
    public class IST440Team3Context : DbContext
    {
        public IST440Team3Context (DbContextOptions<IST440Team3Context> options)
            : base(options)
        {
        }

        public DbSet<IST440Team3.Models.Transformation> Transformation { get; set; }
    }
}
