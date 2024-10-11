using CP2.Application.Dtos;
using CP2.Domain.Entities;
using CP2.Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace CP2.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FornecedorController : ControllerBase
    {
        private readonly IFornecedorApplicationService _applicationService;

        public FornecedorController(IFornecedorApplicationService applicationService)
        {
            _applicationService = applicationService;
        }

        /// <summary>
        /// Método para obter todos os fornecedores cadastrados.
        /// </summary>
        /// <returns>Retorna uma lista de todos os fornecedores.</returns>
        [HttpGet]
        [Produces<IEnumerable<FornecedorEntity>>]
        public IActionResult Get()
        {
            var objModel = _applicationService.ObterTodosFornecedores();

            if (objModel is not null)
                return Ok(objModel);

            return BadRequest("Não foi possivel obter os dados");
        }

        /// <summary>
        /// Método para obter os dados de um fornecedor específico pelo ID.
        /// </summary>
        /// <param name="id">O ID do fornecedor a ser obtido.</param>
        /// <returns>Retorna os dados do fornecedor se encontrado.</returns>
        [HttpGet("{id}")]
        [Produces<FornecedorEntity>]
        public IActionResult GetPorId(int id)
        {
            var objModel = _applicationService.ObterFornecedorPorId(id);

            if (objModel is not null)
                return Ok(objModel);

            return BadRequest("Não foi possivel obter os dados");
        }

        /// <summary>
        /// Método para cadastrar um novo fornecedor.
        /// </summary>
        /// <param name="entity">Objeto com os dados do fornecedor a ser cadastrado.</param>
        /// <returns>Retorna o fornecedor cadastrado se o processo for bem-sucedido.</returns>
        [HttpPost]
        [Produces<FornecedorEntity>]
        public IActionResult Post([FromBody] FornecedorDto entity)
        {
            try
            {
                var objModel = _applicationService.SalvarDadosFornecedor(entity);

                if (objModel is not null)
                    return Ok(objModel);

                return BadRequest("Não foi possivel salvar os dados");
            }
            catch (Exception ex)
            {
                return BadRequest(new
                {
                    Error = ex.Message,
                    status = HttpStatusCode.BadRequest,
                });
            }
        }

        /// <summary>
        /// Método para atualizar os dados de um fornecedor existente.
        /// </summary>
        /// <param name="id">O ID do fornecedor a ser atualizado.</param>
        /// <param name="entity">Objeto com os novos dados do fornecedor.</param>
        /// <returns>Retorna o fornecedor atualizado se o processo for bem-sucedido.</returns>
        [HttpPut("{id}")]
        [Produces<FornecedorEntity>]
        public IActionResult Put(int id, [FromBody] FornecedorDto entity)
        {
            try
            {
                var objModel = _applicationService.EditarDadosFornecedor(id, entity);

                if (objModel is not null)
                    return Ok(objModel);

                return BadRequest("Não foi possivel salvar os dados");
            }
            catch (Exception ex)
            {
                return BadRequest(new
                {
                    Error = ex.Message,
                    status = HttpStatusCode.BadRequest,
                });
            }
        }

        /// <summary>
        /// Método para deletar os dados de um fornecedor pelo ID.
        /// </summary>
        /// <param name="id">O ID do fornecedor a ser deletado.</param>
        /// <returns>Retorna o fornecedor deletado se o processo for bem-sucedido.</returns>
        [HttpDelete("{id}")]
        [Produces<FornecedorEntity>]
        public IActionResult Delete(int id)
        {
            var objModel = _applicationService.DeletarDadosFornecedor(id);

            if (objModel is not null)
                return Ok(objModel);

            return BadRequest("Não foi possivel deletar os dados");
        }
    }
}
