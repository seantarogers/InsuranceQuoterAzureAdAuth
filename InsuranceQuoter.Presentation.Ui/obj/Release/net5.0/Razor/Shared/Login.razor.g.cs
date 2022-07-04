#pragma checksum "C:\Code\InsuranceQuoter\InsuranceQuoter.Presentation.Ui\Shared\Login.razor" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "76e023e9ab74360280dd3a05ae22a5710be6dec6"
// <auto-generated/>
#pragma warning disable 1591
namespace InsuranceQuoter.Presentation.Ui.Shared
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
#line 1 "C:\Code\InsuranceQuoter\InsuranceQuoter.Presentation.Ui\Shared\Login.razor"
using Microsoft.AspNetCore.Components.Authorization;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Code\InsuranceQuoter\InsuranceQuoter.Presentation.Ui\Shared\Login.razor"
using Microsoft.AspNetCore.Components.WebAssembly.Authentication;

#line default
#line hidden
#nullable disable
    public partial class Login : Microsoft.AspNetCore.Components.ComponentBase
    {
        #pragma warning disable 1998
        protected override void BuildRenderTree(Microsoft.AspNetCore.Components.Rendering.RenderTreeBuilder __builder)
        {
            __builder.OpenComponent<Microsoft.AspNetCore.Components.Authorization.AuthorizeView>(0);
            __builder.AddAttribute(1, "Authorized", (Microsoft.AspNetCore.Components.RenderFragment<Microsoft.AspNetCore.Components.Authorization.AuthenticationState>)((context) => (__builder2) => {
                __builder2.AddMarkupContent(2, "\r\n        Welcome ");
#nullable restore
#line 9 "C:\Code\InsuranceQuoter\InsuranceQuoter.Presentation.Ui\Shared\Login.razor"
__builder2.AddContent(3, context.User.Identity.Name);

#line default
#line hidden
#nullable disable
                __builder2.AddMarkupContent(4, "\r\n        ");
                __builder2.OpenElement(5, "button");
                __builder2.AddAttribute(6, "class", "nav-link btn btn-link");
                __builder2.AddAttribute(7, "onclick", Microsoft.AspNetCore.Components.EventCallback.Factory.Create<Microsoft.AspNetCore.Components.Web.MouseEventArgs>(this, 
#nullable restore
#line 10 "C:\Code\InsuranceQuoter\InsuranceQuoter.Presentation.Ui\Shared\Login.razor"
                                                        BeginSignOut

#line default
#line hidden
#nullable disable
                ));
                __builder2.AddContent(8, "Log out");
                __builder2.CloseElement();
            }
            ));
            __builder.AddAttribute(9, "NotAuthorized", (Microsoft.AspNetCore.Components.RenderFragment<Microsoft.AspNetCore.Components.Authorization.AuthenticationState>)((context) => (__builder2) => {
                __builder2.AddMarkupContent(10, "<a href=\"authentication/login\">Log in</a>");
            }
            ));
            __builder.CloseComponent();
        }
        #pragma warning restore 1998
#nullable restore
#line 17 "C:\Code\InsuranceQuoter\InsuranceQuoter.Presentation.Ui\Shared\Login.razor"
      
    private async Task BeginSignOut(MouseEventArgs args)
    {
        await SignOutManager.SetSignOutState();
        Navigation.NavigateTo("authentication/logout");
    }

#line default
#line hidden
#nullable disable
        [global::Microsoft.AspNetCore.Components.InjectAttribute] private SignOutSessionStateManager SignOutManager { get; set; }
        [global::Microsoft.AspNetCore.Components.InjectAttribute] private NavigationManager Navigation { get; set; }
    }
}
#pragma warning restore 1591
