using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using School.Domain.Entities;
using School.Domain.Entities.IdentityServer;
using System.Text.Json;

namespace School.Infrestructure.Persistence.Seed
{
    public static class DBSeed
    {
        public static async Task SeedData(ApplicationDbContext context)
        {


            await ReadData<Department>("Department", context);
            await ReadData<Student>("Student", context);
            //------------------------------------------------




        }
        public static async Task ReadData<TEntity>(string fileName, ApplicationDbContext context) where TEntity : class
        {
            if (!await context.Set<TEntity>().AnyAsync())
            {
                // Get the base path of the project directory
                var basePath = Path.Combine(Directory.GetCurrentDirectory(), @"..\");

                // Combine it with your desired path
                var filePath = Path.Combine(basePath, "School.Infrestructure", "Persistence", "Seed", "SeedData", $"{fileName}.json");

                // Read the file asynchronously
                var file = await File.ReadAllTextAsync(filePath);

                var data = JsonSerializer.Deserialize<List<TEntity>>(file);

                await context.Set<TEntity>().AddRangeAsync(data);

                await context.SaveChangesAsync();
            }
        }

        public static async Task<List<TEntity>?> ReadDataOnly<TEntity>(string fileName) where TEntity : class
        {

            // Get the base path of the project directory
            var basePath = Path.Combine(Directory.GetCurrentDirectory(), @"..\");

            // Combine it with your desired path
            var filePath = Path.Combine(basePath, "School.Infrestructure", "Persistence", "Seed", "SeedData", $"{fileName}.json");

            // Read the file asynchronously
            var file = await File.ReadAllTextAsync(filePath);

            var data = JsonSerializer.Deserialize<List<TEntity>>(file);

            return data;
        }


        //------------------------------------------------
        public static async Task SeedUsers(UserManager<User> _userManager, RoleManager<Role> _roleManager)

        {
            var firstAdded = !_userManager.Users.Any() && !_roleManager.Roles.Any();

            if (!_userManager.Users.Any())
            {
                var Users = await ReadDataOnly<User>("User");
                if (Users != null && Users.Any())
                {


                    foreach (var user in Users)
                    {

                        await _userManager.CreateAsync(user, user.PasswordHash);
                    }
                }

            }

            if (!_roleManager.Roles.Any())
            {
                var roles = await ReadDataOnly<Role>("Role");
                if (roles != null && roles.Any())
                {

                    foreach (var role in roles)
                    {

                        await _roleManager.CreateAsync(role);
                    }
                }

            }

            if (firstAdded)
            {
                var adminUser = await _userManager.Users.FirstOrDefaultAsync(x => x.UserName.ToLower() == "admin");
                var adminRole = await _roleManager.Roles.FirstOrDefaultAsync(x => x.Name.ToLower() == "admin");
                if (adminUser != null && adminRole != null)
                {
                    var userRoleResult = await _userManager.AddToRoleAsync(adminUser, adminRole.Name);

                }


            }




        }
    }
}
