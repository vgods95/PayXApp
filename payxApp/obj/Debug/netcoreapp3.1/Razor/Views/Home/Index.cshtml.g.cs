#pragma checksum "D:\payxApp\payxApp\Views\Home\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "daca4848877a2969c8bcc98b6af1e06a7ff03df1"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Home_Index), @"mvc.1.0.view", @"/Views/Home/Index.cshtml")]
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
#line 2 "D:\payxApp\payxApp\Views\_ViewImports.cshtml"
using PayxApp.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"daca4848877a2969c8bcc98b6af1e06a7ff03df1", @"/Views/Home/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"f8de7d06369424b89b56104b09c1cbe8ee57a5aa", @"/Views/_ViewImports.cshtml")]
    public class Views_Home_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("nav-link js-scroll-trigger"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-controller", "Usuario", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Registro", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Login", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_4 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("btn btn-primary btn-xl text-uppercase js-scroll-trigger"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_5 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("name", "..\\Simulacao\\_Simulacao", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_6 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("name", "_Contato", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_7 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("id", new global::Microsoft.AspNetCore.Html.HtmlString("page-top"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.HeadTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_HeadTagHelper;
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.BodyTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_BodyTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.PartialTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_PartialTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 1 "D:\payxApp\payxApp\Views\Home\Index.cshtml"
  
    Layout = null;

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<!DOCTYPE html>\r\n<html lang=\"pt-br\">\r\n\r\n");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("head", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "daca4848877a2969c8bcc98b6af1e06a7ff03df16185", async() => {
                WriteLiteral(@"
    <meta charset=""utf-8"" />
    <meta name=""viewport"" content=""width=device-width, initial-scale=1, shrink-to-fit=no"" />
    <title>payX</title>
    <link rel='shortcut icon' type='image/x-icon' href='../assets/img/favicon.ico' />
    <!-- Font Awesome icons (free version)-->
    <script src=""https://use.fontawesome.com/releases/v5.15.1/js/all.js"" crossorigin=""anonymous""></script>
    <!-- Google fonts-->
    <link href=""https://fonts.googleapis.com/css?family=Montserrat:400,700"" rel=""stylesheet"" type=""text/css"" />
    <link href=""https://fonts.googleapis.com/css?family=Droid+Serif:400,700,400italic,700italic"" rel=""stylesheet""
          type=""text/css"" />
    <link href=""https://fonts.googleapis.com/css?family=Roboto+Slab:400,100,300,700"" rel=""stylesheet"" type=""text/css"" />
    <!-- Core theme CSS (includes Bootstrap)-->
    <link href=""css/styles.css"" rel=""stylesheet"" />
    <!-- jQuery -->
    <script src=""js/jquery-3.6.0.min.js""></script>
");
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_HeadTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.HeadTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_HeadTagHelper);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n\r\n");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("body", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "daca4848877a2969c8bcc98b6af1e06a7ff03df18160", async() => {
                WriteLiteral("\r\n    <div hidden id=\"viewdata\">\r\n        ");
#nullable restore
#line 28 "D:\payxApp\payxApp\Views\Home\Index.cshtml"
   Write(ViewData["Envio"]);

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n        ");
#nullable restore
#line 29 "D:\payxApp\payxApp\Views\Home\Index.cshtml"
   Write(ViewBag.Message);

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n");
#nullable restore
#line 30 "D:\payxApp\payxApp\Views\Home\Index.cshtml"
          
            if (TempData["Atualizacao"] != null)
                TempData["Atualizacao"].ToString();
        

#line default
#line hidden
#nullable disable
                WriteLiteral(@"    </div>
    <!-- Navega????o -->
    <nav class=""navbar navbar-expand-lg navbar-dark fixed-top"" id=""mainNav"">
        <div class=""container"">
            <a class=""navbar-brand js-scroll-trigger"" href=""#page-top"">
                <img src=""assets/img/navbar-logo.png""
                     alt=""Logotipo payx"" />
            </a>
            <button class=""navbar-toggler navbar-toggler-right"" type=""button"" data-toggle=""collapse""
                    data-target=""#navbarResponsive"" aria-controls=""navbarResponsive"" aria-expanded=""false""
                    aria-label=""Toggle navigation"">
                Menu
                <i class=""fas fa-bars ml-1""></i>
            </button>
            <div class=""collapse navbar-collapse"" id=""navbarResponsive"">
                <ul class=""navbar-nav text-uppercase ml-auto"">
                    <li class=""nav-item""><a class=""nav-link js-scroll-trigger"" href=""#services"">Servi??os</a></li>
                    <li class=""nav-item""><a class=""nav-link js-scroll-trigg");
                WriteLiteral(@"er"" href=""#portfolio"">Simula????o</a></li>
                    <li class=""nav-item""><a class=""nav-link js-scroll-trigger"" href=""#about"">Como funciona?</a></li>
                    <li class=""nav-item""><a class=""nav-link js-scroll-trigger"" href=""#team"">Equipe</a></li>
                    <li class=""nav-item""><a class=""nav-link js-scroll-trigger"" href=""#contact"">Contato</a></li>
                    <li class=""nav-item"">");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "daca4848877a2969c8bcc98b6af1e06a7ff03df110690", async() => {
                    WriteLiteral("Registrar-se");
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
                __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Controller = (string)__tagHelperAttribute_1.Value;
                __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
                __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_2.Value;
                __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_2);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral("</li>\r\n                    <li class=\"nav-item\">");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "daca4848877a2969c8bcc98b6af1e06a7ff03df112265", async() => {
                    WriteLiteral("Login");
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
                __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Controller = (string)__tagHelperAttribute_1.Value;
                __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
                __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_3.Value;
                __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_3);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral(@"</li>
                </ul>
            </div>
        </div>
    </nav>
    <!-- Cabe??alho -->
    <header class=""masthead"">
        <div class=""container"">
            <div class=""masthead-heading"">N??s somos a payX</div>
            <div class=""masthead-subheading"">
                Pague boletos ou fa??a transfer??ncias com seu cart??o de cr??dito parcelado em
                at?? 12x
            </div>
            ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "daca4848877a2969c8bcc98b6af1e06a7ff03df114219", async() => {
                    WriteLiteral("Crie uma conta");
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_4);
                __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Controller = (string)__tagHelperAttribute_1.Value;
                __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
                __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_2.Value;
                __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_2);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral(@"
        </div>
    </header>
    <!-- Servi??os -->
    <section class=""page-section"" id=""services"">
        <div class=""container"">
            <div class=""text-center"">
                <h2 class=""section-heading text-uppercase"">Servi??os</h2>
                <h3 class=""section-subheading text-muted"">Lorem ipsum dolor sit amet consectetur.</h3>
            </div>
            <div class=""row text-center"">
                <div class=""col-md-4"">
                    <span class=""fa-stack fa-4x"">
                        <i class=""fas fa-circle fa-stack-2x text-primary""></i>
                        <i class=""fas fa-file-invoice-dollar fa-stack-1x fa-inverse""></i>
                    </span>
                    <h4 class=""my-3"">Boletos</h4>
                    <p class=""text-muted"">
                        Pague seus boletos usando o cart??o de cr??dito. Voc?? pode parcelar em at?? 12x o
                        pagamento de v??rias contas (faturas, multas, IPTU, IPVA, contas telef??nicas, etc).
       ");
                WriteLiteral(@"                 Veja as regras para o pagamento de boletos <a class=""portfolio-link"" data-toggle=""modal""
                                                                      href=""#boleto-modal"">clicando aqui</a>.<br>
                        Prazo para pagamento: 2 dias ??teis ap??s a aprova????o.
                    </p>
                </div>
                <div class=""col-md-4"">
                    <span class=""fa-stack fa-4x"">
                        <i class=""fas fa-circle fa-stack-2x text-primary""></i>
                        <i class=""fas fa-hand-holding-usd fa-stack-1x fa-inverse""></i>
                    </span>
                    <h4 class=""my-3"">Transfer??ncias</h4>
                    <p class=""text-muted"">
                        Voc?? pode transferir at?? R$x,xx para qualquer titularidade e pagar a
                        transfer??ncia em at?? 12x usando seu cart??o de cr??dito. Ap??s enviar seu pedido, seus dados ser??o
                        analisados, e assim que aprovado a transfer??n");
                WriteLiteral(@"cia ser?? agendada.
                        Veja as regras para transfer??ncias <a class=""portfolio-link"" data-toggle=""modal""
                                                              href=""#transferencia-modal"">clicando aqui</a>.<br>
                        Prazo para pagamento: 2 dias ??teis ap??s a aprova????o.
                    </p>
                </div>
                <div class=""col-md-4"">
                    <span class=""fa-stack fa-4x"">
                        <i class=""fas fa-circle fa-stack-2x text-primary""></i>
                        <i class=""fas fa-lock fa-stack-1x fa-inverse""></i>
                    </span>
                    <h4 class=""my-3"">Seguran??a</h4>
                    <p class=""text-muted"">
                        Lorem ipsum dolor sit amet, consectetur adipisicing elit. Minima maxime quam
                        architecto quo inventore harum ex magni, dicta impedit.
                    </p>
                </div>
            </div>
        </div>
    </section>");
                WriteLiteral("\r\n    <!-- Simula????o -->\r\n    <section class=\"page-section bg-light\" id=\"portfolio\">\r\n        ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("partial", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "daca4848877a2969c8bcc98b6af1e06a7ff03df119090", async() => {
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_PartialTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.PartialTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_PartialTagHelper);
                __Microsoft_AspNetCore_Mvc_TagHelpers_PartialTagHelper.Name = (string)__tagHelperAttribute_5.Value;
                __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_5);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral(@"
    </section>
    <!-- Como funciona? -->
    <section class=""page-section"" id=""about"">
        <div class=""container"">
            <div class=""text-center"">
                <h2 class=""section-heading text-uppercase"">Como funciona?</h2>
                <h3 class=""section-subheading text-muted"">Lorem ipsum dolor sit amet consectetur.</h3>
            </div>
            <ul class=""timeline"">
                <li>
                    <div class=""timeline-image"">
                        <img class=""rounded-circle img-fluid"" src=""assets/img/about/3.jpg""");
                BeginWriteAttribute("alt", "\r\n                             alt=\"", 7317, "\"", 7353, 0);
                EndWriteAttribute();
                WriteLiteral(@" />
                    </div>
                    <div class=""timeline-panel"">
                        <div class=""timeline-heading"">
                            <h4>Qual servi??o procuro?</h4>
                        </div>
                        <div class=""timeline-body"">
                            <p class=""text-muted"">
                                Oferecemos uma forma mais conveniente e f??cil na hora de se entender
                                com as suas contas: o pagamento parcelado dos seus boletos atrav??s do limite do seu
                                cart??o de cr??dito!
                                E n??o para por a??: transfira dinheiro com seu cart??o de cr??dito e tamb??m parcele em at??
                                12x
                            </p>
                        </div>
                    </div>
                </li>
                <li class=""timeline-inverted"">
                    <div class=""timeline-image"">
                        <img class=""rounded-");
                WriteLiteral("circle img-fluid\" src=\"assets/img/about/2.jpg\"");
                BeginWriteAttribute("alt", "\r\n                             alt=\"", 8424, "\"", 8460, 0);
                EndWriteAttribute();
                WriteLiteral(@" />
                    </div>
                    <div class=""timeline-panel"">
                        <div class=""timeline-heading"">
                            <h4>O que eu preciso?</h4>
                        </div>
                        <div class=""timeline-body"">
                            <p class=""text-muted"">
                                Voc?? s?? precisa ter limite dispon??vel no seu cart??o, al??m dos
                                documentos necess??rios para aprova????o que ser??o solicitados durante o pedido.
                            </p>
                        </div>
                    </div>
                </li>
                <li>
                    <div class=""timeline-image"">
                        <img class=""rounded-circle img-fluid"" src=""assets/img/about/1.jpg""");
                BeginWriteAttribute("alt", "\r\n                             alt=\"", 9278, "\"", 9314, 0);
                EndWriteAttribute();
                WriteLiteral(@" />
                    </div>
                    <div class=""timeline-panel"">
                        <div class=""timeline-heading"">
                            <h4>Pra quem ?? indicado?</h4>
                        </div>
                        <div class=""timeline-body"">
                            <p class=""text-muted"">
                                Pessoas que possuem limite dispon??vel no cart??o de cr??dito e desejam
                                pagar boletos ou transferir em at?? 12x.
                            </p>
                        </div>
                    </div>
                </li>
                <li class=""timeline-inverted"">
                    <div class=""timeline-image"">
                        <img class=""rounded-circle img-fluid"" src=""assets/img/about/4.jpg""");
                BeginWriteAttribute("alt", "\r\n                             alt=\"", 10130, "\"", 10166, 0);
                EndWriteAttribute();
                WriteLiteral(@" />
                    </div>
                    <div class=""timeline-panel"">
                        <div class=""timeline-heading"">
                            <h4>Crie sua conta</h4>
                        </div>
                        <div class=""timeline-body"">
                            <p class=""text-muted"">
                                Deixe a payX contribuir de forma r??pida e segura para que voc?? possa
                                se organizar de maneira eficaz.
                                Nossa miss??o ?? ajud??-lo em momentos dif??ceis!
                            </p>
                        </div>
                    </div>
                </li>
                <li class=""timeline-inverted"">
                    <div class=""timeline-image"">
                        <h4>
                            Deixe-nos
                            <br />
                            fazer parte da
                            <br />
                            sua hist??ria!
      ");
                WriteLiteral(@"                  </h4>
                    </div>
                </li>
            </ul>
        </div>
    </section>
    <!-- Equipe -->
    <section class=""page-section bg-light"" id=""team"">
        <div class=""container"">
            <div class=""text-center"">
                <h2 class=""section-heading text-uppercase"">Nossa equipe</h2>
                <h3 class=""section-subheading text-muted"">Lorem ipsum dolor sit amet consectetur.</h3>
            </div>
            <div class=""row"">
                <div class=""col-lg-6"">
                    <div class=""team-member"">
                        <img class=""mx-auto rounded-circle"" src=""assets/img/team/raphael-profile.jpg""
                             alt=""Cofundador e diretor comercial Raphael Lorenzo Bernini"" />
                        <h4>Raphael Lorenzo Bernini</h4>
                        <p class=""text-muted"">Diretor comercial</p>
                        <a class=""btn btn-dark btn-social mx-2"" href=""#!""><i class=""fab fa-twitter""></i><");
                WriteLiteral(@"/a>
                        <a class=""btn btn-dark btn-social mx-2"" href=""#!""><i class=""fab fa-facebook-f""></i></a>
                        <a class=""btn btn-dark btn-social mx-2"" href=""#!""><i class=""fab fa-linkedin-in""></i></a>
                    </div>
                </div>
                <div class=""col-lg-6"">
                    <div class=""team-member"">
                        <img class=""mx-auto rounded-circle"" src=""assets/img/team/vinicius-profile.jpg""
                             alt=""Cofundador e diretor t??cnico Vin??cius Godoy Ferreira"" />
                        <h4>Vin??cius Godoy Ferreira</h4>
                        <p class=""text-muted"">Diretor t??cnico</p>
                        <a class=""btn btn-dark btn-social mx-2"" href=""#!""><i class=""fab fa-twitter""></i></a>
                        <a class=""btn btn-dark btn-social mx-2"" href=""#!""><i class=""fab fa-facebook-f""></i></a>
                        <a class=""btn btn-dark btn-social mx-2"" href=""#!""><i class=""fab fa-linkedin-in""></i><");
                WriteLiteral(@"/a>
                    </div>
                </div>
            </div>
            <div class=""row"">
                <div class=""col-lg-8 mx-auto text-center"">
                    <p class=""large text-muted"">
                        Lorem ipsum dolor sit amet, consectetur adipisicing elit. Aut eaque,
                        laboriosam veritatis, quos non quis ad perspiciatis, totam corporis ea, alias ut unde.
                    </p>
                </div>
            </div>
        </div>
    </section>
    <!-- Clientes-->
    <div class=""py-5"">
        <div class=""container"">
            <div class=""row"">
                <div class=""col-md-3 col-sm-6 my-3"">
                    <a href=""#!""><img class=""img-fluid d-block mx-auto"" src=""assets/img/logos/envato.jpg""");
                BeginWriteAttribute("alt", " alt=\"", 14034, "\"", 14040, 0);
                EndWriteAttribute();
                WriteLiteral(" /></a>\r\n                </div>\r\n                <div class=\"col-md-3 col-sm-6 my-3\">\r\n                    <a href=\"#!\">\r\n                        <img class=\"img-fluid d-block mx-auto\" src=\"assets/img/logos/designmodo.jpg\"");
                BeginWriteAttribute("alt", "\r\n                             alt=\"", 14263, "\"", 14299, 0);
                EndWriteAttribute();
                WriteLiteral(" />\r\n                    </a>\r\n                </div>\r\n                <div class=\"col-md-3 col-sm-6 my-3\">\r\n                    <a href=\"#!\">\r\n                        <img class=\"img-fluid d-block mx-auto\" src=\"assets/img/logos/themeforest.jpg\"");
                BeginWriteAttribute("alt", "\r\n                             alt=\"", 14545, "\"", 14581, 0);
                EndWriteAttribute();
                WriteLiteral(" />\r\n                    </a>\r\n                </div>\r\n                <div class=\"col-md-3 col-sm-6 my-3\">\r\n                    <a href=\"#!\">\r\n                        <img class=\"img-fluid d-block mx-auto\" src=\"assets/img/logos/creative-market.jpg\"");
                BeginWriteAttribute("alt", "\r\n                             alt=\"", 14831, "\"", 14867, 0);
                EndWriteAttribute();
                WriteLiteral(" />\r\n                    </a>\r\n                </div>\r\n            </div>\r\n        </div>\r\n    </div>\r\n    <!-- Contato-->\r\n    <section class=\"page-section\" id=\"contact\">\r\n        ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("partial", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "daca4848877a2969c8bcc98b6af1e06a7ff03df130122", async() => {
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_PartialTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.PartialTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_PartialTagHelper);
                __Microsoft_AspNetCore_Mvc_TagHelpers_PartialTagHelper.Name = (string)__tagHelperAttribute_6.Value;
                __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_6);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral(@"
    </section>
    <!-- Rodap?? -->
    <footer class=""footer py-4"">
        <div class=""container"">
            <div class=""row align-items-center"">
                <div class=""col-lg-4 text-lg-left"">Todos os direitos reservados ?? payX 2021</div>
                <div class=""col-lg-4 my-3 my-lg-0"">
                    <a class=""btn btn-dark btn-social mx-2"" href=""#!""><i class=""fab fa-twitter""></i></a>
                    <a class=""btn btn-dark btn-social mx-2"" href=""#!""><i class=""fab fa-facebook-f""></i></a>
                    <a class=""btn btn-dark btn-social mx-2"" href=""#!""><i class=""fab fa-linkedin-in""></i></a>
                </div>
                <div class=""col-lg-4 text-lg-right"">
                    <a class=""mr-3"" href=""#!"">Pol??tica de privacidade</a>
                    <a href=""#!"">Termos de uso</a>
                </div>
            </div>
        </div>
    </footer>
    <!-- Modal Boleto-->
    <div id=""boleto-modal"" class=""modal fade"">
        <div class=""modal-dialog moda");
                WriteLiteral(@"l-lg modal-dialog-centered"">
            <div class=""modal-content"">
                <div class=""modal-header"">
                    <div class=""row"">
                        <div class=""col-12"">
                            <h2 class=""text-uppercase"" style=""text-align: center;"">Boleto</h2>
                        </div>
                        <div class=""col-12"">
                            <p class=""item-intro text-muted"" style=""text-align: center;"">
                                Precisa pagar um boleto e n??o
                                tem saldo na conta? Que
                                tal usar seu cart??o de cr??dito e parcelar seu boleto em at?? 12x?
                            </p>
                        </div>
                    </div>
                </div>
                <div class=""modal-body justify-content-center"">
                    <p>Envie um boleto com registro;</p>
                    <p>
                        Verifique a data de vencimento. S?? aceitamos boleto");
                WriteLiteral(@"s com at?? 2 dias ??teis
                        antes do vencimento;
                    </p>
                    <p>Digite na simula????o exatamente o valor do boleto, incluindo os centavos;</p>
                    <p>O valor simulado precisa ser exatamente o mesmo do boleto;</p>
                    <p>Envie o boleto na solicita????o. Foto clara ou pdf</p>
                    <p>N??o ser??o aceitos boletos sem data de vencimento ou sem valor;</p>
                    <p>
                        Boletos com inconsist??ncias de dados ou valores ser??o recusados pela
                        institui????o de pagamento.
                    </p>
                    <div class=""row justify-content-center"">
                        <div class=""col-3"">
                            <button class=""btn btn-primary"" data-dismiss=""modal"" type=""button"">
                                <i class=""fas fa-times mr-1""></i>
                                Fechar
                            </button>
                        </");
                WriteLiteral(@"div>
                    </div>
                </div>
            </div>
        </div>
    </div>

    <!-- Modal Transfer??ncias -->
    <div id=""transferencia-modal"" class=""modal fade"">
        <div class=""modal-dialog modal-lg modal-dialog-centered"">
            <div class=""modal-content"">
                <div class=""modal-header"">
                    <div class=""row"">
                        <div class=""col-12"">
                            <h2 class=""text-uppercase"" style=""text-align: center;"">Transfer??ncias</h2>
                        </div>
                        <div class=""col-12"">
                            <p class=""item-intro text-muted"" style=""text-align: center;"">
                                Precisa transferir dinheiro
                                urgente e n??o tem saldo na
                                conta? Que tal usar seu cart??o de cr??dito e parcelar sua transfer??ncia em at?? 12x?
                            </p>
                        </div>
             ");
                WriteLiteral(@"       </div>
                </div>
                <div class=""modal-body justify-content-center"">
                    <p>
                        Isso mesmo! Na payX voc?? consegue transferir at??
                        R$x,xx e parcelar o
                        pagamento em at?? 12x no cart??o de cr??dito. Voc?? s?? precisa ter um cart??o de cr??dito
                        com limite dispon??vel. Al??m dos dados de cart??o de cr??dito, tamb??m ser?? solicitado
                        os dados banc??rios do benefici??rio da transfer??ncia.
                    </p>
                    <p>
                        O prazo para transfer??ncia ?? de at?? 2 dias ??teis ap??s a
                        aprova????o do seu pedido.
                    </p>
                    <p>
                        Dados inconsistentes ser??o recusados pela
                        institui????o de pagamento.
                    </p>
                    <p> Se tiver d??vidas, fale conosco </p>
                    <div class=""row justify");
                WriteLiteral(@"-content-center"">
                        <div class=""col-3"">
                            <button class=""btn btn-primary"" data-dismiss=""modal"" type=""button"">
                                <i class=""fas fa-times mr-1""></i>
                                Fechar
                            </button>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>

    <!-- Bootstrap core JS-->
    <script src=""https://cdn.jsdelivr.net/npm/bootstrap@4.5.3/dist/js/bootstrap.bundle.min.js""></script>
    <!-- Third party plugin JS-->
    <script src=""https://cdnjs.cloudflare.com/ajax/libs/jquery-easing/1.4.1/jquery.easing.min.js""></script>
    <!-- Core theme JS-->
    <script src=""js/scripts.js""></script>
    <!-- Fun????es pr??prias -->
    <script src=""https://cdnjs.cloudflare.com/ajax/libs/jquery.mask/1.14.16/jquery.mask.min.js""></script>
    <script src=""js/InicializarMascaras.js""></script>
    <script src=""js/Validacoes.js""></sc");
                WriteLiteral("ript>\r\n    <script src=\"js/funcoesHome.js\"></script>\r\n");
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_BodyTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.BodyTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_BodyTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_7);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n\r\n</html>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<dynamic> Html { get; private set; }
    }
}
#pragma warning restore 1591
