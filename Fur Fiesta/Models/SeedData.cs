using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;

namespace FurFiestaApp.Models
{
    public static class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new PetDbContext(
                serviceProvider.GetRequiredService<DbContextOptions<PetDbContext>>()))
            {
                // Look for any pets
                if (context.Pets.Any())
                {
                    return;   // DB has been seeded
                }

                var users = new User[25];
                for (int i = 0; i < 25; i++)
                {
                    users[i] = new User
                    {
                        Username = $"user{i}",
                        Email = $"user{i}@example.com",
                        Location = "Location " + i
                    };
                }

                context.Users.AddRange(users);

                context.Pets.AddRange(
                    Enumerable.Range(1, 25).Select(index => new Pet
                    {
                        Name = "Pet " + index,
                        Species = "Species " + index,
                        Breed = "Breed " + index,
                        Age = index % 10,
                        Owner = users[index % 25] // Assign each pet a user
                    }).ToArray()
                );

                context.SaveChanges();
            }
        }
    }
}
