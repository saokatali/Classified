using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Classified.RealEstate.Domain.Entities
{
    public class Project : BaseEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string FullAddress { get; set; }
        public int Area { get; set; }
        public int Towers { get; set; }

        public Builder Builder { get; set; }
        public ICollection<Property> Properties { get; set; }
        public ICollection<Review> Reviews { get; set; }

    }
}
