using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Classified.RealEstate.Domain.Entities
{
    public class Property:BaseEntity
    {
        public string Title { get; set; }
        public string About { get; set; }
        public string Location { get; set; }
        public string FullAddress { get; set; }
        public string Status { get; set; }
        public double Price { get; set; }

        public int Area { get; set; }

        public int Rate { get; set; }

        public DateTime PossessionBy { get; set; }

        public Project Project { get; set; }




        public PropertyType Type { get; set; }


    }
}
