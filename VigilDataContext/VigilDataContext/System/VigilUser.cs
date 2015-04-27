using System;
using Microsoft.AspNet.Identity.EntityFramework;

namespace Vigil
{
    public class VigilUser : IdentityUser<Guid, VigilUserLogin, VigilUserRole, VigilUserClaim>
    {
    }
}
