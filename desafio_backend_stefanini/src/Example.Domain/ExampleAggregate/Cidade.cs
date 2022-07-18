namespace Example.Domain.ExampleAggregate
{
    public  class Cidade
    {
        private Cidade(string nome, string UF)
        {
            this.Nome = nome;
            this.UF = UF;
     
        }

        public int Id { get; set; }

        public string Nome { get; set; }

        public string UF { get; set; }

        //[System.Runtime.Serialization.IgnoreDataMember]
        public virtual  ICollection<Pessoa> Pessoas { get; set; }



        public static Cidade Create(string nome, string UF)
        {
            if (nome == null)
                throw new ArgumentException("Invalid " + nameof(nome));

            if (UF == null)
                throw new ArgumentException("Invalid " + nameof(UF));
            else
                UF = UF.ToUpper();


            return new Cidade(nome, UF);
        }

        public void Update(string nome, string UF)
        {
            if (nome != null)
                this.Nome = nome;

            if (UF != null)
                this.UF = UF;

           
        }
    }
}