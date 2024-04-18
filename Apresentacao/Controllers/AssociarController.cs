using Entidades;
using Microsoft.AspNetCore.Mvc;
using Servicos;

namespace Apresentacao
{
    [Route("api/[Controller]")]
    [ApiController]
    public class AssociarController : ControllerBase
    {
        private IServAssociar _servAssociar;

        public AssociarController(IServAssociar servAssociar)
        {
            _servAssociar = servAssociar;
        }

        [HttpPost]
        public ActionResult Inserir(InserirAssociarDTO inserirDto)
        {
            try
            {
                _servAssociar.Inserir(inserirDto);

                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}
