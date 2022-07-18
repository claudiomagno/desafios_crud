using Example.Application.Common;

namespace Example.Application.ExampleService.Models.Response.Pessoa
{
    public class CreatePessoaResponse : BaseResponse
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Cpf { get; set; }
        public int Idade { get; set; }
        public int Id_Cidade { get; set; }
    }
}
