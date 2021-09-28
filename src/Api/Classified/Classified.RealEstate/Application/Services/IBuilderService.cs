using System.Threading.Tasks;
using Classified.RealEstate.Application.DTOs;

namespace Classified.RealEstate.Application.Services
{
    public interface IBuilderService
    {
        Task<bool> SaveAsync(BuilderDto builder);
    }
}