using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PayxApp.Models;

namespace PayxApp.Mapeamentos
{
    public class BancoMap : IEntityTypeConfiguration<Banco>
    {
        public void Configure(EntityTypeBuilder<Banco> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).HasColumnName("id");

            builder.Property(x => x.Codigo).IsRequired().HasMaxLength(10);
            builder.Property(x => x.Codigo).HasColumnName("codigo");

            builder.Property(x => x.Nome).IsRequired().HasMaxLength(300);
            builder.Property(x => x.Nome).HasColumnName("nome");

            builder.HasMany(x => x.Contas).WithOne(x => x.Banco);

            builder.HasData(new Banco { Id = 1, Codigo = "246", Nome = "Banco ABC Brasil S.A." });
            builder.HasData(new Banco { Id = 2, Codigo = "075", Nome = "Banco ABN AMRO S.A." });
            builder.HasData(new Banco { Id = 3, Codigo = "121", Nome = "Banco Agibank S.A." });
            builder.HasData(new Banco { Id = 4, Codigo = "025", Nome = "Banco Alfa S.A." });
            builder.HasData(new Banco { Id = 5, Codigo = "641", Nome = "Banco Alvorada S.A." });
            builder.HasData(new Banco { Id = 6, Codigo = "065", Nome = "Banco Andbank (Brasil) S.A." });
            builder.HasData(new Banco { Id = 7, Codigo = "096", Nome = "Banco B3 S.A." });
            builder.HasData(new Banco { Id = 8, Codigo = "024", Nome = "Banco BANDEPE S.A." });
            builder.HasData(new Banco { Id = 9, Codigo = "318", Nome = "Banco BMG S.A." });
            builder.HasData(new Banco { Id = 10, Codigo = "752", Nome = "Banco BNP Paribas Brasil S.A." });
            builder.HasData(new Banco { Id = 11, Codigo = "107", Nome = "Banco BOCOM BBM S.A." });
            builder.HasData(new Banco { Id = 12, Codigo = "063", Nome = "Banco Bradescard S.A." });
            builder.HasData(new Banco { Id = 13, Codigo = "036", Nome = "Banco Bradesco BBI S.A." });
            builder.HasData(new Banco { Id = 14, Codigo = "204", Nome = "Banco Bradesco Cartões S.A." });
            builder.HasData(new Banco { Id = 15, Codigo = "394", Nome = "Banco Bradesco Financiamentos S.A." });
            builder.HasData(new Banco { Id = 16, Codigo = "237", Nome = "Banco Bradesco S.A." });
            builder.HasData(new Banco { Id = 17, Codigo = "218", Nome = "Banco BS2 S.A." });
            builder.HasData(new Banco { Id = 18, Codigo = "208", Nome = "Banco BTG Pactual S.A." });
            builder.HasData(new Banco { Id = 19, Codigo = "626", Nome = "Banco C6 Consignado S.A." });
            builder.HasData(new Banco { Id = 21, Codigo = "473", Nome = "Banco Caixa Geral - Brasil S.A." });
            builder.HasData(new Banco { Id = 22, Codigo = "040", Nome = "Banco Cargill S.A." });
            builder.HasData(new Banco { Id = 24, Codigo = "739", Nome = "Banco Cetelem S.A." });
            builder.HasData(new Banco { Id = 25, Codigo = "233", Nome = "Banco Cifra S.A." });
            builder.HasData(new Banco { Id = 26, Codigo = "745", Nome = "Banco Citibank S.A." });
            builder.HasData(new Banco { Id = 28, Codigo = "756", Nome = "Banco Cooperativo do Brasil S.A. - BANCOOB" });
            builder.HasData(new Banco { Id = 29, Codigo = "748", Nome = "Banco Cooperativo Sicredi S.A." });
            builder.HasData(new Banco { Id = 30, Codigo = "222", Nome = "Banco Credit Agricole Brasil S.A." });
            builder.HasData(new Banco { Id = 31, Codigo = "505", Nome = "Banco Credit Suisse (Brasil) S.A." });
            builder.HasData(new Banco { Id = 33, Codigo = "003", Nome = "Banco da Amazônia S.A." });
            builder.HasData(new Banco { Id = 34, Codigo = "083", Nome = "Banco da China Brasil S.A." });
            builder.HasData(new Banco { Id = 35, Codigo = "707", Nome = "Banco Daycoval S.A." });
            builder.HasData(new Banco { Id = 37, Codigo = "654", Nome = "Banco Digimais S.A." });
            builder.HasData(new Banco { Id = 39, Codigo = "001", Nome = "Banco do Brasil S.A." });
            builder.HasData(new Banco { Id = 40, Codigo = "047", Nome = "Banco do Estado de Sergipe S.A." });
            builder.HasData(new Banco { Id = 41, Codigo = "037", Nome = "Banco do Estado do Pará S.A." });
            builder.HasData(new Banco { Id = 42, Codigo = "041", Nome = "Banco do Estado do Rio Grande do Sul S.A." });
            builder.HasData(new Banco { Id = 43, Codigo = "004", Nome = "Banco do Nordeste do Brasil S.A." });
            builder.HasData(new Banco { Id = 44, Codigo = "224", Nome = "Banco Fibra S.A." });
            builder.HasData(new Banco { Id = 46, Codigo = "094", Nome = "Banco Finaxis S.A." });
            builder.HasData(new Banco { Id = 49, Codigo = "612", Nome = "Banco Guanabara S.A." });
            builder.HasData(new Banco { Id = 52, Codigo = "012", Nome = "Banco Inbursa S.A." });
            builder.HasData(new Banco { Id = 53, Codigo = "604", Nome = "Banco Industrial do Brasil S.A." });
            builder.HasData(new Banco { Id = 54, Codigo = "653", Nome = "Banco Indusval S.A." });
            builder.HasData(new Banco { Id = 55, Codigo = "077", Nome = "Banco Inter S.A." });
            builder.HasData(new Banco { Id = 56, Codigo = "249", Nome = "Banco Investcred Unibanco S.A." });
            builder.HasData(new Banco { Id = 57, Codigo = "184", Nome = "Banco Itaú BBA S.A." });
            builder.HasData(new Banco { Id = 58, Codigo = "029", Nome = "Banco Itaú Consignado S.A." });
            builder.HasData(new Banco { Id = 60, Codigo = "479", Nome = "Banco ItauBank S.A" });
            builder.HasData(new Banco { Id = 63, Codigo = "376", Nome = "Banco J. P. Morgan S.A." });
            builder.HasData(new Banco { Id = 64, Codigo = "074", Nome = "Banco J. Safra S.A." });
            builder.HasData(new Banco { Id = 65, Codigo = "217", Nome = "Banco John Deere S.A." });
            builder.HasData(new Banco { Id = 66, Codigo = "600", Nome = "Banco Luso Brasileiro S.A." });
            builder.HasData(new Banco { Id = 67, Codigo = "243", Nome = "Banco Máxima S.A." });
            builder.HasData(new Banco { Id = 68, Codigo = "389", Nome = "Banco Mercantil do Brasil S.A." });
            builder.HasData(new Banco { Id = 69, Codigo = "370", Nome = "Banco Mizuho do Brasil S.A." });
            builder.HasData(new Banco { Id = 70, Codigo = "746", Nome = "Banco Modal S.A." });
            builder.HasData(new Banco { Id = 71, Codigo = "456", Nome = "Banco MUFG Brasil S.A." });
            builder.HasData(new Banco { Id = 72, Codigo = "169", Nome = "Banco Olé Bonsucesso Consignado S.A." });
            builder.HasData(new Banco { Id = 73, Codigo = "212", Nome = "Banco Original S.A." });
            builder.HasData(new Banco { Id = 74, Codigo = "623", Nome = "Banco PAN S.A." });
            builder.HasData(new Banco { Id = 75, Codigo = "611", Nome = "Banco Paulista S.A." });
            builder.HasData(new Banco { Id = 76, Codigo = "643", Nome = "Banco Pine S.A." });
            builder.HasData(new Banco { Id = 77, Codigo = "747", Nome = "Banco Rabobank International Brasil S.A." });
            builder.HasData(new Banco { Id = 79, Codigo = "633", Nome = "Banco Rendimento S.A." });
            builder.HasData(new Banco { Id = 80, Codigo = "120", Nome = "Banco Rodobens S.A." });
            builder.HasData(new Banco { Id = 81, Codigo = "422", Nome = "Banco Safra S.A." });
            builder.HasData(new Banco { Id = 82, Codigo = "033", Nome = "Banco Santander  (Brasil)  S.A." });
            builder.HasData(new Banco { Id = 83, Codigo = "743", Nome = "Banco Semear S.A." });
            builder.HasData(new Banco { Id = 84, Codigo = "276", Nome = "Banco Senff S.A." });
            builder.HasData(new Banco { Id = 85, Codigo = "630", Nome = "Banco Smartbank S.A." });
            builder.HasData(new Banco { Id = 86, Codigo = "366", Nome = "Banco Société Générale Brasil S.A." });
            builder.HasData(new Banco { Id = 87, Codigo = "464", Nome = "Banco Sumitomo Mitsui Brasileiro S.A." });
            builder.HasData(new Banco { Id = 88, Codigo = "082", Nome = "Banco Topázio S.A." });
            builder.HasData(new Banco { Id = 90, Codigo = "634", Nome = "Banco Triângulo S.A." });
            builder.HasData(new Banco { Id = 92, Codigo = "655", Nome = "Banco Votorantim S.A." });
            builder.HasData(new Banco { Id = 93, Codigo = "610", Nome = "Banco VR S.A." });
            builder.HasData(new Banco { Id = 94, Codigo = "119", Nome = "Banco Western Union do Brasil S.A." });
            builder.HasData(new Banco { Id = 95, Codigo = "102", Nome = "Banco XP S.A." });
            builder.HasData(new Banco { Id = 97, Codigo = "021", Nome = "BANESTES S.A. Banco do Estado do Espírito Santo" });
            builder.HasData(new Banco { Id = 98, Codigo = "755", Nome = "Bank of America Merrill Lynch Banco Múltiplo S.A." });
            builder.HasData(new Banco { Id = 99, Codigo = "250", Nome = "BCV - Banco de Crédito e Varejo S.A." });
            builder.HasData(new Banco { Id = 100, Codigo = "144", Nome = "BEXS Banco de Câmbio S.A." });
            builder.HasData(new Banco { Id = 101, Codigo = "017", Nome = "BNY Mellon Banco S.A." });
            builder.HasData(new Banco { Id = 102, Codigo = "070", Nome = "BRB - Banco de Brasília S.A." });
            builder.HasData(new Banco { Id = 103, Codigo = "104", Nome = "Caixa Econômica Federal" });
            builder.HasData(new Banco { Id = 104, Codigo = "320", Nome = "China Construction Bank (Brasil) Banco Múltiplo S.A." });
            builder.HasData(new Banco { Id = 105, Codigo = "477", Nome = "Citibank N.A." });
            builder.HasData(new Banco { Id = 106, Codigo = "487", Nome = "Deutsche Bank S.A. - Banco Alemão" });
            builder.HasData(new Banco { Id = 107, Codigo = "064", Nome = "Goldman Sachs do Brasil Banco Múltiplo S.A." });
            builder.HasData(new Banco { Id = 108, Codigo = "062", Nome = "Hipercard Banco Múltiplo S.A." });
            builder.HasData(new Banco { Id = 109, Codigo = "269", Nome = "HSBC Brasil S.A. - Banco de Investimento" });
            builder.HasData(new Banco { Id = 110, Codigo = "492", Nome = "ING Bank N.V." });
            builder.HasData(new Banco { Id = 111, Codigo = "652", Nome = "Itaú Unibanco Holding S.A." });
            builder.HasData(new Banco { Id = 112, Codigo = "341", Nome = "Itaú Unibanco S.A." });
            builder.HasData(new Banco { Id = 113, Codigo = "488", Nome = "JPMorgan Chase Bank, National Association" });
            builder.HasData(new Banco { Id = 114, Codigo = "399", Nome = "Kirton Bank S.A. - Banco Múltiplo" });
            builder.HasData(new Banco { Id = 115, Codigo = "128", Nome = "MS Bank S.A. Banco de Câmbio" });
            builder.HasData(new Banco { Id = 116, Codigo = "254", Nome = "Paraná Banco S.A." });
            builder.HasData(new Banco { Id = 117, Codigo = "125", Nome = "Plural S.A. - Banco Múltiplo" });
            builder.HasData(new Banco { Id = 119, Codigo = "751", Nome = "Scotiabank Brasil S.A. Banco Múltiplo" });
            builder.HasData(new Banco { Id = 120, Codigo = "095", Nome = "Travelex Banco de Câmbio S.A." });
            builder.HasData(new Banco { Id = 121, Codigo = "129", Nome = "UBS Brasil Banco de Investimento S.A." });

            builder.ToTable("banco");
        }
    }
}
