﻿namespace InstaSport.Data.Models
{
    using System.Collections.Generic;
    using System.Security.Claims;
    using System.Threading.Tasks;
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;

    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit http://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class User : IdentityUser
    {
        public User()
        {
            this.Ratings = new HashSet<Rating>();
            this.Games = new HashSet<Game>();
            this.FavouriteSports = new HashSet<Sport>();
        }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string AvatarUrl { get; set; }

        public string FacebookUrl { get; set; }

        public virtual ICollection<Rating> Ratings { get; set; }

        public virtual ICollection<Game> Games { get; set; }

        public virtual ICollection<Sport> FavouriteSports { get; set; }

        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<User> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);

            // Add custom user claims here
            return userIdentity;
        }
    }
}
