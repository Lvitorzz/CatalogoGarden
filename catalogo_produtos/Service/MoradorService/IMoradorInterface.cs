using catalogo_produtos.Models;

namespace catalogo_produtos.Service.MoradorService
{
    public interface IMoradorInterface
    {
        Task<ServiceResponse<List<MoradorModel>>> GetMoradores();
        Task<ServiceResponse<List<MoradorModel>>> CreateMorador(MoradorModel novoMorador);
        Task<ServiceResponse<MoradorModel>> GetMoradorById(int id);
        Task<ServiceResponse<List<MoradorModel>>> UpdateMorador(MoradorModel editadoMorador);
        Task<ServiceResponse<List<MoradorModel>>> DeleteMorador(int id);
        Task<ServiceResponse<List<MoradorModel>>> InativaMorador(int id);
    }
}
