using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Classified.RealEstate.Domain.Entities
{
    public class Builder : BaseEntity
    {
        public string Name { get; set; }
        public string About { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        ICollection<Project> Projects { get; set; }





    }
}
