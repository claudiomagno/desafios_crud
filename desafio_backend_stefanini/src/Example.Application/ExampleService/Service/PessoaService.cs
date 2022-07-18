using Example.Application.Common;
using Example.Application.ExampleService.Models.Dtos;
using Example.Application.ExampleService.Models.Request;
using Example.Application.ExampleService.Models.Request.Pessoa;
using Example.Application.ExampleService.Models.Response;
using Example.Application.ExampleService.Models.Response.Pessoa;
using Example.Infra.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Example.Application.ExampleService.Service
{
    public class PessoaService : BaseService<PessoaService>, IPessoaService
    {
        private readonly ApplicationContext _db;

        public PessoaService(ILogger<PessoaService> logger, Infra.Data.ApplicationContext db) : base(logger)
        {
            _db = db;
        }

        public async Task<GetAllPessoaResponse> GetAllAsync()
        {
            //var entity =  _db.Pessoas.ToList().Join(_db.Cidades.ToList(), p => p.Id_Cidade, c => c.Id, (p, c) =>  new { pessoa = c.Pessoas }).ToList();

            var cidades = await _db.Cidades.ToListAsync();

            var pessoas = await _db.Pessoas.ToListAsync();

            //var lista = (from p in _db.Pessoas.ToList()
            //             join c in _db.Cidades.ToList() on p.Id_Cidade equals c.Id
            //             select new { pessoa = p.Cidade }

            //             ).ToList();


            return new GetAllPessoaResponse()
            {
                Pessoas = pessoas != null ? pessoas.Select(a => (PessoaDto)a).ToList() : new List<PessoaDto>()
            };
        }

        public async Task<GetByIdPessoaResponse> GetByIdAsync(int id)
        {

            var response = new GetByIdPessoaResponse();
            var cidade = await _db.Cidades.ToListAsync();

            var entity = await _db.Pessoas.FirstOrDefaultAsync(item => item.Id == id);

            if (entity != null) response.Pessoa = (PessoaDto)entity;

            return response;
        }

        public async Task<CreatePessoaResponse> CreateAsync(CreatePessoaRequest request)
        {
            if (request == null)
                throw new ArgumentException("Request empty!");


            var Pessoa = Domain.ExampleAggregate.Pessoa.Create(request.Nome, request.Cpf, request.Idade, request.Id_Cidade);


            #region Verificar Cidade

            bool NoExitCidade = await this.VerificarCidadeCPF(Pessoa);
       
            #endregion


            _db.Pessoas.Add(Pessoa);

            await _db.SaveChangesAsync();

            return new CreatePessoaResponse() { Id = Pessoa.Id, Nome = Pessoa.Nome,Cpf = Pessoa.Cpf,Idade= Pessoa.Idade };
        }

        public async Task<UpdatePessoaResponse> UpdateAsync(int id, UpdatePessoaRequest request)
        {
            if (request == null)
                throw new ArgumentException("Request empty!");

            #region Verificar Cidade

            var Pessoa = Domain.ExampleAggregate.Pessoa.Valida(request.Nome, request.Cpf, request.Idade, request.Id_Cidade);

            bool NoExitCidade = await this.VerificarCidadeCPF(Pessoa,false);

            #endregion

            var entity = await _db.Pessoas.FirstOrDefaultAsync(item => item.Id == id);

            if (entity != null)
            {
                entity.Update(request.Nome, request.Cpf, request.Idade, request.Id_Cidade);
                await _db.SaveChangesAsync();
            }

            return new UpdatePessoaResponse();
        }

        public async Task<DeletePessoaResponse> DeleteAsync(int id)
        {

            var entity = await _db.Pessoas.FirstOrDefaultAsync(item => item.Id == id);

            if (entity != null)
            {
                _db.Remove(entity);
                await _db.SaveChangesAsync();
            }

            return new DeletePessoaResponse();
        }

        public  async Task<bool> VerificarCidadeCPF(Domain.ExampleAggregate.Pessoa request, bool Ispessoa = true)
        {
            Domain.ExampleAggregate.Pessoa pessoa = null;

            var cidade = await _db.Cidades.FirstOrDefaultAsync(item => item.Id == request.Id_Cidade);
            if (cidade == null)
                throw new ArgumentException("Cidade não existe!");

            if (Ispessoa)
            {
                pessoa = await _db.Pessoas.FirstOrDefaultAsync(item => item.Cpf == request.Cpf);

                if (pessoa != null)
                    throw new ArgumentException("Cpf já existe!");
            }
      

            return (cidade == null || pessoa != null);
        }
    }
}
