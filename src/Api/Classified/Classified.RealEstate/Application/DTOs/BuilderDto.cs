using Classified.RealEstate.Domain.Entities;
using System.Collections.Generic;

namespace Classified.RealEstate.Application.DTOs
{
    public class BuilderDto
    {
        public string Name { get; set; }
        public string About { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }

    }
}
