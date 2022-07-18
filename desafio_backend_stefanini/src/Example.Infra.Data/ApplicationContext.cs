using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Example.Infra.Data
{
    public class ApplicationContext : DbContext
    {
        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options)
        {
        }
        //public DbSet<Domain.ExampleAggregate.Example> Examples { get; set; }
        public DbSet<Domain.ExampleAggregate.Cidade> Cidades { get; set; }
        public DbSet<Domain.ExampleAggregate.Pessoa> Pessoas { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            //modelBuilder.ApplyConfiguration(new ExampleEntityTypeConfiguration2());
            //modelBuilder.Entity<Domain.ExampleAggregate.Example>();
            modelBuilder.ApplyConfiguration(new CidadeEntityTypeConfiguration());
            modelBuilder.Entity<Domain.ExampleAggregate.Cidade>();

            modelBuilder.ApplyConfiguration(new PessoaEntityTypeConfiguration());
            modelBuilder.Entity<Domain.ExampleAggregate.Pessoa>();


        }

    }

    public class ExampleEntityTypeConfiguration2 : IEntityTypeConfiguration<Domain.ExampleAggregate.Example>
    {
        public void Configure(EntityTypeBuilder<Domain.ExampleAggregate.Example> orderConfiguration)
        {
            orderConfiguration.ToTable("Example", "dbo");

            orderConfiguration.HasKey(o => o.Id);
            orderConfiguration.Property(o => o.Id).UseIdentityColumn();
            orderConfiguration.Property(o => o.Name).IsRequired();
            orderConfiguration.Property(o => o.Age).IsRequired();
        }
    }

    public class CidadeEntityTypeConfiguration : IEntityTypeConfiguration<Domain.ExampleAggregate.Cidade>
    {
        public void Configure(EntityTypeBuilder<Domain.ExampleAggregate.Cidade> orderConfiguration)
        {
            orderConfiguration.ToTable("Cidade", "dbo");

            orderConfiguration.HasKey(o => o.Id);
            orderConfiguration.Property(o => o.Id).UseIdentityColumn();
            orderConfiguration.Property(o => o.Nome).IsRequired().HasMaxLength(200);
            orderConfiguration.Property(o => o.UF).IsRequired().HasMaxLength(2).IsUnicode(); ;

            orderConfiguration.HasIndex(p => new { p.Nome, p.UF }).IsUnique(true);

        }
    }

    public class PessoaEntityTypeConfiguration : IEntityTypeConfiguration<Domain.ExampleAggregate.Pessoa>
    {

        public void Configure(EntityTypeBuilder<Domain.ExampleAggregate.Pessoa> orderConfiguration)
        {
            orderConfiguration.ToTable("Pessoa", "dbo");

            orderConfiguration.HasKey(o => o.Id);
            orderConfiguration.Property(o => o.Id).UseIdentityColumn();
            orderConfiguration.Property(o => o.Nome).IsRequired().HasMaxLength(300);
            orderConfiguration.Property(o => o.Cpf).IsRequired().HasMaxLength(11);
            orderConfiguration.Property(o => o.Id_Cidade).IsRequired();
            orderConfiguration.Property(o => o.Idade).IsRequired();

            orderConfiguration.HasIndex(p => new { p.Cpf }).IsUnique(true);

            orderConfiguration.HasOne<Domain.ExampleAggregate.Cidade>(s => s.Cidade)
                .WithMany(c => c.Pessoas)
                .HasForeignKey(ad => ad.Id_Cidade);
        }
    }
}
