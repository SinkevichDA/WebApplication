using Microsoft.AspNetCore.Identity;
using System.Data;
using WebApplication7.Data;



namespace WebApplication7.Data
{
    public static class DBInitializer
    {
        public static async Task SetupDb(WebApplication app)
        {
            using var scope = app.Services.CreateScope();
            ApplicationDbContext? context = scope.ServiceProvider.GetService(typeof(ApplicationDbContext)) as ApplicationDbContext;
            var usrManager = scope.ServiceProvider.GetService(typeof(UserManager<ApplicationUser>)) as UserManager<ApplicationUser>;
            var roleManager = scope.ServiceProvider.GetService(typeof(RoleManager<IdentityRole>)) as RoleManager<IdentityRole>;



            // создать БД, если она еще не создана
            context.Database.EnsureCreated();
            // проверка наличия ролей
            if (!context.Roles.Any())
            {
                var roleAdmin = new IdentityRole
                {
                    Name = "admin",
                    NormalizedName = "admin"
                };
                // создать роль admin
                await roleManager.CreateAsync(roleAdmin);
            }



            if (!context.Users.Any())
            {
              
                var user = new ApplicationUser
                {
                    Email = "user@mail.ru",
                    UserName = "user@mail.ru",
                };
                // check if user exists
                if (await usrManager.FindByEmailAsync(user.Email) == null)
                {
                    await usrManager.CreateAsync(user, "123456");
                }

                // create user admin@mail.ru 
                var admin = new ApplicationUser
                {
                    Email = "admin@mail.ru",
                    UserName = "admin@mail.ru"
                };
                // check if admin exists
                if (await usrManager.FindByEmailAsync(admin.Email) == null)
                {
                    await usrManager.CreateAsync(admin, "123456");
                }

                // assign role admin to admin user
                admin = await usrManager.FindByEmailAsync("admin@mail.ru");
                if (admin != null)
                {
                    await usrManager.AddToRoleAsync(admin, "admin");
                }
            }
        }
    }
}
