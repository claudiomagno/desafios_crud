using Example.Domain.Util;

namespace Example.Domain.ExampleAggregate
{
    public sealed class Pessoa
    {
   
       private Pessoa(string nome, string Cpf,int Idade, int Id_Cidade)
        {
            this.Nome = nome;
            this.Cpf = Cpf;
            this.Idade = Idade;
            this.Id_Cidade = Id_Cidade;
        }

        public int Id { get; set; }

        public string Nome { get; set; }

        public string Cpf { get; set; }

        public int Idade { get; set; }

        public int Id_Cidade { get; set; }

        //[System.Runtime.Serialization.IgnoreDataMember]
        public Cidade Cidade { get; set; }


        public static Pessoa Create(string Nome, string Cpf, int Idade, int Id_Cidade) => Valida( Nome,  Cpf,  Idade,  Id_Cidade);

        public void Update(string Nome, string Cpf, int Idade, int Id_Cidade)
        {
            if (Nome != null)
                this.Nome = Nome;
            if (Cpf != null)
                this.Cpf = Cpf;
            if (Idade != 0)
                this.Idade = Idade;
            if (Id_Cidade != 0)
                this.Id_Cidade = Id_Cidade;
         
        }

        public static Pessoa Valida(string Nome, string Cpf, int Idade, int Id_Cidade)
        {
            if (Nome == null)
                throw new ArgumentException("Invalid " + nameof(Nome));

            if (Cpf == null)
                throw new ArgumentException("Invalid " + nameof(Cpf));
            if (!ValidaModel.IsCpf(Cpf))
                throw new ArgumentException("Invalid " + nameof(Cpf));
            else
                Cpf = Cpf.Replace(".", "").Replace("-", "").Trim();

            if (Id_Cidade == 0)
                throw new ArgumentException("Invalid " + nameof(Cidade));
            if (Idade == 0)
                throw new ArgumentException("Invalid " + nameof(Idade));

            return new Pessoa(Nome, Cpf, Idade, Id_Cidade);
        }
    }
}