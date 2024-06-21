using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;
using System.Threading.Tasks;

public static class SeedData
{
    public static async Task Initialize(IServiceProvider serviceProvider, UserManager<IdentityUser> userManager)
    {
        var roleManager = serviceProvider.GetRequiredService<RoleManager<IdentityRole>>();

        string[] roleNames = { "Admin", "User" };
        IdentityResult roleResult;

        foreach (var roleName in roleNames)
        {
            var roleExist = await roleManager.RoleExistsAsync(roleName);
            if (!roleExist)
            {
                // Crear los roles y agregarlos a la base de datos
                roleResult = await roleManager.CreateAsync(new IdentityRole(roleName));
            }
        }

        // Lista de administradores a crear
        var admins = new[]
        {
        new { Email = "admin1@example.com", Password = "Admin1@123" },
        new { Email = "admin2@example.com", Password = "Admin2@123" }
    };

        foreach (var admin in admins)
        {
            var user = await userManager.FindByEmailAsync(admin.Email);
            if (user == null)
            {
                var newAdmin = new IdentityUser
                {
                    UserName = admin.Email,
                    Email = admin.Email,
                };

                var createPowerUser = await userManager.CreateAsync(newAdmin, admin.Password);
                if (createPowerUser.Succeeded)
                {
                    // Asignar el rol de "Admin" al usuario
                    await userManager.AddToRoleAsync(newAdmin, "Admin");
                }
            }
        }

        // Crear un usuario estándar si no existe
        var userEmail = "user@example.com";
        var userUser = await userManager.FindByEmailAsync(userEmail);

        if (userUser == null)
        {
            var newUser = new IdentityUser
            {
                UserName = userEmail,
                Email = userEmail,
            };

            string userPassword = "User@123";
            var createUser = await userManager.CreateAsync(newUser, userPassword);
            if (createUser.Succeeded)
            {
                // Asignar el rol de "User" al usuario
                await userManager.AddToRoleAsync(newUser, "User");
            }
        }
    }

}
