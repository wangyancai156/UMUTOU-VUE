using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WangYc.Services.Messaging {

    public class AccountRequest {

        public string DomainName { get; set; }

        public string LoginName { get; set; }

        public string PassWord { get; set; }

        public string Vcode { get; set; }

        public string ReturnUrl { get; set; }

        public string DomainNamePH { get; set; }

        public string LoginNamePH { get; set; }

        public string PassWordPH { get; set; }

        public string VcodePH { get; set; }

        public AccountRequest() {

            this.DomainNamePH = "请输入区域...";
            this.LoginNamePH = "请输入用户名...";
            this.PassWordPH = "请输入密码...";
            this.VcodePH = "请输入验证码...";
        }

    }
}
