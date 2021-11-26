using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PayxApp.Models;
using System;

namespace PayxApp.Mapeamentos
{
    public class ConfiguracaoJunoMap : IEntityTypeConfiguration<ConfiguracaoJuno>
    {
        public void Configure(EntityTypeBuilder<ConfiguracaoJuno> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).HasColumnName("id");

            builder.Property(u => u.Cnpj).IsRequired().HasMaxLength(30);
            builder.HasIndex(u => u.Cnpj).IsUnique();
            builder.Property(x => x.Cnpj).HasColumnName("cnpj");

            builder.Property(u => u.ClientId).IsRequired().HasMaxLength(100);
            builder.Property(x => x.ClientId).HasColumnName("client_id");

            builder.Property(u => u.ClientSecret).IsRequired().HasMaxLength(100);
            builder.Property(x => x.ClientSecret).HasColumnName("client_secret");

            builder.Property(u => u.ClientResourceToken).HasMaxLength(999);
            builder.Property(x => x.ClientResourceToken).HasColumnName("client_resource_token");

            builder.Property(a => a.ProximoToken).IsRequired();
            builder.Property(x => x.ProximoToken).HasColumnName("data_proximo_token");

            builder.Property(u => u.Token).IsRequired().HasMaxLength(999);
            builder.Property(x => x.Token).HasColumnName("token");

            builder.Property(u => u.PublicToken).IsRequired().HasMaxLength(100);
            builder.Property(x => x.PublicToken).HasColumnName("public_token");

            builder.HasData(new ConfiguracaoJuno { Id = 1, Cnpj = "39.796.247/0001-00", ClientId = "wzBpcAOFm0lHJcK9",  
            ClientSecret = "@}@gw@PbgYFYH+,@(G%lUyXv7acI061$", ClientResourceToken = "A14495AADED039E049C114019546DB89B12BCFFE856A0879740AED12F60A9FDC",
            ProximoToken = DateTime.Now, Token = "eyJhbGciOiJSUzI1NiIsInR5cCI6IkpXVCJ9.eyJ1c2VyX25hbWUiOiJydnBheXhAZ21haWwuY29tIiwic2NvcGUiOlsiYWxsIl0sImV4cCI6MTYxOTE4MDY0MiwianRpIjoiYUQ0enNsY3FhUThPQ3FqcmdNNHhvR1JFTFFrIiwiY2xpZW50X2lkIjoid3pCcGNBT0ZtMGxISmNLOSJ9.KPOtogCG9EPtGphnI3oeejQpsTGnHTu2R-oRhF2FYojheZOXSNA-8Q_Pxz_1yKu3R_4_h7zDcGhc4J0wGJ-fnQbUjov0PQyPJnX_w1Z_mXgpaSOGW_aAiwg2zGfezEmkoxr1uBMRyJ9wRjbWFTdm0rX3tbXSzzkVBE_Xrx8enyBeUqcK_vvM_NYzXfnWZhIkNqnSg_XKWWIakXs44bs3n6z1uTJ5Ko5MWGbS87XCg40yN-WnaaWF6FfJWPVpHsJg7k-cGmw4n6Li2IyOMM9cCxtBlcOT_qc2CMosC5td7Lg_CQz4zbukdSoIdp3tfZM5hXNs-bSBFgROOZNxs5ZgjA",
            PublicToken = "EB82ACAB625BF1AAC5F94DC4DD4CB6FE0E0679F9A3163262FEB2C49D8BD5456A"
            });

            builder.ToTable("configuracao_juno");
        }
    }
}
