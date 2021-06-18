using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace Classified.Domain.Entities
{
    public class AppRole:IdentityRole<Guid>
    {
    }
}
