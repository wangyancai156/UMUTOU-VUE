using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WangYc.Services.ViewModels.HR {
    public class RoleView {

        public int OrganizationId {
            get;
            set;
        }
        public string OrganizationName {
            get;
            set;
        }
        public string Id {
            get;
            set;
        }

        public string Name {
            get;
            set;
        }

        public string Description {
            get;
            set;
        }
        public bool IsValid { get; set; }



    }
}
