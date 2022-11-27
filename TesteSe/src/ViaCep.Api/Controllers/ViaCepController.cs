using MediatR;

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

using System.Net;

using ViaCep.Application.Features.ViaCep.Queries.GetCep;

namespace ViaCep.Api.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class ViaCepController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ViaCepController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("{cep}", Name = "GetCep")]
        [ProducesResponseType(typeof(InfoCepVm), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NoContent)]
        public async Task<ActionResult<InfoCepVm>> GetCep(string cep)
        {
            return await ObeterInfoCep(cep);
        }

        [HttpGet("Se", Name = "GetCepSe")]
        [ProducesResponseType(typeof(InfoCepVm), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NoContent)]
        public async Task<ActionResult<InfoCepVm>> GetCep()
        {
            return await ObeterInfoCep("01001000");
        }

        private async Task<ActionResult<InfoCepVm>> ObeterInfoCep(string cep)
        {
            var query = new GetInfoCepQuery(cep);
            var cepInfo = await _mediator.Send(query);
            if (cepInfo == null)
            {
                return NoContent();
            }
            return Ok(cepInfo);
        }
    }
}
