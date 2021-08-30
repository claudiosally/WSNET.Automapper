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
    [ApiExplorerSettings(GroupName = "Empresa")]
    public class EmpresaController : ApiControllerBase
    {
        private readonly ILogger<EmpresaController> _logger;
        private readonly IEmpresaService _empresaService;

        public EmpresaController(ILogger<EmpresaController> logger, 
                                 IEmpresaService empresaService,
                                 INotification notification)
            : base(notification)
        {
            _logger = logger;
            _empresaService = empresaService;
        }

        /// <summary>
        /// Listar todas as empresas
        /// </summary>
        [HttpGet]
        [ProducesResponseType(Status200OK)] 
        public async Task<ActionResult<IEnumerable<EmpresaViewModel>>> GetAll([FromQuery] bool? ativas)
        {
            var empresas = await _empresaService.ObterTodas(ativas);

            if (_notification.HasNotifications())
                return BadRequest();

            return Ok(empresas);
        }

        /// <summary>
        /// Buscar empresa pelo identificador
        /// </summary>
        [HttpGet("{id}", Name = "Buscar empresa pelo Id")]
        [ProducesResponseType(Status200OK)]
        [ProducesResponseType(Status404NotFound)]
        public async Task<ActionResult<EmpresaViewModel>> GetPorId([FromRoute] Guid id)
        {
            EmpresaViewModel empresa = await _empresaService.ObterEmpresaPeloId(id);

            if (_notification.HasNotifications())
                return BadRequest();

            if (empresa != null)
                return Ok(empresa);

            return NotFound();
        }


        /// <summary>
        /// Buscar empresa pelo Cnpj
        /// </summary>
        [HttpGet("cnpj/{cnpj}", Name = "Buscar empresa pelo CNPJ")]
        [ProducesResponseType(Status200OK)]
        [ProducesResponseType(Status404NotFound)]
        public async Task<ActionResult<EmpresaViewModel>> GetPorCNPJ([FromRoute] string cnpj)
        {
            EmpresaViewModel empresa = await _empresaService.ObterEmpresaPeloCNPJ(cnpj);

            if (_notification.HasNotifications())
                return BadRequest();

            if (empresa != null)
                return Ok(empresa);

            return NotFound();
        }

        /// <summary>
        /// Buscar empresa pela Razao Social
        /// </summary>
        [HttpGet("razaosocial/{razaoSocial}", Name = "Busca empresa pela Razão Social")]
        [ProducesResponseType(Status200OK)]
        [ProducesResponseType(Status404NotFound)]
        public async Task<ActionResult<EmpresaViewModel>> GetPorRazao([FromRoute] string razaoSocial)
        {
            EmpresaViewModel empresa = await _empresaService.ObterEmpresaPelaRazaoSocial(razaoSocial);

            if (_notification.HasNotifications())
                return BadRequest();

            if (empresa != null)
                return Ok(empresa);

            return NotFound();
        }

        /// <summary>
        /// Cadastrar nova empresa
        /// </summary>
        [HttpPost]
        [ProducesResponseType(Status201Created)]
        public async Task<IActionResult> Cadastrar([FromBody] CadastroEmpresaViewModel model)
        {
            var empresa = await _empresaService.CadastrarAsync(model);

            if (_notification.HasNotifications())
                return BadRequest();

            return Created("", empresa);
        }
    }
}
