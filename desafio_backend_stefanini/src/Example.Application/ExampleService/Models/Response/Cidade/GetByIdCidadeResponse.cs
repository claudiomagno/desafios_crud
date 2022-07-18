using Example.Application.Common;
using Example.Application.ExampleService.Models.Dtos;

namespace Example.Application.ExampleService.Models.Response.Cidade
{
    public class GetByIdCidadeResponse : BaseResponse
    {
        public CidadeDto Cidade { get; set; }
    }
}
