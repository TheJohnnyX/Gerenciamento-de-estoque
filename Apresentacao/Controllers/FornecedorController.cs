using Microsoft.AspNetCore.Mvc;
using Servicos;

namespace Apresentacao
{
    [Route("api/[Controller]")]
    [ApiController]
    public class FornecedorController : ControllerBase
    {
        private IServFornecedor _servFornecedor;

        public FornecedorController(IServFornecedor servFornecedor)
        {
            _servFornecedor = servFornecedor;
        }

        [HttpPost]
        public ActionResult Inserir(InserirFornecedorDTO inserirDto)
        {
            try
            {
                _servFornecedor.Inserir(inserirDto);

                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [Route("/api/[controller]/{id}")]
        [HttpPut]
        public IActionResult Editar(int id, [FromBody] EditarFornecedorDTO editarDto)
        {
            try
            {
                _servFornecedor.Editar(id, editarDto);

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
                var fornecedores = _servFornecedor.BuscarTodos();

                var fornecedorEnxuto = fornecedores.Select(p =>
                    new
                    {
                        Id = p.Id,
                        Nome = p.Nome
                    }).ToList();

                return Ok(fornecedorEnxuto);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [Route("/api/[controller]/{id}")]
        [HttpGet]
        public IActionResult BuscarPorId(int id)
        {
            try
            {
                var fornecedor = _servFornecedor.BuscarPorId(id);

                return Ok(fornecedor);
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
                _servFornecedor.Remover(id);

                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}
