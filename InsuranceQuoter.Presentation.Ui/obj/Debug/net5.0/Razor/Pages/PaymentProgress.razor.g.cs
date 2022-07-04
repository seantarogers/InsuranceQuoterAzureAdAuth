#pragma checksum "C:\Code\InsuranceQuoter\InsuranceQuoter.Presentation.Ui\Pages\PaymentProgress.razor" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "1e1f14bf8804cfbb5dbc4198caec622c20d671b1"
// <auto-generated/>
#pragma warning disable 1591
namespace InsuranceQuoter.Presentation.Ui.Pages
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Components;
#nullable restore
#line 1 "C:\Code\InsuranceQuoter\InsuranceQuoter.Presentation.Ui\_Imports.razor"
using System.Net.Http;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Code\InsuranceQuoter\InsuranceQuoter.Presentation.Ui\_Imports.razor"
using System.Net.Http.Json;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "C:\Code\InsuranceQuoter\InsuranceQuoter.Presentation.Ui\_Imports.razor"
using Microsoft.AspNetCore.Components.Forms;

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "C:\Code\InsuranceQuoter\InsuranceQuoter.Presentation.Ui\_Imports.razor"
using Microsoft.AspNetCore.Components.Routing;

#line default
#line hidden
#nullable disable
#nullable restore
#line 5 "C:\Code\InsuranceQuoter\InsuranceQuoter.Presentation.Ui\_Imports.razor"
using Microsoft.AspNetCore.Components.Web;

#line default
#line hidden
#nullable disable
#nullable restore
#line 6 "C:\Code\InsuranceQuoter\InsuranceQuoter.Presentation.Ui\_Imports.razor"
using Microsoft.AspNetCore.Components.Web.Virtualization;

#line default
#line hidden
#nullable disable
#nullable restore
#line 7 "C:\Code\InsuranceQuoter\InsuranceQuoter.Presentation.Ui\_Imports.razor"
using Microsoft.AspNetCore.Components.Authorization;

#line default
#line hidden
#nullable disable
#nullable restore
#line 8 "C:\Code\InsuranceQuoter\InsuranceQuoter.Presentation.Ui\_Imports.razor"
using Microsoft.AspNetCore.Components.WebAssembly.Http;

#line default
#line hidden
#nullable disable
#nullable restore
#line 9 "C:\Code\InsuranceQuoter\InsuranceQuoter.Presentation.Ui\_Imports.razor"
using Microsoft.JSInterop;

#line default
#line hidden
#nullable disable
#nullable restore
#line 10 "C:\Code\InsuranceQuoter\InsuranceQuoter.Presentation.Ui\_Imports.razor"
using InsuranceQuoter.Presentation.Ui;

#line default
#line hidden
#nullable disable
#nullable restore
#line 11 "C:\Code\InsuranceQuoter\InsuranceQuoter.Presentation.Ui\_Imports.razor"
using InsuranceQuoter.Presentation.Ui.Shared;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Code\InsuranceQuoter\InsuranceQuoter.Presentation.Ui\Pages\PaymentProgress.razor"
using Microsoft.AspNetCore.Authorization;

#line default
#line hidden
#nullable disable
#nullable restore
#line 5 "C:\Code\InsuranceQuoter\InsuranceQuoter.Presentation.Ui\Pages\PaymentProgress.razor"
           [Authorize]

