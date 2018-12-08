using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Web.Mvc;
using WangYc.Services.Interfaces.HR;
using System.Security.Principal;
using WangYc.Core.Infrastructure.Security;
using System.Web;
using System.Web.Security;
using WangYc.Services.ViewModels.HR;
using WangYc.Core.Infrastructure.CookieStorage;
using WangYc.Core.Infrastructure.Configuration;
using WangYc.Services.Messaging;
using WangYc.Services.Interfaces.Account;

namespace WangYc.Controllers.Controllers.Account {
    public class AccountController:Controller {

        private readonly IUsersService _usersService;
        private readonly ICookieStorageService _cookieStorageService;
        private readonly IAuthenticationService _authenticationService;
        

        public AccountController(IUsersService usersService, ICookieStorageService cookieStorageService, IAuthenticationService authenticationService) {

            this._usersService = usersService;
            this._cookieStorageService = cookieStorageService;
            this._authenticationService = authenticationService;
        }

        [AllowAnonymous]
        public ActionResult Login(string returnUrl) {

            ViewBag.ReturnUrl = returnUrl;
            try {

                string cookieValue = this._cookieStorageService.Retrieve(FormsAuthentication.FormsCookieName);
                FormsAuthenticationTicket tickets = FormsAuthentication.Decrypt(cookieValue);
                if (tickets != null && tickets.Name != null || tickets.Expired) {
                    if (string.IsNullOrEmpty(returnUrl)) {
                        returnUrl = "/BW/InOutBound/Index";
                    }
                    return Redirect(returnUrl);
                }

            }
            catch {
            }
            AccountRequest request = new AccountRequest();
            return View(request);
        }
        /// <summary>
        /// 登录
        /// </summary>
        /// <param name="domainName">域名</param>
        /// <param name="userName">用户名</param>
        /// <param name="password">密码</param>
        /// <param name="vcode">验证码</param>
        /// <param name="returnUrl">请求页面</param>
        /// <returns></returns>
        [HttpPost]
        [AllowAnonymous]
        public ActionResult Login(AccountRequest request) {

            //Windows身份验证,
            //WindowsIdentity userIdentiy = ActiveDirectoryHelper.GetWindowsIdentity(domainName, userName, password);
            //Form身份验证
            // 基本信息校验
            if (string.IsNullOrWhiteSpace(request.LoginName)) {
                request.LoginName = "";
                return View(request);
            }
            if (string.IsNullOrWhiteSpace(request.PassWord)) { 
                request.PassWord = "";
                return View(request);
            }
            if (string.IsNullOrWhiteSpace(request.Vcode)) { 
                request.PassWord = "";
                return View(request);
            }
            if (Session[ApplicationSettingsFactory.GetApplicationSettings().VerificationCode] == null || request.Vcode.Trim() != Session[ApplicationSettingsFactory.GetApplicationSettings().VerificationCode].ToString()) {
                request.VcodePH = "验证码输入错误！";
                return View(request);
            }
            
            UsersView user = this._usersService.FindUsersBy(request.LoginName);
            if (user != null) {

                if (user.UserPwd == request.PassWord) {

                    string userData = request.DomainName + "|" + request.LoginName + "|" + request.PassWord;
                    // 添加认证
                    this._authenticationService.AddTicket(user.Id, userData);
                    // 更新登录时间
                    this._usersService.UpdateLastLoginTime(user.Id);
                    // 重定向回验证前访问的界面
                    //Response.Redirect(FormsAuthentication.GetRedirectUrl(userIdentiy.Name, true));
                    if (string.IsNullOrEmpty(request.ReturnUrl)) {
                        request.ReturnUrl = "/BW/InOutBound/Index";
                    }
                    return Redirect(request.ReturnUrl);

                }
                else {
                    request.PassWord = "";
                    request.PassWordPH = "密码错误！";
                }
                // 清空验证码session，避免资源浪费
                Session.Remove(ApplicationSettingsFactory.GetApplicationSettings().VerificationCode);
 
            }
            else {
                request.LoginName = null;
                request.LoginName = "用户名错误！";
            }
            return View(request);
        }

        public UsersView FindUsersBy(string userName) {

            return this._usersService.FindUsersBy(userName);
        }
    }
}
