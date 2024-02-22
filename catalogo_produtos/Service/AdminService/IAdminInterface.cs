using catalogo_produtos.Models;

namespace catalogo_produtos.Service.AdminService
{
    public interface IAdminInterface
    {
        Task<ServiceResponse<List<AdminModel>>> CreateAdmin(AdminModel novoAdmin);
        Task<ServiceResponse<List<AdminModel>>> AutenticarAdmin(AdminModel admin);
        Task<ServiceResponse<AdminModel>> GetAdminById(int id);
    }
}
