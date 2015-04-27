using System;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNet.Identity.EntityFramework;

namespace Vigil
{
    public class VigilUserRole : IdentityUserRole<Guid>
    {
    }
}
