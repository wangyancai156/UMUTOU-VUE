using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WangYc.Core.Infrastructure.Domain;
using WangYc.Core.Infrastructure.Querying;
using WangYc.Models.BW;
using WangYc.Services.Messaging.BW;
using WangYc.Services.ViewModels.BW;

namespace WangYc.Services.Interfaces.BW {
    public interface IPurchaseReceiptService {

        #region 到货单

        #region 查找

        /// <summary>
        /// 获取到货单
        /// </summary>
        /// <returns></returns>
        PurchaseReceipt GetPurchaseReceipt(int id);

        /// <summary>
        /// 获取到货单
        /// </summary>
        /// <returns></returns>
        IEnumerable<PurchaseReceipt> GetPurchaseReceipt(Query request);

        /// <summary>
        /// 通过id获取所有库房视图
        /// </summary>
        /// <returns></returns>
        PurchaseReceiptView GetPurchaseReceiptView(int id);
        /// <summary>
        /// 获取库房视图
        /// </summary>
        /// <returns></returns>
        IEnumerable<PurchaseReceiptView> GetPurchaseReceiptView(Query request);

        /// <summary>
        /// 获取所有库房视图
        /// </summary>
        /// <returns></returns>
        ListPaged<PurchaseReceiptView> GetPurchaseReceiptView(int pageIndex, int pageSize, string sort);

        #endregion

        #region 添加

        /// <summary>
        ///添加库房
        /// </summary>
        /// <param name="request"></param>
        PurchaseReceipt AddPurchaseReceipt(AddPurchaseReceiptRequest request);

        void AddPurchaseReceiptDetail(AddPurchaseReceiptDetailRequest request);

        #endregion

        #region 修改

        /// <summary>
        /// 修改库房
        /// </summary>
        /// <param name="request"></param>
        void UpdatePurchaseReceipt(AddPurchaseReceiptRequest request);

        #endregion

        #region 删除
        /// <summary>
        /// 删除库房
        /// </summary>
        /// <param name="id"></param>
        void RemovePurchaseReceipt(int id);
        #endregion
        #endregion

        #region 到货单明细

        #region 查找

        /// <summary>
        /// 获取到到货单明细
        /// </summary>
        /// <returns></returns>
        PurchaseReceiptDetail GetPurchaseReceiptDetailt(int id);
        /// <summary>
        /// 获取到货单明细视图
        /// </summary>
        /// <returns></returns>
        IEnumerable<PurchaseReceiptDetailView> GetPurchaseReceiptDetailView(Query request);

        ListPaged<PurchaseReceiptDetailView> GetPurchaseReceiptDetailView(string purchaseId, int pageIndex, int pageSize, string sort);
        
        #endregion

        #region 修改

        /// <summary>
        /// 修改库房
        /// </summary>
        /// <param name="request"></param>
        void UpdatePurchaseDetailReceipt(AddPurchaseReceiptDetailRequest request);

        #endregion

        #region 删除
        /// <summary>
        /// 删除库房
        /// </summary>
        /// <param name="id"></param>
        void RemovePurchaseReceiptDetail(int id);
        #endregion

        #endregion
    }
}
