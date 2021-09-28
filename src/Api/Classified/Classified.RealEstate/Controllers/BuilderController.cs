using System.Threading.Tasks;
using Classified.RealEstate.Application.DTOs;
using Classified.RealEstate.Application.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Classified.RealEstate.Controllers
{

    public class BuilderController : BaseController
    {
        private readonly IBuilderService builderService;

        public BuilderController(IBuilderService builderService)
        {
            this.builderService = builderService;
        }

        public async Task<IActionResult> Save(BuilderDto builderDto)
        {
            var result = await builderService.SaveAsync(builderDto);
            return Ok(result);
        }
    }
}
