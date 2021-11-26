using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PayxApp.Models;
using System;

namespace PayxApp.Mapeamentos
{
    public class FuncaoMap : IEntityTypeConfiguration<Funcao>
    {
        public void Configure(EntityTypeBuilder<Funcao> builder)
        {
            builder.Property(f => f.Id).ValueGeneratedOnAdd();
            builder.Property(x => x.Id).HasColumnName("id");

            builder.Property(f => f.Descricao).IsRequired().HasMaxLength(30);
            builder.Property(x => x.Descricao).HasColumnName("descricao");

            builder.HasData(
                new Funcao
                {
                    Id = Guid.NewGuid().ToString(),
                    Name = "Usuario",
                    NormalizedName = "USUARIO",
                    Descricao = "Usuário comum"
                },
                new Funcao
                {
                    Id = Guid.NewGuid().ToString(),
                    Name = "Administrador",
                    NormalizedName = "ADMINISTRADOR",
                    Descricao = "Administrador do Sistema"
                });

            builder.ToTable("funcao");
        }
    }
}
