using System;
using Microsoft.AspNet.Identity.EntityFramework;

namespace Vigil
{
    public class VigilUserRole : IdentityUserRole<Guid>
    {
        public Guid VigilUserRoleId { get; set; }
    }
}
