using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WangYc.Core.Infrastructure.Querying;
using WangYc.Models.PO;
using WangYc.Services.Messaging.PO;
using WangYc.Services.ViewModels.PO;

namespace WangYc.Services.Interfaces.PO {
    public interface IPurchaseOrderDetailService {

        #region 查找

        /// <summary>
        /// 获取项目
        /// </summary>
        /// <returns></returns>
        IEnumerable<PurchaseOrderDetail> GetPurchaseOrderDetailBy(Query request);

        /// <summary>
        /// 获取项目视图
        /// </summary>
        /// <returns></returns>
        IEnumerable<PurchaseOrderDetailView> GetPurchaseOrderDetailViewBy(Query request);

        /// <summary>
        /// 根据项目号获取项目视图
        /// </summary>
        /// <returns></returns>
        IEnumerable<PurchaseOrderDetailView> GetPurchaseOrderDetailViewByPurchaseOrderId(string purchaseOrderId);

        #endregion

        #region 添加

        void AddPurchaseOrderDetail(AddPurchaseOrderDetailRequest request);

        #endregion

        #region 修改

        void UpdatePurchaseOrderDetail(AddPurchaseOrderDetailRequest request);

        #endregion

        #region 删除
        void RemovePurchaseOrderDetail(int id);

        #endregion
    }
}
