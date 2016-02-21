namespace InstaSport.Data
{
    using System;
    using System.Data.Entity;
    using System.Linq;
    using Common.Models;
    using InstaSport.Data.Models;
    using Microsoft.AspNet.Identity.EntityFramework;

    public class InstaSportDbContext : IdentityDbContext<User>
    {
        public InstaSportDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public IDbSet<Sport> Sports { get; set; }

        public IDbSet<Game> Games { get; set; }

        public IDbSet<City> Cities { get; set; }

        public IDbSet<Location> Locations { get; set; }

        public static InstaSportDbContext Create()
        {
            return new InstaSportDbContext();
        }

        public override int SaveChanges()
        {
            this.ApplyAuditInfoRules();
            return base.SaveChanges();
        }

        private void ApplyAuditInfoRules()
        {
            // Approach via @julielerman: http://bit.ly/123661P
            foreach (var entry in
                this.ChangeTracker.Entries()
                    .Where(
                        e =>
                        e.Entity is IAuditInfo && ((e.State == EntityState.Added) || (e.State == EntityState.Modified))))
            {
                var entity = (IAuditInfo)entry.Entity;
                if (entry.State == EntityState.Added && entity.CreatedOn == default(DateTime))
                {
                    entity.CreatedOn = DateTime.Now;
                }
                else
                {
                    entity.ModifiedOn = DateTime.Now;
                }
            }
        }
    }
}
