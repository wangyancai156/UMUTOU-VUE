using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WangYc.Services.ViewModels.HR {
    public class RoleView {
 
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

        public int ParentId { get; set; }

        public IEnumerable<RoleView> Child { get; set; }

        public virtual List<int> RightsId { get; set; }


    }
}
