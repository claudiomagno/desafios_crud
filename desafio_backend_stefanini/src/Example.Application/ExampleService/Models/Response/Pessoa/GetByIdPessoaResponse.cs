using Example.Application.Common;
using Example.Application.ExampleService.Models.Dtos;

namespace Example.Application.ExampleService.Models.Response.Pessoa
{
    public class GetByIdPessoaResponse : BaseResponse
    {
        public PessoaDto Pessoa { get; set; }
    }
}
