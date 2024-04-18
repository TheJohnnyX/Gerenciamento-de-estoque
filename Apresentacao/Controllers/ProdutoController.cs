using Microsoft.AspNetCore.Mvc;
using Servicos;

namespace Apresentacao
{
    [Route("api/[Controller]")]
    [ApiController]
    public class ProdutoController : ControllerBase
    {
        private IServProduto _servProduto;

        public ProdutoController(IServProduto servProduto)
        {
            _servProduto = servProduto;
        }

        [HttpPost]
        public ActionResult Inserir(InserirProdutoDTO inserirDto)
        {
            try
            {
                _servProduto.Inserir(inserirDto);

                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [Route("/api/[controller]/{id}")]
        [HttpPut]
        public IActionResult Editar(int id, [FromBody] EditarProdutoDTO editarDto)
        {
            try
            {
                _servProduto.Editar(id, editarDto);

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
                var produtos = _servProduto.BuscarTodos();

                var produtoEnxuto = produtos.Select(p =>
                    new
                    {
                        Id = p.Id,
                        Nome = p.Nome
                    }).ToList();

                return Ok(produtoEnxuto);
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
                var produto = _servProduto.BuscarPorId(id);

                return Ok(produto);
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
                _servProduto.Remover(id);

                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}
