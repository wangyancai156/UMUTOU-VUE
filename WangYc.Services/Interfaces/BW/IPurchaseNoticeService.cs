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
   public interface IPurchaseNoticeService {



        #region 查找

        /// <summary>
        /// 获取待到货单
        /// </summary>
        /// <returns></returns>
        PurchaseNoticeDetail GetPurchaseNotice(int id);

        /// <summary>
        /// 获取待到货单
        /// </summary>
        /// <returns></returns>
        IEnumerable<PurchaseNoticeDetail> GetPurchaseNotice(Query request);

        /// <summary>
        /// 通过id获取待到货单
        /// </summary>
        /// <returns></returns>
        PurchaseNoticeView GetPurchaseNoticeView(int id);
        /// <summary>
        /// 获取到货单
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        ListPaged<PurchaseNoticeView> GetPurchaseOrderViewByStatus(GePurchaseNoticeRequest request);

        #endregion

        #region 添加

        bool AddPurchaseReceipt(AddPurchaseReceiptDetailRequest request);

        #endregion

        #region 修改

        /// <summary>
        /// 修改库房
        /// </summary>
        /// <param name="request"></param>
        void UpdatePurchaseNotice(AddPurchaseNoticeRequest request);

        #endregion

        #region 删除
        /// <summary>
        /// 删除库房
        /// </summary>
        /// <param name="id"></param>
        void RemovePurchaseNotice(int id);
        #endregion

    }
}
