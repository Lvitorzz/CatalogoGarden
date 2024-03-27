using catalogo_produtos.Models;

namespace catalogo_produtos.Service.MoradorProdutoService
{
    public interface IMoradorProdutoInterface
    {
        Task<ServiceResponse<List<MoradorProdutosModel>>> GetMoradorProdutos();
        Task<ServiceResponse<List<MoradorProdutosModel>>> AddProdutoToMorador(int moradorId, int produtoId);
        Task<ServiceResponse<List<MoradorProdutosModel>>> RemoveProdutoFromMorador(int moradorId, int produtoId);
    }
}
