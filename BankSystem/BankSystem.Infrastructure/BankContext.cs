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
            options.UseInMemoryDatabase("BankSystemDb");
        }

    }
}
