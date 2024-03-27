using catalogo_produtos.DataContext;
using catalogo_produtos.Models;
using Microsoft.EntityFrameworkCore;

namespace catalogo_produtos.Service.MoradorProdutoService
{
    public class MoradorProdutoService : IMoradorProdutoInterface
    {
        private readonly ApplicationDbContext _context;
        public MoradorProdutoService(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<ServiceResponse<List<MoradorProdutosModel>>> AddProdutoToMorador(int moradorId, int produtoId)
        {
            ServiceResponse<List<MoradorProdutosModel>> serviceResponse = new ServiceResponse<List<MoradorProdutosModel>>();
            try
            {
                MoradorModel morador = await _context.Moradores.FirstOrDefaultAsync(x => x.Id == moradorId);
                ProdutoModel produto = await _context.Produtos.FirstOrDefaultAsync(x => x.Id == produtoId);

                if (morador == null || produto == null)
                {
                    serviceResponse.Dados = null;
                    serviceResponse.Mensagem = "Morador ou produto não encontrado!";
                    serviceResponse.Sucesso = false;
                    return serviceResponse;
                }

                MoradorProdutosModel novaAssociacao = new MoradorProdutosModel
                {
                    MoradorId = moradorId,
                    ProdutoId = produtoId
                };
                _context.MoradoresProdutos.Add(novaAssociacao);

                await _context.SaveChangesAsync();

                serviceResponse.Dados = await _context.MoradoresProdutos.ToListAsync();
            }
            catch (Exception ex)
            {
                serviceResponse.Mensagem = ex.Message;
                serviceResponse.Sucesso = false;
            }
            return serviceResponse;
        }

        public async Task<ServiceResponse<List<MoradorProdutosModel>>> GetMoradorProdutos()
        {
            ServiceResponse<List<MoradorProdutosModel>> serviceResponse = new ServiceResponse<List<MoradorProdutosModel>>();
            try
            {
                serviceResponse.Dados = await _context.MoradoresProdutos.ToListAsync();

                if (serviceResponse.Dados.Count == 0)
                {
                    serviceResponse.Mensagem = "Nenhum dado encontrado!";
                }
            }
            catch (Exception ex)
            {
                serviceResponse.Mensagem = ex.Message;
                serviceResponse.Sucesso = false;
            }
            return serviceResponse;
        }

        public async Task<ServiceResponse<List<MoradorProdutosModel>>> RemoveProdutoFromMorador(int moradorId, int produtoId)
        {
            ServiceResponse<List<MoradorProdutosModel>> serviceResponse = new ServiceResponse<List<MoradorProdutosModel>>();
            try
            {
                MoradorProdutosModel associacao = await _context.MoradoresProdutos.FirstOrDefaultAsync(x => x.MoradorId == moradorId && x.ProdutoId == produtoId);

                if (associacao == null)
                {
                    serviceResponse.Dados = null;
                    serviceResponse.Mensagem = "Associação não encontrada!";
                    serviceResponse.Sucesso = false;
                    return serviceResponse;
                }

                _context.MoradoresProdutos.Remove(associacao);
                await _context.SaveChangesAsync();

                serviceResponse.Dados = await _context.MoradoresProdutos.ToListAsync();
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
