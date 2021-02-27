using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using toplearn.Datalayer.Entities.User;
using toplearn.Datalayer.Entities.Wallet;

namespace toplearn.Datalayer.Context
{
   public class ToplearnContext:DbContext
    {
        public ToplearnContext(DbContextOptions<ToplearnContext> options):base(options)
        {


        }
        #region User
        public DbSet<Role> Roles { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<UserRole> userRoles { get; set; }
        #endregion
        #region Wallet

        public DbSet<Wallet> Wallets { get; set; }
        public DbSet<WalletType> WalletTypes { get; set; }
        #endregion

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().HasQueryFilter(u => !u.IsDelete);
            modelBuilder.Entity<Role>().HasQueryFilter(r => !r.IsDelete);

            base.OnModelCreating(modelBuilder);
        }

    }
}
