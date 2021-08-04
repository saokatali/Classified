using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Classified.RealEstate.Domain.Entities
{
    public class Review: BaseEntity
    {
        public Guid UserId { get; set; }

        public string UserName { get; set; }

        public string Text { get; set; }

    }
}
