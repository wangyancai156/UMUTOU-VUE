﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WangYc.Services.ViewModels.HR {
    public class UsersView {

        public string Id {
            get;
            set;
        }

        public string UserName {
            get;
            set;
        }

        public string UserPwd {
            get;
            set;
        }
        public string Telephone {
            get;
            set;
        }

        public string LastSignTime {
            get;
            set;
        }

        public string SignState {
            get;
            set;
        }

        public IList<OrganizationView> Organization { get; set; }

        public IList<UserDeviceView> Device { get; set; }

        public virtual List<int> RoleId { get; set; }

        public IList<Menu> Menu { get; set; }
    }
}
