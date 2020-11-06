using AutoMecanica.ClienteApi.Domain.Entities;
using AutoMecanica.ClienteApi.Domain.Interfaces.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace AutoMecanica.ClienteApi.Host.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiVersion("1.0")]
    [ApiExplorerSettings(GroupName = "v1")]
    public class ClienteController : ControllerBase
    {

        private readonly IClienteRepository clienteRepository;

        public ClienteController(IClienteRepository clienteRepository)
        {
            this.clienteRepository = clienteRepository;
        }

        #region Busca clientes

        [SwaggerOperation(
            Summary = "Lista todos os Clientes.",
            Tags = new[] { "Clientes" },
            Produces = new[] { "application/json"}
        )]
        [HttpGet]
        public IActionResult Lista()
        {
            var clientes = clienteRepository.GetClientes();
            return Ok(clientes);
        }

        #endregion

        #region Busca Cliente
        [SwaggerOperation(
            Summary = "Lista Cliente pelo Id.",
            Tags = new[] { "Clientes" },
            Produces = new[] {"application/json"}
        )]
        [HttpGet("{Id}")]
        public IActionResult Busca(int Id)
        {
            var cliente = clienteRepository.Get(Id);
            return Ok(cliente);
        }


        #endregion

        #region Adiciona Cliente
        [SwaggerOperation(
           Summary = "Adiciona um novo Cliente.",
           Tags = new[] { "Clientes" },
           Produces = new[] { "application/json" }
       )]
        [HttpPost("adiciona")]
        public IActionResult Adiciona([FromBody] Cliente cliente)
        {
            var retorno = clienteRepository.Add(cliente);

            if (retorno > 0)
            {
                return Ok();
            }

            return BadRequest();
        }

        #endregion

        #region Altera Cliente
        [SwaggerOperation(
           Summary = "Altera o Cliente",
           Tags = new[] { "Clientes" },
           Produces = new[] { "application/json" }
       )]
        [HttpPut]
        public IActionResult Altera([FromBody] Cliente cliente)
        {
            var retorno = clienteRepository.Edit(cliente);

            if (retorno > 0)
            {
                return Ok();
            }

            return BadRequest();
        }


        #endregion

        #region Apaga Cliente
        [SwaggerOperation(
           Summary = "Apaga o Cliente pelo Id.",
           Tags = new[] { "Clientes" },
           Produces = new[] { "application/json" }
       )]
        [HttpDelete("{Id}")]
        public IActionResult Apaga(int Id)
        {

            var retorno = clienteRepository.Delete(Id);

            if (retorno > 0)
            {
                return NoContent();
            }

            return NotFound();

        }
        #endregion

    }
}
