using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Classified.RealEstate.Domain.Entities
{
    public class Location: BaseEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string Advantages { get; set; }

        public ICollection<Review> Reviews { get; set; }

    }
}
