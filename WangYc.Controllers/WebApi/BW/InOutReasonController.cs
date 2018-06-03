using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using WangYc.Controllers.Account.WebApi;
using WangYc.Services.Implementations.BW;

namespace WangYc.Controllers.WebApi.BW {
    public class InOutReasonController : BaseApiController {

        private InOutReasonService _inOutReasonService;

        public InOutReasonController(InOutReasonService inOutReasonService) {

            this._inOutReasonService = inOutReasonService;
        }


        public HttpResponseMessage GetInReason() {

            return ToJson(this._inOutReasonService.GetInOutReasonView(1));
        }

        public HttpResponseMessage GetOutReason() {

            return ToJson(this._inOutReasonService.GetInOutReasonView(0));
        }

    }
}
