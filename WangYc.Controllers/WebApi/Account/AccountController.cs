using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Security;
using WangYc.Controllers.Account.WebApi;
using WangYc.Core.Infrastructure.Configuration;
using WangYc.Core.Infrastructure.CookieStorage;
using WangYc.Services.Interfaces.Account;
using WangYc.Services.Interfaces.HR;
using WangYc.Services.Messaging;
using WangYc.Services.ViewModels.HR;

namespace WangYc.Controllers.WebApi.Account {

    public class AccountController : BaseApiController {

        private readonly IUsersService _usersService;
        private readonly ICookieStorageService _cookieStorageService;
        private readonly IAuthenticationService _authenticationService;
        private readonly IUserDeviceService _serDeviceService;


        public AccountController(
            IUsersService usersService,
            ICookieStorageService cookieStorageService,
            IAuthenticationService authenticationService,
            IUserDeviceService serDeviceService
        ) {

            this._usersService = usersService;
            this._cookieStorageService = cookieStorageService;
            this._authenticationService = authenticationService;
            this._serDeviceService = serDeviceService;
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
        [System.Web.Http.HttpGet]
        public HttpResponseMessage Login(string LoginName, string PassWord) {

            AccountView account = new AccountView();
            if (string.IsNullOrWhiteSpace(LoginName)) {
                account.Result = false;
                account.ResultDescription = "请输入用户名！";
            }
            if (string.IsNullOrWhiteSpace(PassWord)) {
                account.Result = false;
                account.ResultDescription = "密码错误！";
            }

            UsersView user = this._usersService.FindUsersBy(LoginName);
            if (user != null) {

                if (user.UserPwd == PassWord) {

                    string strSource = LoginName + "|" + PassWord + Guid.NewGuid();
                    //获取密文字节数组
                    string sessionKey = Encode(strSource);

                    UserDeviceView existsDevice = this._serDeviceService.GetUserDeviceView(LoginName, "win", sessionKey);

                    if (existsDevice == null) {
                        this._serDeviceService.CrateUserDevice(LoginName, 1, "win", sessionKey);

                    } else {
                        this._serDeviceService.UpdateUserDevice(LoginName, 1, "win", sessionKey);
                    }

                    account.Result = true;
                    account.ResultDescription = "Success！";
                    account.SessionKey = sessionKey;
                    account.User = user;

                } else {
                    account.Result = false;
                    account.ResultDescription = "密码错误！";
                }

            } else {
                account.Result = false;
                account.ResultDescription = "用户名错误！";
            }
            return ToJson(account);
        }
        [System.Web.Http.HttpGet]
        public HttpResponseMessage Verification(string UserId, string Userkey) {

            bool result = AuthenticationFactory.Authentication().ApiVerification(UserId, Userkey);
            return ToJson(result);
        }

        public static string _KEY = "HQDCKEY1";  //密钥  
        public static string _IV = "HQDCKEY2";   //向量  
        public static string Encode(string data) {

            byte[] byKey = System.Text.ASCIIEncoding.ASCII.GetBytes(_KEY);
            byte[] byIV = System.Text.ASCIIEncoding.ASCII.GetBytes(_IV);

            DESCryptoServiceProvider cryptoProvider = new DESCryptoServiceProvider();
            int i = cryptoProvider.KeySize;
            MemoryStream ms = new MemoryStream();
            CryptoStream cst = new CryptoStream(ms, cryptoProvider.CreateEncryptor(byKey, byIV), CryptoStreamMode.Write);
            StreamWriter sw = new StreamWriter(cst);
            sw.Write(data);
            sw.Flush();
            cst.FlushFinalBlock();
            sw.Flush();
            string strRet = Convert.ToBase64String(ms.GetBuffer(), 0, (int)ms.Length);
            return strRet;
        }

        public static string Decode(string data) {

            byte[] byKey = System.Text.ASCIIEncoding.ASCII.GetBytes(_KEY);
            byte[] byIV = System.Text.ASCIIEncoding.ASCII.GetBytes(_IV);

            byte[] byEnc;

            try {
                data.Replace("_%_", "/");
                data.Replace("-%-", "#");
                byEnc = Convert.FromBase64String(data);

            } catch {
                return null;
            }

            DESCryptoServiceProvider cryptoProvider = new DESCryptoServiceProvider();
            MemoryStream ms = new MemoryStream(byEnc);
            CryptoStream cst = new CryptoStream(ms, cryptoProvider.CreateDecryptor(byKey, byIV), CryptoStreamMode.Read);
            StreamReader sr = new StreamReader(cst);
            return sr.ReadToEnd();
        }



    }
}
