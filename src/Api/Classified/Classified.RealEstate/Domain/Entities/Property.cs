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



    }
}
