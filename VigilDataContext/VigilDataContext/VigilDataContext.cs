using System;
using Microsoft.AspNet.Identity.EntityFramework;

namespace Vigil
{
    public class VigilDataContext : IdentityDbContext<VigilUser, VigilRole, int, VigilUserLogin, VigilUserRole, VigilUserClaim>
    {
        public VigilDataContext()
            : base("ViglDb")
        {
        }

        protected override void OnModelCreating(System.Data.Entity.DbModelBuilder modelBuilder)
        {
            modelBuilder.Ignore(new Type[] { typeof(IdentityUser), typeof(IdentityRole), typeof(IdentityUserClaim), typeof(IdentityUserRole), typeof(IdentityUserLogin) });
            modelBuilder.RegisterEntityType(typeof(VigilUser));
            modelBuilder.RegisterEntityType(typeof(VigilUserRole));
            modelBuilder.RegisterEntityType(typeof(VigilUserClaim));
            modelBuilder.RegisterEntityType(typeof(VigilUserLogin));
            modelBuilder.RegisterEntityType(typeof(VigilRole));

            base.OnModelCreating(modelBuilder);
        }
    }
}
