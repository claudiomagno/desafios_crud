using Example.Domain.ExampleAggregate;

namespace Example.Application.ExampleService.Models.Dtos
{
    public class PessoaDto
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Cpf { get; set; }

        public int Idade { get; set; }
        public CidadeDto Cidade { get; set; }

        public static explicit operator PessoaDto(Domain.ExampleAggregate.Pessoa v)
        {
            var cidade = new CidadeDto { Id = v.Cidade.Id, Nome = v.Cidade.Nome, UF = v.Cidade.UF};
            return new PessoaDto()
            {
                Id = v.Id,
                Nome = v.Nome,
                Cpf = v.Cpf,
                Idade= v.Idade,
                Cidade = cidade

            };
        }
    }
}
