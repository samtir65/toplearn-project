#pragma checksum "C:\Users\Samira\Desktop\Barnamenevisi2020\toplearn\toplearn.web\Views\Shared\ActiveEmail.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "a665287eea84945ff4c423093143c54e43498b02"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Shared_ActiveEmail), @"mvc.1.0.view", @"/Views/Shared/ActiveEmail.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Shared/ActiveEmail.cshtml", typeof(AspNetCore.Views_Shared_ActiveEmail))]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"a665287eea84945ff4c423093143c54e43498b02", @"/Views/Shared/ActiveEmail.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"a9af4978b9c2bfca24ef48e96efe5f8573634464", @"/Views/_ViewImports.cshtml")]
    public class Views_Shared_ActiveEmail : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<toplearn.Datalayer.Entities.User.User>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            BeginContext(46, 54, true);
            WriteLiteral("\r\n<div style=\"direction:rtl;padding:20px\">\r\n\r\n    <h2>");
            EndContext();
            BeginContext(101, 14, false);
#line 5 "C:\Users\Samira\Desktop\Barnamenevisi2020\toplearn\toplearn.web\Views\Shared\ActiveEmail.cshtml"
   Write(Model.UserName);

#line default
#line hidden
            EndContext();
            BeginContext(115, 145, true);
            WriteLiteral(" عزیز!</h2>\r\n   <p>\r\n       با تشکر از ثبت نام شما در تاپ لرن جهت ادامه کار می بایست حساب کاربری خود را فعال نمایید\r\n   </p>\r\n    <p>\r\n        <a");
            EndContext();
            BeginWriteAttribute("href", " href=\"", 260, "\"", 330, 2);
            WriteAttributeValue("", 267, "https://localhost:44375/Account/ActiveAccount/", 267, 46, true);
#line 10 "C:\Users\Samira\Desktop\Barnamenevisi2020\toplearn\toplearn.web\Views\Shared\ActiveEmail.cshtml"
WriteAttributeValue("", 313, Model.ActiveCode, 313, 17, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(331, 43, true);
            WriteLiteral(">فعالسازی حساب کاربری</a>\r\n    </p>\r\n</div>");
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
