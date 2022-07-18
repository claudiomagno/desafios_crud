using System.Collections.Generic;
using Example.Application.Common;
using Example.Application.ExampleService.Models.Dtos;

namespace Example.Application.ExampleService.Models.Response.Cidade
{
    public class GetAllCidadeResponse: BaseResponse
    {
        public List<CidadeDto> Cidades { get; set; }
    }
}
