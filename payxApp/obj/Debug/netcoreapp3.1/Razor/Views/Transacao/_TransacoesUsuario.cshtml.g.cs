#pragma checksum "D:\payxApp\payxApp\Views\Transacao\_TransacoesUsuario.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "e8faee9e85055f9e8baa620ba77562cbe07846f4"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Transacao__TransacoesUsuario), @"mvc.1.0.view", @"/Views/Transacao/_TransacoesUsuario.cshtml")]
namespace AspNetCore
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using Microsoft.AspNetCore.Mvc.ViewFeatures;
#nullable restore
#line 1 "D:\payxApp\payxApp\Views\_ViewImports.cshtml"
using PayxApp;

#line default
#line hidden
#nullable disable
#nullable restore
#line 1 "D:\payxApp\payxApp\Views\Transacao\_TransacoesUsuario.cshtml"
using PayxApp.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"e8faee9e85055f9e8baa620ba77562cbe07846f4", @"/Views/Transacao/_TransacoesUsuario.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"f8de7d06369424b89b56104b09c1cbe8ee57a5aa", @"/Views/_ViewImports.cshtml")]
    public class Views_Transacao__TransacoesUsuario : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<Transacao>>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-controller", "Transacao", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "VisualizarTransacao", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("btn btn-primary align-middle btn-sm"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("data-toggle", new global::Microsoft.AspNetCore.Html.HtmlString("tooltip"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_4 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("data-placement", new global::Microsoft.AspNetCore.Html.HtmlString("top"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_5 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("title", new global::Microsoft.AspNetCore.Html.HtmlString("Visualizar transação"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        #line hidden
        #pragma warning disable 0649
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperExecutionContext __tagHelperExecutionContext;
        #pragma warning restore 0649
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner __tagHelperRunner = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner();
        #pragma warning disable 0169
        private string __tagHelperStringValueBuffer;
        #pragma warning restore 0169
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager __backed__tagHelperScopeManager = null;
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager __tagHelperScopeManager
        {
            get
            {
                if (__backed__tagHelperScopeManager == null)
                {
                    __backed__tagHelperScopeManager = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager(StartTagHelperWritingScope, EndTagHelperWritingScope);
                }
                return __backed__tagHelperScopeManager;
            }
        }
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral(@"
<script src=""https://kit.fontawesome.com/a076d05399.js""></script>
<script>
    function AprovarTransacao(transacaoId) {
        $.post(""Transacao/AprovarTransacao"", { transacaoId: transacaoId }).done(function (data) {
            if (data) {
                $.get('Usuario/ListarTransacoes').done(function (data) {
                    $('#transacoes-usuario').html(data);
                    AbrirAlerta('Transação aprovada!');
                });
            }
            else {
                $.get('Usuario/ListarTransacoes').done(function (data) {
                    $('#transacoes-usuario').html(data);
                    AbrirAlerta('Não foi possível aprovar a transação!');
                });
            }
        }).fail(function () {
            $.get('Usuario/ListarTransacoes').done(function (data) {
                $('#transacoes-usuario').html(data);
                AbrirAlerta('Não foi possível aprovar a transação!');
            });
        });
    }

    //function Visuali");
            WriteLiteral(@"zarTransacao(transacaoId) {
    //    $.get(""Transacao/VisualizarTransacao"", { transacaoId: transacaoId });
    //}

    function ReprovarTransacao(transacaoId) {
        var modal = $('#modal-motivo');
        $('#input-transacaoId').val(transacaoId);
        modal.modal('toggle');
    }

    function ProcessarTransacao(transacaoId) {
        $.post(""Transacao/ProcessarTransacao"", { transacaoId: transacaoId }).done(function (data) {
            if (data) {
                $.get('Usuario/ListarTransacoes').done(function (data) {
                    $('#transacoes-usuario').html(data);
                    AbrirAlerta('Transação em processamento!');
                });
            }
            else {
                $.get('Usuario/ListarTransacoes').done(function (data) {
                    $('#transacoes-usuario').html(data);
                    AbrirAlerta('Não foi possível alterar a transação!');
                });
            }
        }).fail(function () {
            $.get('Usu");
            WriteLiteral(@"ario/ListarTransacoes').done(function (data) {
                $('#transacoes-usuario').html(data);
                AbrirAlerta('Não foi possível alterar a transação!');
            });
        });
    }

    function EstornarTransacao(transacaoId) {
        $.post(""Transacao/EstornarTransacao"", { transacaoId: transacaoId }).done(function (data) {
            $.get('Usuario/ListarTransacoes').done(function (data) {
                $('#transacoes-usuario').html(data);
                AbrirAlerta('Estorno realizado com sucesso!');
            });
        }).fail(function (error) {
            $.get('Usuario/ListarTransacoes').done(function (data) {
                $('#transacoes-usuario').html(data);
                AbrirAlerta('Falha ao realizar estorno!');
            });
        });
    }
</script>



<div class=""container my-5"">
    <h3>Minhas transações</h3>
    <div class=""table-responsive"">
        <table class=""table table-striped"">
            <thead>
                <tr>
");
            WriteLiteral(@"                    <th scope=""col"">Código</th>
                    <th scope=""col"">Data</th>
                    <th scope=""col"">Valor R$</th>
                    <th scope=""col"">Parcelamento</th>
                    <th scope=""col"">Valor pago</th>
                    <th scope=""col"">Status</th>
                    <th scope=""col"">Ações</th>
                </tr>
            </thead>
            <tbody>

");
#nullable restore
#line 94 "D:\payxApp\payxApp\Views\Transacao\_TransacoesUsuario.cshtml"
                 foreach (Transacao transacao in Model)
                {

#line default
#line hidden
#nullable disable
            WriteLiteral("                    <tr>\r\n                        <td>");
#nullable restore
#line 97 "D:\payxApp\payxApp\Views\Transacao\_TransacoesUsuario.cshtml"
                       Write(transacao.Id);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                        <td>");
#nullable restore
#line 98 "D:\payxApp\payxApp\Views\Transacao\_TransacoesUsuario.cshtml"
                       Write(transacao.DataTransacao.ToShortDateString());

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                        <td>");
#nullable restore
#line 99 "D:\payxApp\payxApp\Views\Transacao\_TransacoesUsuario.cshtml"
                       Write(transacao.ValorTransacao.ToString("N2"));

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                        <td>");
#nullable restore
#line 100 "D:\payxApp\payxApp\Views\Transacao\_TransacoesUsuario.cshtml"
                       Write(transacao.Parcelamento);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                        <td>");
#nullable restore
#line 101 "D:\payxApp\payxApp\Views\Transacao\_TransacoesUsuario.cshtml"
                       Write(transacao.ValorFinalTransacao.ToString("N2"));

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n");
#nullable restore
#line 102 "D:\payxApp\payxApp\Views\Transacao\_TransacoesUsuario.cshtml"
                         if (transacao.StatusTransacao == StatusTransacao.EM_ABERTO)
                        {

#line default
#line hidden
#nullable disable
            WriteLiteral("                            <td><span class=\"badge badge-amarelo\">Analisando</span></td>\r\n");
#nullable restore
#line 105 "D:\payxApp\payxApp\Views\Transacao\_TransacoesUsuario.cshtml"
                        }
                        else if (transacao.StatusTransacao == StatusTransacao.EM_PROCESSAMENTO)
                        {

#line default
#line hidden
#nullable disable
            WriteLiteral("                            <td><span class=\"badge badge-amarelo\">Processando</span></td>\r\n");
#nullable restore
#line 109 "D:\payxApp\payxApp\Views\Transacao\_TransacoesUsuario.cshtml"
                        }
                        else if (transacao.StatusTransacao == StatusTransacao.APROVADA)
                        {

#line default
#line hidden
#nullable disable
            WriteLiteral("                            <td><span class=\"badge badge-verde\">Aprovada</span></td>\r\n");
#nullable restore
#line 113 "D:\payxApp\payxApp\Views\Transacao\_TransacoesUsuario.cshtml"
                        }
                        else if (transacao.StatusTransacao == StatusTransacao.REJEITADA)
                        {

#line default
#line hidden
#nullable disable
            WriteLiteral("                            <td><span class=\"badge badge-vermelho\">Rejeitada</span></td>\r\n");
#nullable restore
#line 117 "D:\payxApp\payxApp\Views\Transacao\_TransacoesUsuario.cshtml"
                        }
                        else if (transacao.StatusTransacao == StatusTransacao.PEDIDO_CANCELAMENTO)
                        {

#line default
#line hidden
#nullable disable
            WriteLiteral("                            <td><span class=\"badge badge-amarelo\">Análise de canc.</span></td>\r\n");
#nullable restore
#line 121 "D:\payxApp\payxApp\Views\Transacao\_TransacoesUsuario.cshtml"
                        }
                        else if (transacao.StatusTransacao == StatusTransacao.ESTORNO_PARCIAL_APROVADO)
                        {

#line default
#line hidden
#nullable disable
            WriteLiteral("                            <td><span class=\"badge badge-amarelo\">Estorno parcial</span></td>\r\n");
#nullable restore
#line 125 "D:\payxApp\payxApp\Views\Transacao\_TransacoesUsuario.cshtml"
                        }
                        else if (transacao.StatusTransacao == StatusTransacao.ESTORNO_APROVADO)
                        {

#line default
#line hidden
#nullable disable
            WriteLiteral("                            <td><span class=\"badge badge-vermelho\">Estornada</span></td>\r\n");
#nullable restore
#line 129 "D:\payxApp\payxApp\Views\Transacao\_TransacoesUsuario.cshtml"
                        }
                        else if (transacao.StatusTransacao == StatusTransacao.ESTORNO_REJEITADO)
                        {

#line default
#line hidden
#nullable disable
            WriteLiteral("                            <td><span class=\"badge badge-verde\">Aprovada (estorno rejeitado)</span></td>\r\n");
#nullable restore
#line 133 "D:\payxApp\payxApp\Views\Transacao\_TransacoesUsuario.cshtml"
                        }

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                        <td>\r\n                            ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "e8faee9e85055f9e8baa620ba77562cbe07846f414002", async() => {
                WriteLiteral(@"
                                <svg xmlns=""http://www.w3.org/2000/svg"" width=""16"" height=""16"" fill=""currentColor"" class=""bi bi-eye align-middle"" viewBox=""0 0 16 16"">
                                    <path d=""M16 8s-3-5.5-8-5.5S0 8 0 8s3 5.5 8 5.5S16 8 16 8zM1.173 8a13.133 13.133 0 0 1 1.66-2.043C4.12 4.668 5.88 3.5 8 3.5c2.12 0 3.879 1.168 5.168 2.457A13.133 13.133 0 0 1 14.828 8c-.058.087-.122.183-.195.288-.335.48-.83 1.12-1.465 1.755C11.879 11.332 10.119 12.5 8 12.5c-2.12 0-3.879-1.168-5.168-2.457A13.134 13.134 0 0 1 1.172 8z"" />
                                    <path d=""M8 5.5a2.5 2.5 0 1 0 0 5 2.5 2.5 0 0 0 0-5zM4.5 8a3.5 3.5 0 1 1 7 0 3.5 3.5 0 0 1-7 0z"" />
                                </svg>
                            ");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Controller = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-id", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#nullable restore
#line 136 "D:\payxApp\payxApp\Views\Transacao\_TransacoesUsuario.cshtml"
                                                                                             WriteLiteral(transacao.Id);

#line default
#line hidden
#nullable disable
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-id", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_2);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_3);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_4);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_5);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n                            <a");
            BeginWriteAttribute("onclick", " onclick=\"", 6981, "\"", 7023, 3);
            WriteAttributeValue("", 6991, "EstornarTransacao(", 6991, 18, true);
#nullable restore
#line 142 "D:\payxApp\payxApp\Views\Transacao\_TransacoesUsuario.cshtml"
WriteAttributeValue("", 7009, transacao.Id, 7009, 13, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue("", 7022, ")", 7022, 1, true);
            EndWriteAttribute();
            WriteLiteral(@" class=""btn badge-roxo align-middle btn-sm"" data-toggle=""tooltip"" data-placement=""top"" title=""Solicitar estorno"">
                                <svg xmlns=""http://www.w3.org/2000/svg"" width=""16"" height=""16"" fill=""currentColor"" class=""bi bi-file-arrow-down align-middle"" viewBox=""0 0 16 16"">
                                    <path d=""M8 5a.5.5 0 0 1 .5.5v3.793l1.146-1.147a.5.5 0 0 1 .708.708l-2 2a.5.5 0 0 1-.708 0l-2-2a.5.5 0 1 1 .708-.708L7.5 9.293V5.5A.5.5 0 0 1 8 5z"" />
                                    <path d=""M4 0a2 2 0 0 0-2 2v12a2 2 0 0 0 2 2h8a2 2 0 0 0 2-2V2a2 2 0 0 0-2-2H4zm0 1h8a1 1 0 0 1 1 1v12a1 1 0 0 1-1 1H4a1 1 0 0 1-1-1V2a1 1 0 0 1 1-1z"" />
                                </svg>
                            </a>
                            <a");
            BeginWriteAttribute("onclick", " onclick=\"", 7802, "\"", 7843, 3);
            WriteAttributeValue("", 7812, "AprovarTransacao(", 7812, 17, true);
#nullable restore
#line 148 "D:\payxApp\payxApp\Views\Transacao\_TransacoesUsuario.cshtml"
WriteAttributeValue("", 7829, transacao.Id, 7829, 13, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue("", 7842, ")", 7842, 1, true);
            EndWriteAttribute();
            WriteLiteral(@" class=""btn badge-verde align-middle btn-sm"" data-toggle=""tooltip"" data-placement=""top"" title=""Aprovar transação"">
                                <svg xmlns=""http://www.w3.org/2000/svg"" width=""16"" height=""16"" fill=""currentColor"" class=""bi bi-check2 align-middle"" viewBox=""0 0 16 16"">
                                    <path d=""M13.854 3.646a.5.5 0 0 1 0 .708l-7 7a.5.5 0 0 1-.708 0l-3.5-3.5a.5.5 0 1 1 .708-.708L6.5 10.293l6.646-6.647a.5.5 0 0 1 .708 0z"" />
                                </svg>
                            </a>
                            <a");
            BeginWriteAttribute("onclick", " onclick=\"", 8412, "\"", 8454, 3);
            WriteAttributeValue("", 8422, "ReprovarTransacao(", 8422, 18, true);
#nullable restore
#line 153 "D:\payxApp\payxApp\Views\Transacao\_TransacoesUsuario.cshtml"
WriteAttributeValue("", 8440, transacao.Id, 8440, 13, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue("", 8453, ")", 8453, 1, true);
            EndWriteAttribute();
            WriteLiteral(@" class=""btn btn-danger align-middle btn-sm"" data-toggle=""tooltip"" data-placement=""top"" title=""Reprovar transação"">
                                <svg xmlns=""http://www.w3.org/2000/svg"" width=""16"" height=""16"" fill=""currentColor"" class=""bi bi-x align-middle"" viewBox=""0 0 16 16"">
                                    <path d=""M4.646 4.646a.5.5 0 0 1 .708 0L8 7.293l2.646-2.647a.5.5 0 0 1 .708.708L8.707 8l2.647 2.646a.5.5 0 0 1-.708.708L8 8.707l-2.646 2.647a.5.5 0 0 1-.708-.708L7.293 8 4.646 5.354a.5.5 0 0 1 0-.708z"" />
                                </svg>
                            </a>
                            <a");
            BeginWriteAttribute("onclick", " onclick=\"", 9083, "\"", 9126, 3);
            WriteAttributeValue("", 9093, "ProcessarTransacao(", 9093, 19, true);
#nullable restore
#line 158 "D:\payxApp\payxApp\Views\Transacao\_TransacoesUsuario.cshtml"
WriteAttributeValue("", 9112, transacao.Id, 9112, 13, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue("", 9125, ")", 9125, 1, true);
            EndWriteAttribute();
            WriteLiteral(@" class=""btn badge-amarelo align-middle btn-sm"" data-toggle=""tooltip"" data-placement=""top"" title=""Processar transação"">
                                <svg xmlns=""http://www.w3.org/2000/svg"" width=""16"" height=""16"" fill=""currentColor"" class=""bi bi-download"" viewBox=""0 0 16 16"">
                                    <path d=""M.5 9.9a.5.5 0 0 1 .5.5v2.5a1 1 0 0 0 1 1h12a1 1 0 0 0 1-1v-2.5a.5.5 0 0 1 1 0v2.5a2 2 0 0 1-2 2H2a2 2 0 0 1-2-2v-2.5a.5.5 0 0 1 .5-.5z"" />
                                    <path d=""M7.646 11.854a.5.5 0 0 0 .708 0l3-3a.5.5 0 0 0-.708-.708L8.5 10.293V1.5a.5.5 0 0 0-1 0v8.793L5.354 8.146a.5.5 0 1 0-.708.708l3 3z"" />
                                </svg>
                            </a>
                        </td>
                    </tr>
");
#nullable restore
#line 166 "D:\payxApp\payxApp\Views\Transacao\_TransacoesUsuario.cshtml"
                }

#line default
#line hidden
#nullable disable
            WriteLiteral(@"            </tbody>
        </table>
    </div>
</div>

<a class=""btn badge-roxo align-middle btn-sm"" data-toggle=""modal""
   href=""#boleto-modal"">Clique aqui</a>
<br>

<!-- Modal -->
<div id=""modal-motivo"" class=""modal fade"">
    <div class=""modal-dialog modal-lg modal-dialog-centered"">
        <div class=""modal-content"">
            <div class=""p-5 pb-0"">
                <div class=""row"">
                    <div class=""col-12"">
                        <h2 class=""text-uppercase"" style=""text-align: center;"">Motivo da reprovação</h2>
                    </div>
                    <div class=""container"">
                        <textarea id=""MotivoReprovacao"" class=""w-100 h-100"" rows=""10""></textarea>
                        <input type=""hidden"" id=""input-transacaoId"" />
                    </div>
                </div>
            </div>
            <div class=""modal-body justify-content-center"">
                <div class=""row justify-content-center"">
                    <div class=""");
            WriteLiteral(@"col-3"">
                        <button class=""btn btn-primary"" type=""button"" data-dismiss=""modal"" id=""botao-modal-confirmar"">
                            <svg xmlns=""http://www.w3.org/2000/svg"" width=""16"" height=""16"" fill=""currentColor"" class=""bi bi-check"" viewBox=""0 0 16 16"">
                                <path d=""M10.97 4.97a.75.75 0 0 1 1.07 1.05l-3.99 4.99a.75.75 0 0 1-1.08.02L4.324 8.384a.75.75 0 1 1 1.06-1.06l2.094 2.093 3.473-4.425a.267.267 0 0 1 .02-.022z"" />
                            </svg>
                            Confirmar
                        </button>
                    </div>
                </div>
            </div>
        </div>
    </div>
</div>

<script>
    $('#botao-modal-confirmar').unbind().click(function () {
        $('.modal-backdrop')[0].classList.remove('show');
        var motivoRejeicao = $('#MotivoReprovacao').val();
        var transacaoId = $('#input-transacaoId').val();

        if (motivoRejeicao && motivoRejeicao.length > 15) {
            $");
            WriteLiteral(@".post(""Transacao/ReprovarTransacao"", { transacaoId: transacaoId, motivoReprovacao: motivoRejeicao }).done(function (data) {
                if (data) {
                    $.get('Usuario/ListarTransacoes').done(function (data) {
                        $('#transacoes-usuario').html(data);
                        AbrirAlerta('Transação reprovada!');
                    });
                } else {
                    modal.modal('toggle');
                    $.get('Usuario/ListarTransacoes').done(function (data) {
                        $('#transacoes-usuario').html(data);
                        AbrirAlerta('Falha na reprovação!');
                    });
                }
            }).fail(function () {
                $.get('Usuario/ListarTransacoes').done(function (data) {
                    $('#transacoes-usuario').html(data);
                    AbrirAlerta('Falha na reprovação!');
                });
            });
        }
        else {
            AbrirAlerta('Digite mais ");
            WriteLiteral("de 15 caracteres!\');\r\n        }\r\n    });\r\n</script>\r\n");
        }
        #pragma warning restore 1998
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<Transacao>> Html { get; private set; }
    }
}
#pragma warning restore 1591