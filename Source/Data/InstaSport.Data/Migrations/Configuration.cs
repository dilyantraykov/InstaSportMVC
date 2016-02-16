namespace InstaSport.Data.Migrations
{
    using System.Data.Entity.Migrations;
    using System.Linq;

    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;

    using InstaSport.Common;
    using InstaSport.Data.Models;
    using System.Collections.Generic;
    public sealed class Configuration : DbMigrationsConfiguration<InstaSportDbContext>
    {
        public Configuration()
        {
            this.AutomaticMigrationsEnabled = false;
            this.AutomaticMigrationDataLossAllowed = false;
        }

        protected override void Seed(InstaSportDbContext context)
        {
            const string AdministratorUserName = "instadmin";
            const string AdministratorEmail = "admin@instasport.com";
            const string AdministratorPassword = "admin1";

            var seed = new SeedData();

            if (!context.Roles.Any())
            {
                // Create admin role
                var roleStore = new RoleStore<IdentityRole>(context);
                var roleManager = new RoleManager<IdentityRole>(roleStore);
                var role = new IdentityRole { Name = GlobalConstants.AdministratorRoleName };
                roleManager.Create(role);

                // Create admin user
                var userStore = new UserStore<User>(context);
                var userManager = new UserManager<User>(userStore);
                var user = new User { UserName = AdministratorUserName, Email = AdministratorEmail };
                userManager.Create(user, AdministratorPassword);

                // Assign user to admin role
                userManager.AddToRole(user.Id, GlobalConstants.AdministratorRoleName);
            }

            if (!context.Sports.Any())
            {
                seed.Sports.ForEach(s => context.Sports.Add(s));
                context.SaveChanges();
            }

            if (!context.Cities.Any())
            {
                seed.Cities.ForEach(c => context.Cities.Add(c));
                context.SaveChanges();
            }

            if (!context.Locations.Any())
            {
                seed.Locations.ForEach(l => context.Locations.Add(l));
                context.SaveChanges();
            }
        }
    }
}
