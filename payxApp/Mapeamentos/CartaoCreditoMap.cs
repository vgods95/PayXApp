using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PayxApp.Models;

namespace PayxApp.Mapeamentos
{
    public class CartaoCreditoMap : IEntityTypeConfiguration<CartaoCredito>
    {
        public void Configure(EntityTypeBuilder<CartaoCredito> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).HasColumnName("id");

            builder.Property(x => x.UltimosQuatroDigitos).IsRequired().HasMaxLength(4);
            builder.Property(x => x.UltimosQuatroDigitos).HasColumnName("ultimos_quatro_digitos");

            builder.Property(x => x.MesExpiracao).IsRequired().HasMaxLength(2);
            builder.Property(x => x.MesExpiracao).HasColumnName("mes_expiracao");

            builder.Property(x => x.AnoExpiracao).IsRequired().HasMaxLength(4);
            builder.Property(x => x.AnoExpiracao).HasColumnName("ano_expiracao");

            builder.Property(x => x.HashCartao).IsRequired().HasMaxLength(300);
            builder.Property(x => x.HashCartao).HasColumnName("hash_cartao");

            builder.Property(x => x.Bandeira).IsRequired(false).HasMaxLength(50);
            builder.Property(x => x.Bandeira).HasColumnName("bandeira");

            builder.Property(u => u.UsuarioId).IsRequired();
            builder.Property(x => x.UsuarioId).HasColumnName("usuario_id");

            builder.HasOne(x => x.Usuario).WithMany(x => x.Cartoes).HasForeignKey(x => x.UsuarioId);

            builder.ToTable("cartao_credito");
        }
    }
}
