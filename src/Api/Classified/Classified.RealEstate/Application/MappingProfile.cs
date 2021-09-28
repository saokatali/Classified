using AutoMapper;
using Classified.RealEstate.Application.DTOs;
using Classified.RealEstate.Domain.Entities;

namespace Classified.RealEstate.Application
{
    public class MappingProfile: Profile
    {
        public MappingProfile()
        {
            CreateMap<Builder, BuilderDto>();
            CreateMap<BuilderDto, Builder>();


        }


    }
}
