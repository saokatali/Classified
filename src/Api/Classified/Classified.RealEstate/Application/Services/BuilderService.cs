using Classified.RealEstate.Application.DTOs;
using Classified.RealEstate.Infrastructure;
using Microsoft.Extensions.Logging;
using AutoMapper;
using Classified.RealEstate.Domain.Entities;
using System.Threading.Tasks;

namespace Classified.RealEstate.Application.Services
{
    public class BuilderService : IBuilderService
    {
        private readonly RealEstateDataContext dataContext;
        private readonly ILogger<BuilderService> logger;
        private readonly IMapper mapper;

        public BuilderService(RealEstateDataContext dataContext, ILogger<BuilderService> logger, IMapper mapper)
        {
            this.dataContext = dataContext;
            this.logger = logger;
            this.mapper = mapper;
        }

        public async Task<bool>  SaveAsync(BuilderDto builderDto)
        {
            Builder builder = mapper.Map<Builder>(builderDto);
            dataContext.Builders.Add(builder);
            var result = await dataContext.SaveChangesAsync();
            return result > 0;

        }
    }
}
