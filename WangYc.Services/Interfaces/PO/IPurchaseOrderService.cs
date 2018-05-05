using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
        IEnumerable<PurchaseOrderView> GetPurchaseOrderView(Query request);
        /// <summary>
        /// 获取所有采购单视图
        /// </summary>
        /// <returns></returns>
        IEnumerable<PurchaseOrderView> GetPurchaseOrderViewByAll();

        /// <summary>
        /// 根据采购单号获取采购单视图
        /// </summary>
        /// <returns></returns>
        IEnumerable<PurchaseOrderView> GetPurchaseOrderViewById(int id);
        #endregion

        #region 添加

        void AddPurchaseOrder(AddPurchaseOrderRequest request);

        void AddPurchaseOrderDetail(AddPurchaseOrderDetailRequest request);

        #endregion

        #region 修改

        void UpdatePurchaseOrder(AddPurchaseOrderRequest request);
        #endregion

        #region 删除
        void RemovePurchaseOrder(int id);

        #endregion
    }
}
