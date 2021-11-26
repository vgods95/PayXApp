using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PayxApp.Models;

namespace PayxApp.Mapeamentos
{
    public class ContaMap : IEntityTypeConfiguration<Conta>
    {
        public void Configure(EntityTypeBuilder<Conta> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).HasColumnName("id");

            builder.Property(x => x.NomeCompletoDestinatario).IsRequired().HasMaxLength(300);
            builder.Property(x => x.NomeCompletoDestinatario).HasColumnName("nome_completo_destinatario");

            builder.Property(x => x.BancoId).IsRequired();
            builder.Property(x => x.BancoId).HasColumnName("banco_id");

            builder.Property(x => x.AgenciaDestino).IsRequired().HasMaxLength(50);
            builder.Property(x => x.AgenciaDestino).HasColumnName("agencia_destino");

            builder.Property(x => x.DigitoAgencia).IsRequired(false).HasMaxLength(1);
            builder.Property(x => x.DigitoAgencia).HasColumnName("digito_agencia");

            builder.Property(x => x.NumeroContaDestino).IsRequired().HasMaxLength(50);
            builder.Property(x => x.NumeroContaDestino).HasColumnName("numero_conta_destino");

            builder.Property(x => x.DigitoConta).IsRequired(false).HasMaxLength(1);
            builder.Property(x => x.DigitoConta).HasColumnName("digito_conta");

            builder.Property(x => x.TipoConta).IsRequired();
            builder.Property(x => x.TipoConta).HasColumnName("tipo_conta");

            builder.Property(x => x.NumeroOperacaoCaixa).IsRequired(false).HasMaxLength(50);
            builder.Property(x => x.NumeroOperacaoCaixa).HasColumnName("numero_operacao_caixa");

            builder.Property(u => u.CpfCnpjDestino).IsRequired().HasMaxLength(30);
            builder.HasIndex(u => u.CpfCnpjDestino);
            builder.Property(x => x.CpfCnpjDestino).HasColumnName("cpf_cnpj_destino");

            builder.Property(x => x.UsuarioId).IsRequired();
            builder.Property(x => x.UsuarioId).HasColumnName("usuario_id");

            builder.HasOne(x => x.Banco).WithMany(x => x.Contas).HasForeignKey(x => x.BancoId);
            builder.HasOne(x => x.Usuario).WithMany(x => x.Contas).HasForeignKey(x => x.UsuarioId);

            builder.ToTable("conta_bancaria");
        }
    }
}
