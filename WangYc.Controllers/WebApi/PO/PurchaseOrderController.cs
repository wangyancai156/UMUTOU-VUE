using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;
using WangYc.Controllers.Account.WebApi;
using WangYc.Core.Infrastructure.Domain;
using WangYc.Services.Interfaces.FI;
using WangYc.Services.Interfaces.PO;
using WangYc.Services.Interfaces.RS;
using WangYc.Services.Messaging.PO;
using WangYc.Services.ViewModels.FI;
using WangYc.Services.ViewModels.PO;
using WangYc.Services.ViewModels.RS;

namespace WangYc.Controllers.WebApi.PO {
    public class PurchaseOrderController : BaseApiController {

        private readonly IPurchaseOrderService _purchaseOrderService;
        private readonly IPurchaseTypeService _purchaseTypeService;
        private readonly IPaymentTypeService _paymentTypeService;
        private readonly ISupplierService _supplierService;

        public PurchaseOrderController(
                IPurchaseOrderService purchaseOrderService,
                IPurchaseTypeService purchaseTypeService,
                IPaymentTypeService paymentTypeService,
                ISupplierService supplierService
        ) {
            this._purchaseOrderService = purchaseOrderService;
            this._purchaseTypeService = purchaseTypeService;
            this._paymentTypeService = paymentTypeService;
            this._supplierService = supplierService;
        }


        #region 采购单
        /// <summary>
        /// 根据状态获取采购单
        /// </summary>
        /// <param name="status"></param>
        /// <returns></returns>
        [HttpGet]
        public HttpResponseMessage GetPurchaseOrderViewByStatus([FromUri] GetPurchaseOrderRequest request) {

            ListPaged<PurchaseOrderView> model = this._purchaseOrderService.GetPurchaseOrderViewByStatus(request);
            return ToJson(model);
        }
         
        [HttpGet]
        public HttpResponseMessage AddPurchaseOrder([FromUri] AddPurchaseOrderRequest request) {

            this._purchaseOrderService.AddPurchaseOrder(request);
            return ToJson("");
        }
        [HttpGet]
        public HttpResponseMessage RemovePurchaseOrder(string id ) {
 
            string[] ids = id.Split('|');
            this._purchaseOrderService.RemovePurchaseOrder(ids);
            return ToJson("");
        }

        #endregion

        #region 添加采购单是获取的信息

        /// <summary>
        /// 获取采购类型
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public HttpResponseMessage GetPurchaseType() {

            IEnumerable<PurchaseTypeView> model = this._purchaseTypeService.GetPurchaseTypeViewByAll();
            return ToJson(model);
        }
        /// <summary>
        /// 获取供应商
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public HttpResponseMessage GetSupplierView() {

            IEnumerable<SupplierView> model = this._supplierService.GetSupplierViewByAll();
            return ToJson(model);
        }

        /// <summary>
        /// 获取付款方式
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public HttpResponseMessage GetPaymentType() {

            IEnumerable<PaymentTypeView> model = this._paymentTypeService.GetPaymentTypeViewByAll();
            return ToJson(model);
        }

        #endregion

        #region 采购流程

        [HttpGet]
        public bool PurchaseApply(string id, string operatorId) {

            return this._purchaseOrderService.PurchaseApply(id, operatorId);
        }
        [HttpGet]
        public bool PurchaseApproval(string id, string operatorId) {

            return this._purchaseOrderService.PurchaseApproval(id, operatorId);
        }
        [HttpGet]
        public bool PurchaseReject(string id, string operatorId) {

            return this._purchaseOrderService.PurchaseReject(id, operatorId);
        }


        #endregion

        #region 采购单明细

        /// <summary>
        /// 获取采购明细列表
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public HttpResponseMessage GetPurchaseOrderDetailView(string purchaseOrderId) {

            IEnumerable<PurchaseOrderDetailView> model = this._purchaseOrderService.GetPurchaseOrderDetailView(purchaseOrderId);
            return ToJson(model);
        }

        /// <summary>
        /// 添加采购明细
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public HttpResponseMessage AddPurchaseOrderDetail([FromUri] AddPurchaseOrderDetailRequest request) {

            this._purchaseOrderService.AddPurchaseOrderDetail(request);
            return ToJson("");
        }

        /// <summary>
        /// 添加采购明细
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public HttpResponseMessage RemovePurchaseOrderDetail(string id, int itemid) {

            this._purchaseOrderService.RemovePurchaseOrderDetail(id, itemid);
            return ToJson("");
        }



        #endregion
    }
}
