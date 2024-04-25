using Entidades;
using Microsoft.AspNetCore.Mvc;
using Servicos;

namespace Apresentacao
{
    [Route("api/[Controller]")]
    [ApiController]
    public class VenderController : ControllerBase
    {
        private IServVender _servVender;

        public VenderController(IServVender servVender)
        {
            _servVender = servVender;
        }

        [HttpPost]
        public ActionResult Inserir(InserirVenderDTO inserirDto)
        {
            try
            {
                _servVender.Inserir(inserirDto);

                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpGet]
        public IActionResult BuscarTodos()
        {
            try
            {
                var vender = _servVender.BuscarTodos();

                var venderEnxuto = vender.Select(p =>
                    new
                    {
                        Id = p.Id,
                        IdProduto = p.IdProduto,
                        IdFornecedor = p.IdFornecedor,
                        Quantidade = p.Quantidade,
                        Valor = p.Valor
                    }).ToList();

                return Ok(venderEnxuto);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [Route("/api/[controller]/{id}")]
        [HttpDelete]
        public IActionResult Remover(int id)
        {
            try
            {
                _servVender.Remover(id);

                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}
