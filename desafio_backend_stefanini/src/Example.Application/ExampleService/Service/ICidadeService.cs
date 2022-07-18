using Example.Application.ExampleService.Models.Request;
using Example.Application.ExampleService.Models.Request.Cidade;
using Example.Application.ExampleService.Models.Response;
using Example.Application.ExampleService.Models.Response.Cidade;
using System.Threading.Tasks;

namespace Example.Application.ExampleService.Service
{
    public interface ICidadeService
    {
        Task<GetAllCidadeResponse> GetAllAsync();
        Task<GetByIdCidadeResponse> GetByIdAsync(int id);
        Task<CreateCidadeResponse> CreateAsync(CreateCidadeRequest request);
        Task<UpdateCidadeResponse> UpdateAsync(int id, UpdateCidadeRequest request);
        Task<DeleteCidadeResponse> DeleteAsync(int id);
    }
}
