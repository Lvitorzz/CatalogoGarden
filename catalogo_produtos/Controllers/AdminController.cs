using catalogo_produtos.Models;
using catalogo_produtos.Service.AdminService;
using catalogo_produtos.Service.ProdutoService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpLogging;
using Microsoft.AspNetCore.Mvc;

namespace catalogo_produtos.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdminController : ControllerBase
    {
        private readonly  IAdminInterface _adminInterface;

        public AdminController(IAdminInterface adminInterface)
        {
            _adminInterface = adminInterface;
        }
        [HttpPost("create")]
        public async Task<ActionResult<ServiceResponse<List<AdminModel>>>> CreateAdmin(AdminModel novoAdmin)
        {
            return Ok(await _adminInterface.CreateAdmin(novoAdmin));
        }
        [HttpPost("authenticate")]
        public async Task<ActionResult<ServiceResponse<List<AdminModel>>>> AutenticarAdmin(AdminModel admin)
        {
            return Ok(await _adminInterface.AutenticarAdmin(admin));
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<ServiceResponse<AdminModel>>> GetAdminById(int id)
        {
            ServiceResponse<AdminModel> serviceResponse = await _adminInterface.GetAdminById(id);
            return Ok(serviceResponse);
        }
    }
}
