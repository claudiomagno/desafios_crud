using Example.Application.ExampleService.Models.Request;
using Example.Application.ExampleService.Models.Request.Pessoa;
using Example.Application.ExampleService.Models.Response;
using Example.Application.ExampleService.Models.Response.Pessoa;

namespace Example.Application.ExampleService.Service
{
    public interface IPessoaService
    {
        Task<GetAllPessoaResponse> GetAllAsync();
        Task<GetByIdPessoaResponse> GetByIdAsync(int id);
        Task<CreatePessoaResponse> CreateAsync(CreatePessoaRequest request);
        Task<UpdatePessoaResponse> UpdateAsync(int id, UpdatePessoaRequest request);
        Task<DeletePessoaResponse> DeleteAsync(int id);
    }
}
