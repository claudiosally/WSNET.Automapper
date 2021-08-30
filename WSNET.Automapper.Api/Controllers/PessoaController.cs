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
    [ApiExplorerSettings(GroupName = "Pessoa")]
    public class PessoaController : ApiControllerBase
    {
        private readonly ILogger _logger;
        private readonly IPessoaService _pessoaService;

        public PessoaController(ILogger<PessoaController> logger,
                                IPessoaService pessoaService,
                                INotification notification)
            : base(notification)
        {
            _logger = logger;
            _pessoaService = pessoaService;
        }

        /// <summary>
        /// Listar todos as pessoas
        /// </summary>
        [HttpGet]
        [ProducesResponseType(Status200OK)]
           public async Task<ActionResult<IEnumerable<PessoaViewModel>>> GetAll([FromQuery] bool? ativos)
        {
            var pessoas = await _pessoaService.ObterTodos(ativos);

            if (_notification.HasNotifications())
                return BadRequest();

            return Ok(pessoas);
        }

        /// <summary>
        /// Buscar pessoa pelo Identificador
        /// </summary>
        [HttpGet("{id}", Name = "Buscar pessoa pelo Id")]
        [ProducesResponseType(Status200OK)]
        [ProducesResponseType(Status404NotFound)]
        public async Task<ActionResult<PessoaViewModel>> GetPorId([FromRoute] Guid id)
        {
            PessoaViewModel pessoa = await _pessoaService.ObterPessoaPeloId(id);

            if (_notification.HasNotifications())
                return BadRequest();

            if (pessoa != null)
                return Ok(pessoa);

            return NotFound();
        }

        /// <summary>
        /// Buscar pessoa pelo Cpf
        /// </summary>
        [HttpGet("cpf/{cpf}", Name = "Buscar pessoa pelo CPF")]
        [ProducesResponseType(Status200OK)]
        [ProducesResponseType(Status404NotFound)]
        public async Task<ActionResult<PessoaViewModel>> GetPorCPF([FromRoute] string cpf)
        {
            PessoaViewModel pessoa = await _pessoaService.ObterPessoaPeloCPF(cpf);

            if (_notification.HasNotifications())
                return BadRequest();

            if (pessoa != null)
                return Ok(pessoa);

            return NotFound();
        }

        /// <summary>
        /// Buscar pessoa pelo Nome
        /// </summary>
        [HttpGet("nome/{nome}", Name = "Buscar pessoa pelo Nome")]
        [ProducesResponseType(Status200OK)]
        [ProducesResponseType(Status404NotFound)]
        public async Task<ActionResult<PessoaViewModel>> GetPorNome([FromRoute] string nome)
        {
            PessoaViewModel pessoa = await _pessoaService.ObterPessoaPeloNome(nome);

            if (_notification.HasNotifications())
                return BadRequest();

            if (pessoa != null)
                return Ok(pessoa);

            return NotFound();
        }

        /// <summary>
        /// Cadastrar novo pessoa
        /// </summary>
        [HttpPost]
        [ProducesResponseType(Status201Created)]
        public async Task<IActionResult> Cadastrar([FromBody] CadastroPessoaViewModel model)
        {
            var pessoa = await _pessoaService.CadastrarAsync(model);

            if (_notification.HasNotifications())
                return BadRequest();

            return Created("", pessoa);
        }

        /// <summary>
        /// Atualizar pessoa existente
        /// </summary>
        [HttpPatch]
        [ProducesResponseType(Status200OK)]
        public async Task<IActionResult> Atualizar([FromBody] AtualizacaoPessoaViewModel model)
        {
            var pessoa = await _pessoaService.AtualizarAsync(model);

            if (_notification.HasNotifications())
                return BadRequest();

            return Ok(pessoa);
        }

        /// <summary>
        /// Deletar pessoa existente
        /// </summary>
        [HttpDelete("{id}")]
        [ProducesResponseType(Status200OK)]
        public async Task<IActionResult> Atualizar([FromRoute] Guid id)
        {
            await _pessoaService.ApagarPessoa(id);

            if (_notification.HasNotifications())
                return BadRequest();

            return Ok();
        }
    }
}
