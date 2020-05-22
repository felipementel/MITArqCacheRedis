using Aplicacao.Application.Interfaces;
using Aplicacao.Application.ViewModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net.Mime;

namespace Aplicacao.API.Controllers
{
    //[Authorize("Bearer")]
    [ApiVersion("1")]
    [Route("api/[controller]/{version}")]
    [ApiController]
    public class ClientesController : ControllerBase
    {
        private readonly ILogger<ClientesController> _logger;

        private readonly IConfiguration _config;

        private readonly IClienteApplication _clienteApplication;

        public ClientesController(ILogger<ClientesController> logger,
            IConfiguration config,
            IClienteApplication clientService)
        {
            _logger = logger;
            _config = config;
            _clienteApplication = clientService;
        }

        [HttpGet(Name = nameof(GetAll))]
        [MapToApiVersion("1")]
        [Consumes(MediaTypeNames.Application.Json)]
        [ProducesResponseType(typeof(IEnumerable<ClienteViewModel>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        public ActionResult<IEnumerable<ClienteViewModel>> GetAll()
        {
            Stopwatch sw = new Stopwatch();
            sw.Start();

            var clienteViewModel = _clienteApplication.GetAll();

            if (clienteViewModel == null)
                return NoContent();

            sw.Stop();

            return Ok(new
            {
                success = true,
                data = clienteViewModel,
                tempoProcessamento =
                $"{TimeSpan.FromMilliseconds(sw.ElapsedMilliseconds).Seconds} segundos e " +
                $"{TimeSpan.FromMilliseconds(sw.ElapsedMilliseconds).Milliseconds} milessegundos"
            });
        }

        [HttpGet("{id}", Name = nameof(Get))]
        [MapToApiVersion("1")]
        [Consumes(MediaTypeNames.Application.Json)]
        [ProducesResponseType(typeof(ClienteViewModel), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult Get(int id)
        {
            Stopwatch sw = new Stopwatch();
            sw.Start();

            var clienteViewModel = _clienteApplication.Get(id);

            if (clienteViewModel == null)
                return NoContent();

            sw.Stop();

            return Ok(new
            {
                success = true,
                data = clienteViewModel,
                tempoProcessamento =
                $"{TimeSpan.FromMilliseconds(sw.ElapsedMilliseconds).Seconds} segundos e " +
                $"{TimeSpan.FromMilliseconds(sw.ElapsedMilliseconds).Milliseconds} milessegundos"
            });
        }

        [HttpPost(Name = nameof(Post))]
        [MapToApiVersion("1")]
        [Consumes(MediaTypeNames.Application.Json)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult Post([FromBody] ClienteViewModel clienteViewModel)
        {
            if (!ModelState.IsValid)
                return NotFound();

            _clienteApplication.Add(clienteViewModel);

            return Created(Url.RouteUrl(clienteViewModel.Identificador), clienteViewModel.Identificador);

        }

        [HttpPut("{id}", Name = nameof(Put))]
        [MapToApiVersion("1")]
        [Consumes(MediaTypeNames.Application.Json)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult Put(int id, [FromBody] ClienteViewModel clienteViewModel)
        {
            if (!ModelState.IsValid)
                return NotFound();

            _clienteApplication.Update(clienteViewModel);

            return NoContent();
        }

        [HttpDelete("{id}", Name = nameof(Delete))]
        [MapToApiVersion("1")]
        [Consumes(MediaTypeNames.Application.Json)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult Delete(int id)
        {
            _clienteApplication.Remove(id);

            return NoContent();
        }
    }
}
