using catalogo_produtos.DataContext;
using catalogo_produtos.Models;
using Microsoft.EntityFrameworkCore;

namespace catalogo_produtos.Service.ProdutoService
{
    public class ProdutoService : IProdutoInterface
    {
        private readonly ApplicationDbContext _context;
        public ProdutoService(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<ServiceResponse<List<ProdutoModel>>> CreateProduto(ProdutoModel novoProduto)
        {
            ServiceResponse<List<ProdutoModel>> serviceResponse = new ServiceResponse<List<ProdutoModel>>();

            try
            {
                if (novoProduto == null)
                {
                    serviceResponse.Dados = null;
                    serviceResponse.Mensagem = "Informar Dados!";
                    serviceResponse.Sucesso = false;

                    return serviceResponse;
                }

                _context.Add(novoProduto);
                await _context.SaveChangesAsync();

                serviceResponse.Dados = _context.Produtos.ToList();
                

            }catch (Exception ex)
            {
                serviceResponse.Mensagem = ex.Message;
                serviceResponse.Sucesso = false;
            }
            return serviceResponse;
        }

        public async Task<ServiceResponse<List<ProdutoModel>>> DeleteProduto(int id)
        {
            ServiceResponse<List<ProdutoModel>> serviceResponse = new ServiceResponse<List<ProdutoModel>>();

            try
            {
                ProdutoModel produto = _context.Produtos.FirstOrDefault(x => x.Id == id);

                if (produto == null)
                {
                    serviceResponse.Dados = null;
                    serviceResponse.Mensagem = "Produto não localizado!";
                    serviceResponse.Sucesso = false;

                    return serviceResponse;
                }

                _context.Produtos.Remove(produto);
                await _context.SaveChangesAsync();

                serviceResponse.Dados = _context.Produtos.ToList();

            }catch (Exception ex)
            {
                serviceResponse.Mensagem = ex.Message;
                serviceResponse.Sucesso = false;
            }
            return serviceResponse;
        }

        public async Task<ServiceResponse<ProdutoModel>> GetProdutoById(int id)
        {
            ServiceResponse<ProdutoModel> serviceResponse = new ServiceResponse<ProdutoModel>();

            try
            {
                ProdutoModel produto = _context.Produtos.FirstOrDefault(x => x.Id == id);

                serviceResponse.Dados = produto;

                if (produto == null)
                {
                    serviceResponse.Dados= null;
                    serviceResponse.Mensagem = "Produto não localizado!";
                    serviceResponse.Sucesso = false;
                }

            }catch (Exception ex)
            {
                serviceResponse.Mensagem = ex.Message;
                serviceResponse.Sucesso = false;
            }
            return serviceResponse;
        }

        public async Task<ServiceResponse<List<ProdutoModel>>> GetProdutos()
        {
            ServiceResponse<List<ProdutoModel>> serviceResponse = new ServiceResponse<List<ProdutoModel>>();

            try
            {
                serviceResponse.Dados = _context.Produtos.ToList();

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

        public async Task<ServiceResponse<List<ProdutoModel>>> InativaProduto(int id)
        {
            ServiceResponse<List<ProdutoModel>> serviceResponse = new ServiceResponse<List<ProdutoModel>>();

            try
            {
                ProdutoModel produto = _context.Produtos.FirstOrDefault(x => x.Id == id);

                if (produto == null)
                {
                    serviceResponse.Dados = null;
                    serviceResponse.Mensagem = "Produto não localizado!";
                    serviceResponse.Sucesso = false;
                }

                produto.Ativo = false;
                produto.DataDeAlteracao = DateTime.Now.ToLocalTime();

                _context.Produtos.Update(produto);
                await _context.SaveChangesAsync();

                serviceResponse.Dados = _context.Produtos.ToList();
            }
            catch (Exception ex)
            {
                serviceResponse.Mensagem = ex.Message;
                serviceResponse.Sucesso = false;
            }
            return serviceResponse;
        }

        public async Task<ServiceResponse<List<ProdutoModel>>> UpdateProduto(ProdutoModel editadoProduto)
        {
            ServiceResponse<List<ProdutoModel>> serviceResponse = new ServiceResponse<List<ProdutoModel>>();
            try
            {
                ProdutoModel produto = _context.Produtos.AsNoTracking().FirstOrDefault(x => x.Id == editadoProduto.Id);
                if (produto == null)
                {
                    serviceResponse.Dados = null;
                    serviceResponse.Mensagem = "Produto não localizado";
                    serviceResponse.Sucesso = false;
                }

                produto.DataDeAlteracao = DateTime.Now.ToLocalTime();
                _context.Produtos.Update(editadoProduto);
                await _context.SaveChangesAsync();

                serviceResponse.Dados = _context.Produtos.ToList();

            }catch (Exception ex)
            {
                serviceResponse.Mensagem = ex.Message;
                serviceResponse.Sucesso = false;
            }
            return serviceResponse;
        }
    }
}
