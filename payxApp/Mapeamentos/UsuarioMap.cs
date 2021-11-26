using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PayxApp.Models;

namespace PayxApp.Mapeamentos
{
    public class UsuarioMap : IEntityTypeConfiguration<Usuario>
    {
        public void Configure(EntityTypeBuilder<Usuario> builder)
        {

            builder.Property(u => u.Id).ValueGeneratedOnAdd();
            builder.Property(x => x.Id).HasColumnName("id");

            builder.Property(u => u.Cpf).IsRequired().HasMaxLength(30);
            builder.HasIndex(u => u.Cpf).IsUnique();
            builder.Property(x => x.Cpf).HasColumnName("cpf");

            builder.Property(x => x.NomeCompleto).IsRequired().HasMaxLength(300);
            builder.Property(x => x.NomeCompleto).HasColumnName("nome_completo");

            builder.Property(x => x.Email).IsRequired();
            builder.Property(x => x.Email).HasColumnName("email");

            builder.Property(x => x.PhoneNumber).IsRequired();
            builder.Property(x => x.PhoneNumber).HasColumnName("celular");

            builder.Property(u => u.Cep).IsRequired().HasMaxLength(10);
            builder.Property(x => x.Cep).HasColumnName("cep");

            builder.Property(u => u.Logradouro).IsRequired().HasMaxLength(200);
            builder.Property(x => x.Logradouro).HasColumnName("logradouro");

            builder.Property(u => u.Numero).IsRequired().HasMaxLength(10);
            builder.Property(x => x.Numero).HasColumnName("numero");

            builder.Property(u => u.Complemento).IsRequired(false).HasMaxLength(100);
            builder.Property(x => x.Complemento).HasColumnName("complemento");

            builder.Property(u => u.Bairro).IsRequired().HasMaxLength(100);
            builder.Property(x => x.Bairro).HasColumnName("bairro");

            builder.Property(a => a.CidadeId).IsRequired();
            builder.Property(x => x.CidadeId).HasColumnName("cidade_id");

            builder.Property(x => x.Sexo).IsRequired().HasMaxLength(1);
            builder.Property(x => x.Sexo).HasColumnName("sexo");

            builder.Property(a => a.DataNascimento).IsRequired();
            builder.Property(x => x.DataNascimento).HasColumnName("data_nascimento");

            builder.HasOne(c => c.Cidade).WithMany(c => c.Usuarios).HasForeignKey(c => c.CidadeId);

            builder.ToTable("usuario");
        }
    }
}
