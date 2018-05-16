using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Security;
using WangYc.Core.Infrastructure.Account;
using WangYc.Core.Infrastructure.Configuration;
using WangYc.Core.Infrastructure.CookieStorage;
using WangYc.Services.Interfaces.HR;
using WangYc.Services.Messaging;
using WangYc.Services.ViewModels.HR;

namespace WangYc.Controllers.WebApi.Account
{
    public class AccountController : ApiController
    {

        private readonly IUsersService _usersService;
        private readonly ICookieStorageService _cookieStorageService;
        private readonly IAuthenticationService _authenticationService;


        public AccountController(IUsersService usersService, ICookieStorageService cookieStorageService, IAuthenticationService authenticationService)
        {

            this._usersService = usersService;
            this._cookieStorageService = cookieStorageService;
            this._authenticationService = authenticationService;
        }

        [System.Web.Http.AllowAnonymous]
        public bool Login(string returnUrl)
        {

            bool result = false;
            try
            {
                string cookieValue = this._cookieStorageService.Retrieve(FormsAuthentication.FormsCookieName);
                FormsAuthenticationTicket tickets = FormsAuthentication.Decrypt(cookieValue);
                if (tickets != null && tickets.Name != null || tickets.Expired)
                {
                    if (string.IsNullOrEmpty(returnUrl))
                    {
                        returnUrl = "/BW/InOutBound/Index";
                    }
                    result = true;
                }
            }
            catch
            {

            }
            return result;
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
        public string Login(AccountRequest request)
        {

            //Windows身份验证,
            //WindowsIdentity userIdentiy = ActiveDirectoryHelper.GetWindowsIdentity(domainName, userName, password);
            //Form身份验证
            // 基本信息校验

            string result = "";
            if (string.IsNullOrWhiteSpace(request.LoginName))
            {
                result = "请输入用户名！";
            }
            if (string.IsNullOrWhiteSpace(request.PassWord))
            {
                result = "密码错误！";
            }
            if (string.IsNullOrWhiteSpace(request.Vcode))
            {
                result = "密码错误！";
            }
            //if (Session[ApplicationSettingsFactory.GetApplicationSettings().VerificationCode] == null || request.Vcode.Trim() != Session[ApplicationSettingsFactory.GetApplicationSettings().VerificationCode].ToString()) {
            //    request.VcodePH = "验证码输入错误！";
            //}

            UsersView user = this._usersService.FindUsersBy(request.LoginName);
            if (user != null)
            {

                if (user.UserPwd == request.PassWord)
                {

                    string userData = request.DomainName + "|" + request.LoginName + "|" + request.PassWord;
                    // 添加认证
                    this._authenticationService.AddTicket(user.Id, userData);
                    // 更新登录时间
                    this._usersService.UpdateLastLoginTime(user.Id);
                    // 重定向回验证前访问的界面
                    //Response.Redirect(FormsAuthentication.GetRedirectUrl(userIdentiy.Name, true));

                }
                else
                {
                    result = "密码错误！";
                }
                // 清空验证码session，避免资源浪费
                //Session.Remove(ApplicationSettingsFactory.GetApplicationSettings().VerificationCode);

            }
            else
            {
                result = "用户名错误！";
            }
            return result;
        }

        public UsersView FindUsersBy(string userName)
        {

            return this._usersService.FindUsersBy(userName);
        }

        /// <summary>
        ///  TODO：待完善此处的登录校验逻辑，依据账号和密码和数据库中进行比较，然后返回相应实体
        ///  在vue前台接收返回的实体，进行逻辑判断是否登录成功
        ///  测试接口：http://localhost:3143/api/account/login?uname=admin&upass=123
        /// </summary>
        /// <param name="uname"></param>
        /// <param name="upass"></param>
        /// <returns></returns>
        [System.Web.Http.HttpGet]
        public UsersView Login(string uname, string upass)
        {
            UsersView ent = new UsersView();
            ent.UserName = "admin";
            ent.UserPwd = "123";
            return ent;
        }

    }
}
