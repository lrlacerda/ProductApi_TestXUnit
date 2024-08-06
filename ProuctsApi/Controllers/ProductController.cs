using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProuctsApi.Domains;
using ProuctsApi.Interfaces;
using ProuctsApi.Repositories;

namespace ProuctsApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/json")]
    public class ProductController : ControllerBase
    {
        private readonly IProduct _product;

        public ProductController()
        {
            _product = new ProductRepositorie();
        }

        [HttpPost]
        public IActionResult Post(Products p)
        {
            _product.Cadastrar(p);
            return NoContent();
        }

        [HttpGet]
        public IActionResult GetList()
        {
            return Ok(_product.Listar());
        }
        [HttpDelete("{id}")]
        public IActionResult Delete(Guid id)
        {
            _product.Deletar(id);
            return NoContent();
        }

        [HttpPut("{id}")]
        public IActionResult Put(Products p, Guid id)
        {
            _product.Atualizar(id, p);

            return NoContent();
        }
        [HttpGet("{id}")]
        public IActionResult GetById(Guid id)
        {
            return Ok(_product.BuscarPorId(id));
        }
    }
}
