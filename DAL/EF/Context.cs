using DAL.EF.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace DAL.EF
{
    internal class Context: DbContext
    {
        public DbSet<UserEntity> Users { get; set; }
        public DbSet<PollEntity> Polls { get; set; }
        public DbSet<OptionEntity> Options { get; set; }
        public DbSet<VoteEntity> Votes { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<VoteEntity>()
                .HasRequired(v => v.User)  // Configure foreign key to UserEntity
                .WithMany()  // Assuming no navigation property in UserEntity
                .HasForeignKey(v => v.UserId)
                .WillCascadeOnDelete(false); // Disable cascade delete for UserEntity

            modelBuilder.Entity<VoteEntity>()
                .HasRequired(v => v.Option)  // Configure foreign key to OptionEntity
                .WithMany()  // Assuming no navigation property in OptionEntity
                .HasForeignKey(v => v.OptionId)
                .WillCascadeOnDelete(false); // Disable cascade delete for OptionEntity

            modelBuilder.Entity<VoteEntity>()
                .HasRequired(v => v.Poll)  // Configure foreign key to PollEntity
                .WithMany()  // Assuming no navigation property in PollEntity
                .HasForeignKey(v => v.PollId)
                .WillCascadeOnDelete(false); // Disable cascade delete for PollEntity
        }
    }
}
