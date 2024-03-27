using catalogo_produtos.Models;
using catalogo_produtos.Service.MoradorProdutoService;
using Microsoft.AspNetCore.Mvc;

namespace catalogo_produtos.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MoradorProdutoController : ControllerBase
    {
        private readonly IMoradorProdutoInterface _moradorProdutoService;

        public MoradorProdutoController(IMoradorProdutoInterface moradorProdutoService)
        {
            _moradorProdutoService = moradorProdutoService;
        }

        [HttpPost("addProdutoToMorador")]
        public async Task<ActionResult<ServiceResponse<List<MoradorProdutosModel>>>> AddProdutoToMorador(int moradorId, int produtoId)
        {
            var serviceResponse = await _moradorProdutoService.AddProdutoToMorador(moradorId, produtoId);
            return Ok(serviceResponse);
        }

        [HttpGet("getMoradorProdutos")]
        public async Task<ActionResult<ServiceResponse<List<MoradorProdutosModel>>>> GetMoradorProdutos()
        {
            var serviceResponse = await _moradorProdutoService.GetMoradorProdutos();
            return Ok(serviceResponse);
        }

        [HttpDelete("removeProdutoFromMorador")]
        public async Task<ActionResult<ServiceResponse<List<MoradorProdutosModel>>>> RemoveProdutoFromMorador(int moradorId, int produtoId)
        {
            var serviceResponse = await _moradorProdutoService.RemoveProdutoFromMorador(moradorId, produtoId);
            return Ok(serviceResponse);
        }
    }
}