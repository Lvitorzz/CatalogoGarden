using catalogo_produtos.Models;
using catalogo_produtos.Service.ProdutoService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace catalogo_produtos.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProdutoController : ControllerBase
    {
        private readonly IProdutoInterface _produtoInterface;
        public ProdutoController(IProdutoInterface produtoInterface)
        {
            _produtoInterface = produtoInterface;
        }
        [HttpGet]
        public async Task<ActionResult<ServiceResponse<List<ProdutoModel>>>> GetProdutos()
        {
            return Ok( await _produtoInterface.GetProdutos());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ServiceResponse<ProdutoModel>>> GetProdutoById(int id)
        {
            ServiceResponse<ProdutoModel> serviceResponse = await _produtoInterface.GetProdutoById(id);
            return Ok(serviceResponse);
        }

        [HttpPost]
        public async Task<ActionResult<ServiceResponse<List<ProdutoModel>>>> CreateProdutos(ProdutoModel novoProduto)
        {
            return Ok( await _produtoInterface.CreateProduto(novoProduto));
        }

        [HttpPut]
        public async Task<ActionResult<ServiceResponse<List<ProdutoModel>>>> UpdateProdutos(ProdutoModel editadoProduto)
        {
            ServiceResponse<List<ProdutoModel>> serviceResponse = await _produtoInterface.UpdateProduto(editadoProduto);
            return Ok(serviceResponse);
        }

        [HttpPut("inativaProduto/{id}")]
        public async Task<ActionResult<ServiceResponse<List<ProdutoModel>>>> InativaProduto(int id)
        {
            ServiceResponse<List<ProdutoModel>> serviceResponse = await _produtoInterface.InativaProduto(id);
            return Ok(serviceResponse);
        }

        [HttpDelete]
        public async Task<ActionResult<ServiceResponse<List<ProdutoModel>>>> DeleteProdutos(int id)
        {
            ServiceResponse<List<ProdutoModel>> serviceResponse = await _produtoInterface.DeleteProduto(id);
            return Ok(serviceResponse);
        }
    }
}
