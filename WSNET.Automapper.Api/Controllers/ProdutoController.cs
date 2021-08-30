using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using WSNET.Automapper.Application.Service.Interface;
using WSNET.Automapper.Application.ViewModel;
using WSNET.Automapper.Domain.Services.Interface;
using static Microsoft.AspNetCore.Http.StatusCodes;

namespace WSNET.Automapper.Api.Controllers
{
    [ApiExplorerSettings(GroupName = "Produto")]
    public class ProdutoController : ApiControllerBase
    {
        private readonly ILogger<ProdutoController> _logger;
        private readonly IProdutoService _produtoService;

        public ProdutoController(ILogger<ProdutoController> logger, 
                                 IProdutoService produtoService,
                                 INotification notification)
            : base(notification)
        {
            _logger = logger;
            _produtoService = produtoService;
        }

        /// <summary>
        /// Listar todos os produtos
        /// </summary>
        [HttpGet]
        [ProducesResponseType(Status200OK)]
        public async Task<ActionResult<IEnumerable<ProdutoViewModel>>> GetAll([FromQuery] bool? ativos)
        {
            var produtos = await _produtoService.ObterTodos(ativos);
            
            if (_notification.HasNotifications())
                return BadRequest();

            return Ok(produtos);
        }

        /// <summary>
        /// Buscar produto pelo Identificador
        /// </summary>
        [HttpGet("{id}", Name = "Buscar produto pelo Id")]
        [ProducesResponseType(Status200OK)]
        [ProducesResponseType(Status404NotFound)]
        public async Task<ActionResult<ProdutoViewModel>> GetPorId([FromRoute] Guid id)
        {
            ProdutoViewModel produto = await _produtoService.ObterProdutoPeloId(id);

            if (_notification.HasNotifications())
                return BadRequest();

            if (produto != null)
                return Ok(produto);

            return NotFound();
        }

       
        /// <summary>
        /// Buscar produto pela descrição
        /// </summary>
        [HttpGet("nome/{descricao}", Name = "Buscar produto pela descricao")]
        [ProducesResponseType(Status200OK)]
        [ProducesResponseType(Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult<ProdutoViewModel>> GetPorDescricao([FromRoute] string descricao)
        {
            ProdutoViewModel produto = await _produtoService.ObterProdutoPelaDescricao(descricao);

            if (_notification.HasNotifications())
                return BadRequest();

            if (produto != null)
                return Ok(produto);

            return NotFound();
        }

        /// <summary>
        /// Cadastrar novo produto
        /// </summary>
        [HttpPost]
        [ProducesResponseType(Status201Created)]
        public async Task<IActionResult> Cadastrar([FromBody] CadastroProdutoViewModel model)
        {
            var produto = await _produtoService.CadastrarAsync(model);

            if (_notification.HasNotifications())
                return BadRequest();

            return Created("", produto);
        }

        /// <summary>
        /// Deletar produto existente
        /// </summary>
        [HttpDelete("{id}")]
        [ProducesResponseType(Status200OK)]
        public async Task<IActionResult> Atualizar([FromRoute] Guid id)
        {
            await _produtoService.ApagarProduto(id);

            if (_notification.HasNotifications())
                return BadRequest();

            return Ok();
        }
    }
}
