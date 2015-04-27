using System;
using Microsoft.AspNet.Identity.EntityFramework;

namespace Vigil
{
    public class VigilRole : IdentityRole<Guid, VigilUserRole>
    {
    }
}