#line default
#line hidden
#nullable disable
    [Microsoft.AspNetCore.Components.RouteAttribute("/paymentprogress")]
    public partial class PaymentProgress : Fluxor.Blazor.Web.Components.FluxorComponent
    {
        #pragma warning disable 1998
        protected override void BuildRenderTree(Microsoft.AspNetCore.Components.Rendering.RenderTreeBuilder __builder)
        {
#nullable restore
#line 7 "C:\Code\InsuranceQuoter\InsuranceQuoter.Presentation.Ui\Pages\PaymentProgress.razor"
 if (PolicyBound == false)
{

#line default
#line hidden
#nullable disable
            __builder.AddMarkupContent(0, "<h1 class=\"page-title\">Please wait whilst we place your car on cover...</h1>");
            __builder.OpenElement(1, "div");
            __builder.AddAttribute(2, "class", "form-group");
            __builder.OpenElement(3, "ul");
            __builder.AddAttribute(4, "class", "list-group");
#nullable restore
#line 14 "C:\Code\InsuranceQuoter\InsuranceQuoter.Presentation.Ui\Pages\PaymentProgress.razor"
             foreach (string state in States)
            {

#line default
#line hidden
#nullable disable
            __builder.OpenElement(5, "li");
            __builder.AddAttribute(6, "class", "list-group-item");
#nullable restore
#line 16 "C:\Code\InsuranceQuoter\InsuranceQuoter.Presentation.Ui\Pages\PaymentProgress.razor"
__builder.AddContent(7, state);

#line default
#line hidden
#nullable disable
            __builder.CloseElement();
#nullable restore
#line 17 "C:\Code\InsuranceQuoter\InsuranceQuoter.Presentation.Ui\Pages\PaymentProgress.razor"
            }

#line default
#line hidden
#nullable disable
            __builder.CloseElement();
            __builder.CloseElement();
            __builder.OpenElement(8, "div");
            __builder.AddAttribute(9, "class", "form-group");
            __builder.OpenElement(10, "div");
            __builder.AddAttribute(11, "class", "progress");
            __builder.OpenElement(12, "div");
            __builder.AddAttribute(13, "class", "progress-bar progress-bar-striped bg-success progress-bar-animated");
            __builder.AddAttribute(14, "style", "width:" + " " + (
#nullable restore
#line 23 "C:\Code\InsuranceQuoter\InsuranceQuoter.Presentation.Ui\Pages\PaymentProgress.razor"
                                                                                                           StatesPercentage

#line default
#line hidden
#nullable disable
            ));
            __builder.AddAttribute(15, "role", "progressbar");
            __builder.AddAttribute(16, "aria-valuenow", 
#nullable restore
#line 23 "C:\Code\InsuranceQuoter\InsuranceQuoter.Presentation.Ui\Pages\PaymentProgress.razor"
                                                                                                                                                                StatesCompleted

#line default
#line hidden
#nullable disable
            );
            __builder.AddAttribute(17, "aria-valuemin", "0");
            __builder.AddAttribute(18, "aria-valuemax", "5");
            __builder.CloseElement();
            __builder.CloseElement();
            __builder.CloseElement();
#nullable restore
#line 26 "C:\Code\InsuranceQuoter\InsuranceQuoter.Presentation.Ui\Pages\PaymentProgress.razor"
}
else
{

#line default
#line hidden
#nullable disable
            __builder.OpenElement(19, "div");
            __builder.OpenElement(20, "div");
            __builder.AddAttribute(21, "class", "card");
            __builder.AddMarkupContent(22, "<div class=\"card-header\"><strong>Your car is now on cover!</strong></div>\r\n            ");
            __builder.OpenElement(23, "div");
            __builder.AddAttribute(24, "class", "card-body");
            __builder.OpenElement(25, "p");
            __builder.AddAttribute(26, "class", "card-text");
            __builder.AddMarkupContent(27, "<strong>Insurer</strong>: ");
#nullable restore
#line 34 "C:\Code\InsuranceQuoter\InsuranceQuoter.Presentation.Ui\Pages\PaymentProgress.razor"
__builder.AddContent(28, InsurerName);

#line default
#line hidden
#nullable disable
            __builder.CloseElement();
            __builder.AddMarkupContent(29, "\r\n                ");
            __builder.OpenElement(30, "p");
            __builder.AddAttribute(31, "class", "card-text");
            __builder.AddMarkupContent(32, "<strong>Policy Reference</strong>: ");
#nullable restore
#line 35 "C:\Code\InsuranceQuoter\InsuranceQuoter.Presentation.Ui\Pages\PaymentProgress.razor"
__builder.AddContent(33, PolicyUid);

#line default
#line hidden
#nullable disable
            __builder.CloseElement();
            __builder.AddMarkupContent(34, "\r\n                ");
            __builder.OpenElement(35, "p");
            __builder.AddAttribute(36, "class", "card-text");
            __builder.AddMarkupContent(37, "<strong>Cover Type</strong>: ");
#nullable restore
#line 36 "C:\Code\InsuranceQuoter\InsuranceQuoter.Presentation.Ui\Pages\PaymentProgress.razor"
__builder.AddContent(38, CoverType);

#line default
#line hidden
#nullable disable
            __builder.CloseElement();
            __builder.AddMarkupContent(39, "\r\n                ");
            __builder.OpenElement(40, "p");
            __builder.AddAttribute(41, "class", "card-text");
            __builder.AddMarkupContent(42, "<strong>Car Registration</strong>: ");
#nullable restore
#line 37 "C:\Code\InsuranceQuoter\InsuranceQuoter.Presentation.Ui\Pages\PaymentProgress.razor"
__builder.AddContent(43, Registration);

#line default
#line hidden
#nullable disable
            __builder.CloseElement();
            __builder.CloseElement();
            __builder.CloseElement();
            __builder.CloseElement();
#nullable restore
#line 41 "C:\Code\InsuranceQuoter\InsuranceQuoter.Presentation.Ui\Pages\PaymentProgress.razor"
}

#line default
#line hidden
#nullable disable
        }
        #pragma warning restore 1998
    }
}
#pragma warning restore 1591
