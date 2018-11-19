using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WangYc.Core.Infrastructure.Domain;
using WangYc.Core.Infrastructure.Querying;
using WangYc.Services.Messaging.PO;
using WangYc.Services.ViewModels.PO;

namespace WangYc.Services.Interfaces.PO {
    public interface IPurchaseOrderService {

        #region 查找

        /// <summary>
        /// 获取采购单视图
        /// </summary>
        /// <returns></returns>
        PurchaseOrderView GetPurchaseOrderViewById(string id);
        /// <summary>
        /// 获取采购单视图列表
        /// </summary>
        /// <returns></returns>
        IEnumerable<PurchaseOrderView> GetPurchaseOrderView(Query request);

        /// <summary>
        /// 根据状态获取采购单视图
        /// </summary>
        /// <returns></returns>
        ListPaged<PurchaseOrderView> GetPurchaseOrderViewByStatus(GetPurchaseOrderRequest request);
        /// <summary>
        /// 获取已经处理过的采购单
        /// </summary>
        /// <param name="purchaseOrderId"></param>
        /// <returns></returns>
        ListPaged<PurchaseOrderView> GetPurchaseOrderViewHaveStatus(GetPurchaseOrderRequest request);
        /// <summary>
        /// 获取采购明细列表
        /// </summary>
        /// <param name="purchaseOrderId"></param>
        /// <returns></returns>
        IEnumerable<PurchaseOrderDetailView> GetPurchaseOrderDetailView(string purchaseOrderId);
        #endregion

        #region 添加

        void AddPurchaseOrder(AddPurchaseOrderRequest request);

        void AddPurchaseOrderDetail(AddPurchaseOrderDetailRequest request);

        #endregion

        #region 修改

        void UpdatePurchaseOrder(AddPurchaseOrderRequest request);

        bool PurchaseApply(string id, string operatorId);

        bool PurchaseApproval(string id, string operatorId);

        bool PurchaseReject(string id, string operatorId);

            #endregion

        #region 删除
        void RemovePurchaseOrder(string [] id);

        void RemovePurchaseOrderDetail(string id, int itemid);

        #endregion
    }
}
