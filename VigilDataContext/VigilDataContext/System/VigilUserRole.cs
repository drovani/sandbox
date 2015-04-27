using System;
using Microsoft.AspNet.Identity.EntityFramework;

namespace Vigil
{
    public class VigilUserRole : IdentityUserRole<int>
    {
        public int VigilUserRoleId { get; set; }
    }
}
