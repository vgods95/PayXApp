using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PayxApp.Models;

namespace PayxApp.Mapeamentos
{
    public class BoletoMap : IEntityTypeConfiguration<Boleto>
    {
        public void Configure(EntityTypeBuilder<Boleto> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).HasColumnName("id");

            builder.Property(x => x.CodigoBarras).IsRequired().HasMaxLength(55);
            builder.Property(x => x.CodigoBarras).HasColumnName("codigo_barras");

            builder.Property(x => x.DescricaoDoPagamento).IsRequired().HasMaxLength(300);
            builder.Property(x => x.DescricaoDoPagamento).HasColumnName("descricao_pagamento");

            builder.Property(u => u.CnpjBeneficiario).IsRequired().HasMaxLength(30);
            builder.Property(x => x.CnpjBeneficiario).HasColumnName("cnpj_beneficiario");

            builder.Property(u => u.DataEmissao).IsRequired();
            builder.Property(x => x.DataEmissao).HasColumnName("data_emissao");

            builder.Property(u => u.DataEmissao).IsRequired();
            builder.Property(x => x.DataEmissao).HasColumnName("data_vencimento");

            builder.Property(u => u.UsuarioId).IsRequired();
            builder.Property(x => x.UsuarioId).HasColumnName("usuario_id");

            builder.HasOne(x => x.Usuario).WithMany(x => x.Boletos).HasForeignKey(x => x.UsuarioId);

            builder.ToTable("boleto_bancario");
        }
    }
}
