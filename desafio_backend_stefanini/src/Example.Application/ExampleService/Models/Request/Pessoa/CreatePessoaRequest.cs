﻿namespace Example.Application.ExampleService.Models.Request.Pessoa
{
    public class CreatePessoaRequest
    {
        public string Nome { get; set; }
        public string Cpf { get; set; }

        public int Idade { get; set; }
        public int Id_Cidade { get; set; }
    }
}
