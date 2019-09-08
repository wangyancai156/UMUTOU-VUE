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
    public interface IArrivalReceiptService {

        #region 到货单

        #region 查找

        /// <summary>
        /// 获取到货单
        /// </summary>
        /// <returns></returns>
        ArrivalReceipt GetArrivalReceipt(int id);

        /// <summary>
        /// 获取到货单
        /// </summary>
        /// <returns></returns>
        IEnumerable<ArrivalReceipt> GetArrivalReceipt(Query request);

        /// <summary>
        /// 通过id获取所有库房视图
        /// </summary>
        /// <returns></returns>
        ArrivalReceiptView GetArrivalReceiptView(int id);
        /// <summary>
        /// 获取库房视图
        /// </summary>
        /// <returns></returns>
        IEnumerable<ArrivalReceiptView> GetArrivalReceiptView(Query request);

        /// <summary>
        /// 获取所有库房视图
        /// </summary>
        /// <returns></returns>
        ListPaged<ArrivalReceiptView> GetArrivalReceiptView(int pageIndex, int pageSize, string sort);

        #endregion

        #region 添加

        /// <summary>
        ///添加库房
        /// </summary>
        /// <param name="request"></param>
        ArrivalReceipt AddArrivalReceipt(AddArrivalReceiptRequest request);

        void AddArrivalReceiptDetail(AddArrivalReceiptDetailRequest request);

        #endregion

        #region 修改

        /// <summary>
        /// 修改库房
        /// </summary>
        /// <param name="request"></param>
        void UpdateArrivalReceipt(AddArrivalReceiptRequest request);

        #endregion

        #region 删除
        /// <summary>
        /// 删除库房
        /// </summary>
        /// <param name="id"></param>
        void RemoveArrivalReceipt(int id);
        #endregion
        #endregion

        #region 到货单明细

        #region 查找

        /// <summary>
        /// 获取到到货单明细
        /// </summary>
        /// <returns></returns>
        ArrivalReceiptDetail GetArrivalReceiptDetailt(int id);
        /// <summary>
        /// 获取到货单明细视图
        /// </summary>
        /// <returns></returns>
        IEnumerable<ArrivalReceiptDetailView> GetArrivalReceiptDetailView(Query request);

        ListPaged<ArrivalReceiptDetailView> GetArrivalReceiptDetailView(string purchaseId, int pageIndex, int pageSize, string sort);
        
        #endregion

        #region 修改

        /// <summary>
        /// 修改库房
        /// </summary>
        /// <param name="request"></param>
        void UpdatePurchaseDetailReceipt(AddArrivalReceiptDetailRequest request);

        #endregion

        #region 删除
        /// <summary>
        /// 删除库房
        /// </summary>
        /// <param name="id"></param>
        void RemoveArrivalReceiptDetail(int id);
        #endregion

        #endregion
    }
}
