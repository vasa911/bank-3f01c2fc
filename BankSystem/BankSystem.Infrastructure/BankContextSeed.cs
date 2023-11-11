using BankSystem.Domain.Aggregates.User;
using Microsoft.EntityFrameworkCore;

namespace BankSystem.Infrastructure
{
    public class BankContextSeed
    {

        public void Seed(BankContext context)
        {
            context.Database.EnsureCreated();

            if (!context.Users.Any())
            {
                context.Users.Add(new User(
                    new Guid("797c5451-93e9-4af8-86e7-4b440172dea4"), "test-assesment")
                    );
            }

            context.SaveChanges();
        }
    }
}
