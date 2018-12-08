using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using WangYc.Services.Interfaces.Account;

namespace WangYc.Controllers.WebApi.Account {
    public class AuthFilterOutside : AuthorizeAttribute {
        //重写基类的验证方式，加入我们自定义的Ticket验证  
        public override void OnAuthorization(System.Web.Http.Controllers.HttpActionContext actionContext) {

            //解密用户ticket,并校验用户名密码是否匹配  
            if (AuthenticationFactory.Authentication().Verification) {
                base.IsAuthorized(actionContext);
            } else {
                //如果取不到身份验证信息，并且不允许匿名访问，则返回未验证401  
                var attributes = actionContext.ActionDescriptor.GetCustomAttributes<AllowAnonymousAttribute>().OfType<AllowAnonymousAttribute>();
                bool isAnonymous = attributes.Any(a => a is AllowAnonymousAttribute);
                if (isAnonymous) base.OnAuthorization(actionContext);
                else HandleUnauthorizedRequest(actionContext);
            }
        }

    }
}
