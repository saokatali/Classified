using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Classified.Domain.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Classified.Infrastructure
{
    public class ClassifiedDbContect : IdentityDbContext<AppUser, AppRole, Guid>
    {

    }
}
