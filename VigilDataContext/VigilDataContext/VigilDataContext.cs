using System;
using Microsoft.AspNet.Identity.EntityFramework;

namespace Vigil
{
    public class VigilDataContext : IdentityDbContext<VigilUser, VigilRole, Guid, VigilUserLogin, VigilUserRole, VigilUserClaim>
    {
        public VigilDataContext()
            : base("ViglDb")
        {
        }
    }
}
