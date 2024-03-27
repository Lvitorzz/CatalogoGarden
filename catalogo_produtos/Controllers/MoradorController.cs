
using catalogo_produtos.Models;
using catalogo_produtos.Service.MoradorService;

using Microsoft.AspNetCore.Mvc;

namespace catalogo_produtos.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MoradorController : ControllerBase
    {
        private readonly IMoradorInterface _moradorInterface;
        public MoradorController(IMoradorInterface moradorInterface)
        {
            _moradorInterface = moradorInterface;
        }
        [HttpGet]
        public async Task<ActionResult<ServiceResponse<List<MoradorModel>>>> GetMoradores()
        {
            return Ok(await _moradorInterface.GetMoradores());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ServiceResponse<MoradorModel>>> GetMoradoresById(int id)
        {
            ServiceResponse<MoradorModel> serviceResponse = await _moradorInterface.GetMoradorById(id);
            return Ok(serviceResponse);
        }

        [HttpPost]
        public async Task<ActionResult<ServiceResponse<List<MoradorModel>>>> CreateMorador(MoradorModel novoMorador)
        {
            return Ok(await _moradorInterface.CreateMorador(novoMorador));
        }

        [HttpPut]
        public async Task<ActionResult<ServiceResponse<List<MoradorModel>>>> UpdateMorador(MoradorModel editadoMorador)
        {
            ServiceResponse<List<MoradorModel>> serviceResponse = await _moradorInterface.UpdateMorador(editadoMorador);
            return Ok(serviceResponse);
        }

        [HttpPut("inativaMorador/{id}")]
        public async Task<ActionResult<ServiceResponse<List<MoradorModel>>>> InativaMorador(int id)
        {
            ServiceResponse<List<MoradorModel>> serviceResponse = await _moradorInterface.InativaMorador(id);
            return Ok(serviceResponse);
        }

        [HttpDelete]
        public async Task<ActionResult<ServiceResponse<List<ProdutoModel>>>> DeleteMorador(int id)
        {
            ServiceResponse<List<MoradorModel>> serviceResponse = await _moradorInterface.DeleteMorador(id);
            return Ok(serviceResponse);
        }
    }
}
