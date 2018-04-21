using System;
using System.Collections.Generic;
using System.Linq;
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
        
    }
}
