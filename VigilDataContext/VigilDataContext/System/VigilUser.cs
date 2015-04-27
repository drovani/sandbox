using System;
using Microsoft.AspNet.Identity.EntityFramework;

namespace Vigil
{
    public class VigilUser : IdentityUser<int, VigilUserLogin, VigilUserRole, VigilUserClaim>
    {
    }
}
