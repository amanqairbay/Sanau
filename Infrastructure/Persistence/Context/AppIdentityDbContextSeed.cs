using Domain.Entities.Identity;
using Microsoft.AspNetCore.Identity;

namespace Persistence.Context;

public class AppIdentityDbContextSeed
{
    public static void SeedUsers(UserManager<AppUser> userManager)
    {
        if (!userManager.Users.Any())
        {
            var user = new AppUser
            {
                Email = "bob@test.com",
                UserName = "bob@test.com",
                Address = new Address
                {
                    FirstName = "Bob",
                    LastName = "Bobbity",
                    Street = "10 The Street",
                    State = "NY",
                    City = "New York",
                    ZipCode = "90210"
                }
            };

            IdentityResult result = userManager.CreateAsync(user, "Pa$$w0rd").Result;

            if (result.Succeeded)
                userManager.AddToRoleAsync(user, "Customer").Wait();
        }
    }
}