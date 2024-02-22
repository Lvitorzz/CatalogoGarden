using catalogo_produtos.DataContext;
using catalogo_produtos.Models;
using Microsoft.EntityFrameworkCore;

namespace catalogo_produtos.Service.AdminService
{
    public class AdminService : IAdminInterface
    {
        private readonly ApplicationDbContext _context;
        public AdminService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<ServiceResponse<List<AdminModel>>> AutenticarAdmin(AdminModel admin)
        {
            ServiceResponse<List<AdminModel>> serviceResponse = new ServiceResponse<List<AdminModel>>();

            try
            {
                if (admin == null)
                {
                    serviceResponse.Dados = null;
                    serviceResponse.Mensagem = "Informar dados!";
                    serviceResponse.Sucesso = false;

                    return serviceResponse;
                }

                AdminModel adminModel = _context.Admins.FirstOrDefault(x => x.NomeUsuario == admin.NomeUsuario);

                if (adminModel == null)
                {
                    serviceResponse.Dados = null;
                    serviceResponse.Mensagem = "Usuário não encontrado.";
                    serviceResponse.Sucesso = false;

                    return serviceResponse;
                }

                if (admin.Senha != adminModel.Senha)
                {
                    serviceResponse.Dados = null;
                    serviceResponse.Mensagem = "Credenciais inválidas.";
                    serviceResponse.Sucesso = false;

                    return serviceResponse;
                }

                serviceResponse.Dados = _context.Admins.ToList();
                serviceResponse.Mensagem = "Autenticação bem-sucedida.";
                serviceResponse.Sucesso = true;
            }
            catch (Exception ex)
            {
                serviceResponse.Mensagem = ex.Message;
                serviceResponse.Sucesso = false;
            }
            return serviceResponse;
        }

        public async Task<ServiceResponse<List<AdminModel>>> CreateAdmin(AdminModel novoAdmin)
        {
            ServiceResponse<List<AdminModel>> serviceResponse = new ServiceResponse<List<AdminModel>>();
            try
            {
                if (novoAdmin == null)
                {
                    serviceResponse.Dados = null;
                    serviceResponse.Mensagem = "Informar dados!";
                    serviceResponse.Sucesso = false;

                    return serviceResponse;
                }
                _context.Add(novoAdmin);
                await _context.SaveChangesAsync();

                serviceResponse.Dados = _context.Admins.ToList();
            }
            catch (Exception ex)
            {
                serviceResponse.Mensagem = ex.Message;
                serviceResponse.Sucesso = false;
            }
            return serviceResponse;
        }
        public async Task<ServiceResponse<AdminModel>> GetAdminById(int id)
        {
            ServiceResponse<AdminModel> serviceResponse = new ServiceResponse<AdminModel>();

            try
            {
                AdminModel admin = _context.Admins.FirstOrDefault(x => x.Id == id);

                serviceResponse.Dados = admin;

                if (admin == null)
                {
                    serviceResponse.Dados = null;
                    serviceResponse.Mensagem = "Produto não localizado!";
                    serviceResponse.Sucesso = false;
                }

            }
            catch (Exception ex)
            {
                serviceResponse.Mensagem = ex.Message;
                serviceResponse.Sucesso = false;
            }
            return serviceResponse;
        }
    }
}
