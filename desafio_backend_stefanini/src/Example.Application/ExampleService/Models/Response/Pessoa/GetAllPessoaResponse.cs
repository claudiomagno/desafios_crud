using System.Collections.Generic;
using Example.Application.Common;
using Example.Application.ExampleService.Models.Dtos;

namespace Example.Application.ExampleService.Models.Response.Pessoa
{
    public class GetAllPessoaResponse : BaseResponse
    {
        public List<PessoaDto> Pessoas { get; set; }
    }
}
