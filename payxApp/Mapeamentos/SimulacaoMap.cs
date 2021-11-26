using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PayxApp.Models;

namespace PayxApp.Mapeamentos
{
    public class SimulacaoMap : IEntityTypeConfiguration<Simulacao>
    {
        public void Configure(EntityTypeBuilder<Simulacao> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).HasColumnName("id");

            builder.Property(x => x.NomeCompleto).IsRequired().HasMaxLength(300);
            builder.Property(x => x.NomeCompleto).HasColumnName("nome");

            builder.Property(x => x.Email).IsRequired().HasMaxLength(150);
            builder.Property(x => x.Email).HasColumnName("email");

            builder.Property(x => x.Celular).IsRequired().HasMaxLength(20);
            builder.Property(x => x.Celular).HasColumnName("celular");

            builder.Property(x => x.Valor).IsRequired();
            builder.Property(x => x.Valor).HasColumnName("valor");

            builder.Property(x => x.Parcelas).IsRequired();
            builder.Property(x => x.Parcelas).HasColumnName("parcelas");

            builder.Property(x => x.DataHora).IsRequired();
            builder.Property(x => x.DataHora).HasColumnName("data_hora");

            builder.Property(x => x.DesmembramentoParcelasJson).IsRequired();
            builder.Property(x => x.DesmembramentoParcelasJson).HasColumnName("desmembramento_parcelas");

            builder.ToTable("simulacao");
        }
    }
}
