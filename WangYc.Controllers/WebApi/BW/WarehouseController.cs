using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Mvc;
using WangYc.Services.Interfaces.BW;
using WangYc.Services.ViewModels.BW;
using System.Web.Script.Serialization;
using System.Net.Http;
using Webdiyer.WebControls.Mvc;
using WangYc.Controllers.Account.WebApi;

namespace WangYc.Controllers.WebApi.BW
{
    public class WarehouseController : BaseApiController
    {
        private IWarehouseService _warehouseService;
        private IWarehouseShelfService _warehouseShelfService;

        public WarehouseController(IWarehouseService warehouseService, IWarehouseShelfService warehouseShelfService)
        {
            this._warehouseService = warehouseService;
            this._warehouseShelfService = warehouseShelfService;
        }

        public HttpResponseMessage GetWarehouse()
        {
            IEnumerable<WarehouseView> model = this._warehouseService.GetWarehouseViewByAll();
            return ToJson(model);
        }
    }
 
}