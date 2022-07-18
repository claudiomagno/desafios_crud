using Example.Application.Common;
using Example.Application.ExampleService.Models.Dtos;
using Example.Application.ExampleService.Models.Request;
using Example.Application.ExampleService.Models.Request.Cidade;
using Example.Application.ExampleService.Models.Response;
using Example.Application.ExampleService.Models.Response.Cidade;
using Example.Infra.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Example.Application.ExampleService.Service
{
    public class CidadeService : BaseService<CidadeService>, ICidadeService
    {
        private readonly ApplicationContext _db;

        public CidadeService(ILogger<CidadeService> logger, Infra.Data.ApplicationContext db) : base(logger)
        {
            _db = db;
        }

        public async Task<GetAllCidadeResponse> GetAllAsync()
        {
            var entity = await _db.Cidades.ToListAsync();
            return new GetAllCidadeResponse()
            {
                Cidades = entity != null ? entity.Select(a => (CidadeDto)a).ToList() : new List<CidadeDto>()
            };
        }

        public async Task<GetByIdCidadeResponse> GetByIdAsync(int id)
        {

            var response = new GetByIdCidadeResponse();

            var entity = await _db.Cidades.FirstOrDefaultAsync(item => item.Id == id);

            if (entity != null) response.Cidade = (CidadeDto)entity;

            return response;
        }

        public async Task<CreateCidadeResponse> CreateAsync(CreateCidadeRequest request)
        {
            if (request == null)
                throw new ArgumentException("Request empty!");

            var cidade = Domain.ExampleAggregate.Cidade.Create(request.Nome, request.UF);

            bool NoExitCidade = await this.VerificarCidade(cidade);


            _db.Cidades.Add(cidade);

            await _db.SaveChangesAsync();

            return new CreateCidadeResponse() { Id = cidade.Id };
        }

        public async Task<UpdateCidadeResponse> UpdateAsync(int id, UpdateCidadeRequest request)
        {
            if (request == null)
                throw new ArgumentException("Request empty!");

            var entity = await _db.Cidades.FirstOrDefaultAsync(item => item.Id == id);

            if (entity != null)
            {
                entity.Update(request.Nome, request.UF);
                await _db.SaveChangesAsync();
            }

            return new UpdateCidadeResponse();
        }

        public async Task<DeleteCidadeResponse> DeleteAsync(int id)
        {

            var entity = await _db.Cidades.FirstOrDefaultAsync(item => item.Id == id);

            if (entity != null)
            {
                _db.Remove(entity);
                await _db.SaveChangesAsync();
            }

            return new DeleteCidadeResponse();
        }

        public async Task<bool> VerificarCidade(Domain.ExampleAggregate.Cidade request)
        {
            var cidade = await _db.Cidades.FirstOrDefaultAsync(item => item.Nome.ToUpper() == request.Nome.ToUpper() && item.UF.ToUpper() == request.UF.ToUpper());
            if (cidade != null)
                throw new ArgumentException("Cidade e UF já existe!");
    

            return (cidade == null );
        }
    }
}
