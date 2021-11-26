using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PayxApp.Models;

namespace PayxApp.Mapeamentos
{
    public class TransacaoMap : IEntityTypeConfiguration<Transacao>
    {
        public void Configure(EntityTypeBuilder<Transacao> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).HasColumnName("id");

            builder.Property(u => u.UsuarioId).IsRequired();
            builder.Property(x => x.UsuarioId).HasColumnName("usuario_id");

            builder.Property(u => u.DataTransacao).IsRequired();
            builder.Property(x => x.DataTransacao).HasColumnName("data_transacao");

            builder.Property(u => u.ValorFinalTransacao).IsRequired();
            builder.Property(x => x.ValorFinalTransacao).HasColumnName("valor_final_transacao");

            builder.Property(u => u.ValorTransacao).IsRequired();
            builder.Property(x => x.ValorTransacao).HasColumnName("valor_transacao");

            builder.Property(u => u.ValorCusto).IsRequired();
            builder.Property(x => x.ValorCusto).HasColumnName("valor_custo");

            builder.Property(u => u.Parcelamento).IsRequired();
            builder.Property(x => x.Parcelamento).HasColumnName("parcelamento");
            
            builder.Property(u => u.CartaoCreditoId).IsRequired(false);
            builder.Property(x => x.CartaoCreditoId).HasColumnName("cartao_credito_id");

            builder.Property(u => u.BoletoId).IsRequired(false);
            builder.Property(x => x.BoletoId).HasColumnName("boleto_id");

            builder.Property(u => u.ContaId).IsRequired(false);
            builder.Property(x => x.ContaId).HasColumnName("conta_id");

            builder.Property(x => x.StatusTransacao).IsRequired().HasMaxLength(50);
            builder.Property(x => x.StatusTransacao).HasColumnName("status_transacao");

            builder.Property(x => x.CobrancaCriada).IsRequired();
            builder.Property(x => x.CobrancaCriada).HasColumnName("cobranca_criada");

            builder.Property(x => x.DesmembramentoParcelasJson).IsRequired().HasMaxLength(999);
            builder.Property(x => x.DesmembramentoParcelasJson).HasColumnName("desmembramento_parcelas_json");

            builder.Property(x => x.TransactionIdJuno).IsRequired(false).HasMaxLength(50);
            builder.Property(x => x.TransactionIdJuno).HasColumnName("transaction_id_juno");

            builder.Property(x => x.PagamentoCriado).IsRequired();
            builder.Property(x => x.PagamentoCriado).HasColumnName("pagamento_criado");

            builder.Property(x => x.FalhaPagamento).IsRequired(false).HasMaxLength(999);
            builder.Property(x => x.FalhaPagamento).HasColumnName("falha_pagamento");

            builder.Property(x => x.Estorno).IsRequired();
            builder.Property(x => x.Estorno).HasColumnName("estorno");

            builder.Property(x => x.DataEstorno).IsRequired(false);
            builder.Property(x => x.DataEstorno).HasColumnName("data_estorno");

            builder.Property(x => x.EstornoJson).IsRequired(false);
            builder.Property(x => x.EstornoJson).HasColumnName("estorno_json");

            builder.Property(x => x.DataAprovacaoReprovacao).IsRequired(false);
            builder.Property(x => x.DataAprovacaoReprovacao).HasColumnName("data_aprovacao_reprovacao");

            builder.Property(x => x.DataProcessamento).IsRequired(false);
            builder.Property(x => x.DataProcessamento).HasColumnName("data_processamento");

            builder.Property(x => x.MotivoReprovacao).IsRequired(false);
            builder.Property(x => x.MotivoReprovacao).HasColumnName("motivo_reprovacao");

            builder.Property(x => x.UsuarioAprovacaoReprovacaoId).IsRequired(false);
            builder.Property(x => x.UsuarioAprovacaoReprovacaoId).HasColumnName("usuario_aprovacao_reprovacao_id");

            builder.HasOne(x => x.Usuario).WithMany(x => x.Transacoes).HasForeignKey(x => x.UsuarioId);
            builder.HasOne(x => x.Boleto).WithOne(x => x.Transacao).HasForeignKey<Transacao>(x => x.BoletoId);
            builder.HasOne(x => x.Conta).WithMany(x => x.Transacoes).HasForeignKey(x => x.ContaId);
            builder.HasOne(x => x.CartaoCredito).WithMany(x => x.Transacoes).HasForeignKey(x => x.CartaoCreditoId);
            builder.HasOne(x => x.UsuarioAprovacaoReprovacao).WithMany(x => x.TransacoesAprovadasReprovadas).HasForeignKey(x => x.UsuarioAprovacaoReprovacaoId);

            builder.ToTable("transacao");
        }
    }
}
