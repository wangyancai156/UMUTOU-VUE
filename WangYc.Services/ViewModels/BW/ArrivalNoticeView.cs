using System;
using WangYc.Services.ViewModels.HR;

namespace WangYc.Services.ViewModels.BW {

    public class ArrivalNoticeView {


        public int Id {
            get;
            set;
        }

        public ArrivalNoticeTypeView ArrivalNoticeType {
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

        private DateTime createdate;
        public string CreateDate {
            get { return createdate.ToString("yyyy-MM-dd HH:mm:ss"); }
            set { createdate = Convert.ToDateTime(value); }
        }

    }
}

