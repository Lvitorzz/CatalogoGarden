using catalogo_produtos.DataContext;
using catalogo_produtos.Models;
using Microsoft.EntityFrameworkCore;

namespace catalogo_produtos.Service.MoradorService
{
    public class MoradorService : IMoradorInterface
    {
        private readonly ApplicationDbContext _context;
        public MoradorService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<ServiceResponse<List<MoradorModel>>> CreateMorador(MoradorModel novoMorador)
        {
            ServiceResponse<List<MoradorModel>> serviceResponse = new ServiceResponse<List<MoradorModel>>();

            try
            {
                if (novoMorador == null)
                {
                    serviceResponse.Dados = null;
                    serviceResponse.Mensagem = "Informar Dados!";
                    serviceResponse.Sucesso = false;

                    return serviceResponse;
                }

                _context.Add(novoMorador);
                await _context.SaveChangesAsync();

                serviceResponse.Dados = _context.Moradores.ToList();


            }
            catch (Exception ex)
            {
                serviceResponse.Mensagem = ex.Message;
                serviceResponse.Sucesso = false;
            }
            return serviceResponse;
        }

        public async Task<ServiceResponse<List<MoradorModel>>> DeleteMorador(int id)
        {
            ServiceResponse<List<MoradorModel>> serviceResponse = new ServiceResponse<List<MoradorModel>>();

            try
            {
                MoradorModel morador = _context.Moradores.FirstOrDefault(x => x.Id == id);

                if (morador == null)
                {
                    serviceResponse.Dados = null;
                    serviceResponse.Mensagem = "Morador não localizado!";
                    serviceResponse.Sucesso = false;

                    return serviceResponse;
                }

                _context.Moradores.Remove(morador);
                await _context.SaveChangesAsync();

                serviceResponse.Dados = _context.Moradores.ToList();

            }
            catch (Exception ex)
            {
                serviceResponse.Mensagem = ex.Message;
                serviceResponse.Sucesso = false;
            }
            return serviceResponse;
        }

        public async Task<ServiceResponse<MoradorModel>> GetMoradorById(int id)
        {
            ServiceResponse<MoradorModel> serviceResponse = new ServiceResponse<MoradorModel>();

            try
            {
                MoradorModel morador = _context.Moradores.FirstOrDefault(x => x.Id == id);

                serviceResponse.Dados = morador;

                if (morador == null)
                {
                    serviceResponse.Dados = null;
                    serviceResponse.Mensagem = "Morador não localizado!";
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

        public async Task<ServiceResponse<List<MoradorModel>>> GetMoradores()
        {
            ServiceResponse<List<MoradorModel>> serviceResponse = new ServiceResponse<List<MoradorModel>>();

            try
            {
                serviceResponse.Dados = _context.Moradores.ToList();

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

        public async Task<ServiceResponse<List<MoradorModel>>> InativaMorador(int id)
        {
            ServiceResponse<List<MoradorModel>> serviceResponse = new ServiceResponse<List<MoradorModel>>();

            try
            {
                MoradorModel morador = _context.Moradores.FirstOrDefault(x => x.Id == id);

                if (morador == null)
                {
                    serviceResponse.Dados = null;
                    serviceResponse.Mensagem = "Morador não localizado!";
                    serviceResponse.Sucesso = false;
                }

                morador.Ativo = false;
                morador.DataDeAlteracao = DateTime.Now.ToLocalTime();

                _context.Moradores.Update(morador);
                await _context.SaveChangesAsync();

                serviceResponse.Dados = _context.Moradores.ToList();
            }
            catch (Exception ex)
            {
                serviceResponse.Mensagem = ex.Message;
                serviceResponse.Sucesso = false;
            }
            return serviceResponse;
        }

        public async Task<ServiceResponse<List<MoradorModel>>> UpdateMorador(MoradorModel editadoMorador)
        {
            ServiceResponse<List<MoradorModel>> serviceResponse = new ServiceResponse<List<MoradorModel>>();
            try
            {
                MoradorModel morador = _context.Moradores.AsNoTracking().FirstOrDefault(x => x.Id == editadoMorador.Id);
                if (morador == null)
                {
                    serviceResponse.Dados = null;
                    serviceResponse.Mensagem = "Morador não localizado";
                    serviceResponse.Sucesso = false;
                }

                morador.DataDeAlteracao = DateTime.Now.ToLocalTime();
                _context.Moradores.Update(editadoMorador);
                await _context.SaveChangesAsync();

                serviceResponse.Dados = _context.Moradores.ToList();

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
