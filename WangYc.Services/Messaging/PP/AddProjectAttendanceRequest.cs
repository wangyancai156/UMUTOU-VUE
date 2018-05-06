using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WangYc.Services.Messaging.PP {
    public class AddProjectAttendanceRequest {
         public int Id { get; set; }

        public int ProjectId { get; set; }

        public string UsersId { get; set; }

        public string CreateUserId { get; set; }

    }
}
