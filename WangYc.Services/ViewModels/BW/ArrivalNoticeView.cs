using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WangYc.Services.ViewModels.HR;

namespace WangYc.Services.ViewModels.BW {

    public class ArrivalNoticeView {

        public string ArrivalNoticeTypeId {
            get;
            set;
        }
        public string ObjectId {
            get;
            set;
        }
        public string WarehouseId {
            get;
            set;
        }
        public string Note {
            get;
            set;
        }
        public int State {
            get;
            set;
        }

        public UsersView CreateUser {
            get;
            set;
        }
        public virtual DateTime CreateDate {
            get;
            set;
        }

    }
}

 