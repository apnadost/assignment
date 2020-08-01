using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Knorish.Infrastructure
{
    public class DataContext : DbContext
    {
        public DataContext()
        {
        }
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
           
            base.OnConfiguring(optionsBuilder);

        }


        #region Entity DbSet
        public virtual DbSet<Boat> Boats { get; set; }
        #endregion
    }
}

