#pragma checksum "C:\Users\Samira\Desktop\Barnamenevisi2020\toplearn\toplearn.web\Views\Account\SuccsessRegister.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "bdf34aa82f9c47ffd065c49b3053df96c4cfe334"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Account_SuccsessRegister), @"mvc.1.0.view", @"/Views/Account/SuccsessRegister.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Account/SuccsessRegister.cshtml", typeof(AspNetCore.Views_Account_SuccsessRegister))]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"bdf34aa82f9c47ffd065c49b3053df96c4cfe334", @"/Views/Account/SuccsessRegister.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"a9af4978b9c2bfca24ef48e96efe5f8573634464", @"/Views/_ViewImports.cshtml")]
    public class Views_Account_SuccsessRegister : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<toplearn.Datalayer.Entities.User.User>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#line 2 "C:\Users\Samira\Desktop\Barnamenevisi2020\toplearn\toplearn.web\Views\Account\SuccsessRegister.cshtml"
  
    ViewData["Title"] = "پایان ثبت نام";

#line default
#line hidden
            BeginContext(96, 275, true);
            WriteLiteral(@"
<nav aria-label=""breadcrumb"">
    <ul class=""breadcrumb"">
        <li class=""breadcrumb-item""><a href=""/"">تاپ لرن</a></li>
        <li class=""breadcrumb-item active"" aria-current=""page"">پایان ثبت نام</li>
    </ul>

    <div class=""alert alert-sucsses"">
        <h2>");
            EndContext();
            BeginContext(372, 14, false);
#line 13 "C:\Users\Samira\Desktop\Barnamenevisi2020\toplearn\toplearn.web\Views\Account\SuccsessRegister.cshtml"
       Write(Model.UserName);

#line default
#line hidden
            EndContext();
            BeginContext(386, 138, true);
            WriteLiteral(" عزیز</h2>\r\n        <p>\r\n            ثبت نام شما انجام شد\r\n            لطفا برای فعالسازی وارد ایمیل خود شوید و بر روی لینک زیر کلیک کنید ");
            EndContext();
            BeginContext(525, 11, false);
#line 16 "C:\Users\Samira\Desktop\Barnamenevisi2020\toplearn\toplearn.web\Views\Account\SuccsessRegister.cshtml"
                                                                          Write(Model.Email);

#line default
#line hidden
            EndContext();
            BeginContext(536, 27, true);
            WriteLiteral(" \r\n        </p>\r\n    </div>");
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
