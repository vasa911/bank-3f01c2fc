using BankSystem.Domain.Aggregates.User;
using BankSystem.Infrastructure.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace BankSystem.Infrastructure
{
    public class BankContext : DbContext, IUnitOfWork
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Account> Accounts { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
        }

        public void SeedAsync()
        {
            Database.EnsureCreated();

            if (!Users.Any())
            {
                Users.Add(new User(
                    new Guid("797c5451-93e9-4af8-86e7-4b440172dea4"), "test -assesment")
                    );
            }

            this.SaveChanges();
        }
    }
}
