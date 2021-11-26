using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PayxApp.Models;

namespace PayxApp.Mapeamentos
{
    public class TransacaoDetalheMap : IEntityTypeConfiguration<TransacaoDetalhe>
    {
        public void Configure(EntityTypeBuilder<TransacaoDetalhe> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).HasColumnName("id");

            builder.Property(x => x.ChargeCode).IsRequired().HasMaxLength(300);
            builder.Property(x => x.ChargeCode).HasColumnName("charge_code_juno");

            builder.Property(x => x.ChargeId).IsRequired().HasMaxLength(300);
            builder.Property(x => x.ChargeId).HasColumnName("charge_id_juno");

            builder.Property(x => x.TransacaoId).IsRequired();
            builder.Property(x => x.TransacaoId).HasColumnName("transacao_id");

            builder.Property(x => x.ValorParcela).IsRequired();
            builder.Property(x => x.ValorParcela).HasColumnName("valor_parcela");

            builder.Property(x => x.PagamentoIdJuno).IsRequired(false).HasMaxLength(100);
            builder.Property(x => x.PagamentoIdJuno).HasColumnName("pagamento_id_juno");

            builder.Property(x => x.DataCompensacao).IsRequired(false);
            builder.Property(x => x.DataCompensacao).HasColumnName("data_compensacao");

            builder.Property(x => x.TaxaJuno).IsRequired(false);
            builder.Property(x => x.TaxaJuno).HasColumnName("taxa_juno");

            builder.Property(x => x.PagamentoCriado).IsRequired();
            builder.Property(x => x.PagamentoCriado).HasColumnName("pagamento_criado");

            builder.Property(x => x.FalhaPagamento).IsRequired(false).HasMaxLength(999);
            builder.Property(x => x.FalhaPagamento).HasColumnName("falha_pagamento");

            builder.Property(x => x.Estorno).IsRequired();
            builder.Property(x => x.Estorno).HasColumnName("estorno");

            builder.Property(x => x.DataEstorno).IsRequired(false);
            builder.Property(x => x.DataEstorno).HasColumnName("data_estorno");

            builder.HasOne(x => x.Transacao).WithMany(x => x.TransacaoDetalhe).HasForeignKey(x => x.TransacaoId);

            builder.ToTable("transacao_detalhe");
        }
    }
}
