using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using icbincvdt.Models;

    public class RazorPagesCVContext : DbContext
    {
        public RazorPagesCVContext (DbContextOptions<RazorPagesCVContext> options)
            : base(options)
        {
        }

        public DbSet<icbincvdt.Models.CV> CV { get; set; }
    }
