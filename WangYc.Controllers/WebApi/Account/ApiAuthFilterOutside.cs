using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Http.Controllers;
using WangYc.Services.Interfaces.Account;

namespace WangYc.Controllers.WebApi.Account {
    public class ApiAuthFilterOutside : AuthorizeAttribute {

        public const string SessionKey = "SessionKey";
        public const string UserId = "UserId";
         
        public override void OnAuthorization(HttpActionContext actionContext) {

            var qs = HttpUtility.ParseQueryString(actionContext.Request.RequestUri.Query);
            string sessionKey = qs[SessionKey];
            string userId = qs[UserId];

            if (AuthenticationFactory.Authentication().ApiVerification(userId, sessionKey)) {
                base.IsAuthorized(actionContext);
            } else {
                var attributes = actionContext.ActionDescriptor.GetCustomAttributes<AllowAnonymousAttribute>().OfType<AllowAnonymousAttribute>();
                bool isAnonymous = attributes.Any(a => a is AllowAnonymousAttribute);
                if (isAnonymous) {
                    base.OnAuthorization(actionContext);
                } else {
                    HandleUnauthorizedRequest(actionContext);
                }
            }

            ////验证用户session
            //var userSession = authenticationService.GetUserDevice(sessionKey);

            //if (userSession == null) {
            //    throw new ApiException("无此 sessionKey", "RequireParameter_sessionKey");
            //} else {
            //    //todo: 加Session是否过期的判断
            //    if (userSession.ExpiredTime < DateTime.UtcNow)
            //        throw new ApiException("session已过期", "SessionTimeOut");

            //    var logonUser = authenticationService.GetUser(userSession.UserId);
            //    if (logonUser != null) {
            //        filterContext.ControllerContext.RouteData.Values[LogonUserName] = logonUser;
            //        SetPrincipal(new UserPrincipal<int>(logonUser));
            //    }
            //    userSession.ActiveTime = DateTime.UtcNow;
            //    userSession.ExpiredTime = DateTime.UtcNow.AddMinutes(60);
            //    authenticationService.UpdateUserDevice(userSession);
            //}
        }
 
    }
}
