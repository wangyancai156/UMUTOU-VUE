using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WangYc.Services.Messaging.HR {
    public class AddUsersRequest {
 
        /// <summary>
        ///  用户编号
        /// </summary>
        string id;
        public string Id {
            get { return id; }
            set { id = value; }
        }
        /// <summary>
        ///  用户姓名（登录账号）
        /// </summary>
        string username;
        public string Name {
            get { return username; }
            set { username = value; }
        }
        /// <summary>
        ///  密码
        /// </summary>
        string userpwd;
        public string Pwd {
            get { return userpwd; }
            set { userpwd = value; }
        }
        int organizationid;
        public int Organizationid {
            get { return organizationid; }
            set { organizationid = value; }
        }

        string telephone;
        public string Telephone {
            get { return telephone; }
            set { telephone = value; }
        }

    }
}
