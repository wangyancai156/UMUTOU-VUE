using System;
using System.Web;
using System.Web.Security;
using WangYc.Core.Infrastructure.CookieStorage;
using WangYc.Services.Interfaces.Account;
using WangYc.Services.Interfaces.HR;
using WangYc.Services.ViewModels.HR;

namespace WangYc.Services.Implementations.Account {

    public class AuthenticationService : IAuthenticationService {

        ICookieStorageService _cookieStorageService;
        IUserDeviceService _userDeviceService;
        public AuthenticationService(ICookieStorageService cookieStorageService, IUserDeviceService userDeviceService) {
            this._cookieStorageService = cookieStorageService;
            this._userDeviceService = userDeviceService;
        }

        #region  MVC登陆验证

        /// <summary>
        /// 添加用户Form验证 Cookie
        /// </summary>
        /// <param name="name"></param>
        /// <param name="userData"></param>
        public void AddTicket(string name, string userData) {

            this._cookieStorageService.Add(CreateFormAuthenticationCustomeCookie(name, userData));
        }

        /// <summary>
        /// 获取用户Form验证
        /// </summary>
        /// <returns></returns>
        public FormsAuthenticationTicket RetrieveTicket() {

            string cookieValue = this._cookieStorageService.Retrieve(FormsAuthentication.FormsCookieName);
            if (string.IsNullOrEmpty(cookieValue))
                return null;
            try {
                FormsAuthenticationTicket ticket = FormsAuthentication.Decrypt(cookieValue);
                return ticket;
            } catch {
                return null;
            }
        }

        /// <summary>
        /// 创建用户Form验证 Cookie
        /// </summary>
        /// <param name="name"></param>
        /// <param name="userData"></param>
        /// <returns></returns>
        public HttpCookie CreateFormAuthenticationCustomeCookie(string name, string userData) {

            // 1.创建一个FormsAuthenticationTicket，它包含登录名以及额外的用户数据。
            FormsAuthenticationTicket ticket = new FormsAuthenticationTicket(2, name, DateTime.Now, DateTime.Now.AddHours(4), true, userData);

            // 2.加密Ticket，变成一个加密的字符串。
            string cookieValue = FormsAuthentication.Encrypt(ticket);

            //解密Ticket
            FormsAuthenticationTicket tickets = FormsAuthentication.Decrypt(cookieValue);

            // 3.根据加密结果创建登录Cookie
            HttpCookie cookie = new HttpCookie(FormsAuthentication.FormsCookieName, cookieValue);
            cookie.HttpOnly = true;
            cookie.Secure = FormsAuthentication.RequireSSL;
            cookie.Domain = FormsAuthentication.CookieDomain;
            cookie.Path = FormsAuthentication.FormsCookiePath;
            cookie.Expires = DateTime.Now.AddHours(4);

            return cookie;
        }

        /// <summary>
        /// 验证
        /// </summary>
        /// <returns></returns>
        public bool Verification {
            get {
                FormsAuthenticationTicket ticket = this.RetrieveTicket();
                if (ticket == null || ticket.Name == null || ticket.UserData == null || ticket.Expired) {
                    return false;
                }
                return true;
            }
        }
        #endregion

        #region 前后端分离登陆验证

        /// <summary>
        /// 验证
        /// </summary>
        /// <returns></returns>
        public bool ApiVerification(string userId, string sessionKey) {

            UserDeviceView model = this._userDeviceService.GetUserDeviceView(userId, "win", sessionKey);

            if (model == null || model.ExpiredTime > DateTime.Now) {
                return false;
            }
            return true;

        }

        #endregion

    }
}

