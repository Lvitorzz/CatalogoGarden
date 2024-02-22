using catalogo_produtos.Models;

namespace catalogo_produtos.Service.ProdutoService
{
    public interface IProdutoInterface
    {
        Task<ServiceResponse<List<ProdutoModel>>> GetProdutos();
        Task<ServiceResponse<List<ProdutoModel>>> CreateProduto(ProdutoModel novoProduto);
        Task<ServiceResponse<ProdutoModel>> GetProdutoById(int id);
        Task<ServiceResponse<List<ProdutoModel>>> UpdateProduto(ProdutoModel editadoProduto);
        Task<ServiceResponse<List<ProdutoModel>>> DeleteProduto(int id);
        Task<ServiceResponse<List<ProdutoModel>>> InativaProduto(int id);
    }
}
