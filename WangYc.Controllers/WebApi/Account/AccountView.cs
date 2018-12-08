using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WangYc.Services.ViewModels.HR;

namespace WangYc.Controllers.WebApi.Account {
    public class AccountView {

        public bool Result { get; set; }

        public string ResultDescription { get; set; }

        public string SessionKey { get; set; }

        public UsersView User { get; set; }
    }
}
