#pragma checksum "C:\Users\Samira\Desktop\Barnamenevisi2020\toplearn\toplearn.web\Views\Shared\_forgotPassword.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "0cac4a773c1f7e7696eb5074d0f680fa11ec7099"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Shared__forgotPassword), @"mvc.1.0.view", @"/Views/Shared/_forgotPassword.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Shared/_forgotPassword.cshtml", typeof(AspNetCore.Views_Shared__forgotPassword))]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"0cac4a773c1f7e7696eb5074d0f680fa11ec7099", @"/Views/Shared/_forgotPassword.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"a9af4978b9c2bfca24ef48e96efe5f8573634464", @"/Views/_ViewImports.cshtml")]
    public class Views_Shared__forgotPassword : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<toplearn.Datalayer.Entities.User.User>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            BeginContext(46, 54, true);
            WriteLiteral("\r\n<div style=\"direction:rtl;padding:20px\">\r\n\r\n    <h2>");
            EndContext();
            BeginContext(101, 14, false);
#line 5 "C:\Users\Samira\Desktop\Barnamenevisi2020\toplearn\toplearn.web\Views\Shared\_forgotPassword.cshtml"
   Write(Model.UserName);

#line default
#line hidden
            EndContext();
            BeginContext(115, 110, true);
            WriteLiteral(" عزیز!</h2>\r\n    <p>\r\n        جهت بازیابی رمز عبور خود روی لینک زیر کلیک نمایید\r\n    </p>\r\n    <p>\r\n        <a");
            EndContext();
            BeginWriteAttribute("href", " href=\"", 225, "\"", 295, 2);
            WriteAttributeValue("", 232, "https://localhost:44375/Account/ResetPassword/", 232, 46, true);
#line 10 "C:\Users\Samira\Desktop\Barnamenevisi2020\toplearn\toplearn.web\Views\Shared\_forgotPassword.cshtml"
WriteAttributeValue("", 278, Model.ActiveCode, 278, 17, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(296, 40, true);
            WriteLiteral(">بازیابی کلمه عبور</a>\r\n    </p>\r\n</div>");
            EndContext();
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<toplearn.Datalayer.Entities.User.User> Html { get; private set; }
    }
}
#pragma warning restore 1591
