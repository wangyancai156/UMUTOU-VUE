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
   public interface IArrivalNoticeService {



        #region 查找

        /// <summary>
        /// 获取待到货单
        /// </summary>
        /// <returns></returns>
        ArrivalNoticeDetail GetArrivalNotice(int id);

        /// <summary>
        /// 获取待到货单
        /// </summary>
        /// <returns></returns>
        IEnumerable<ArrivalNoticeDetail> GetArrivalNotice(Query request);

        /// <summary>
        /// 通过id获取待到货单
        /// </summary>
        /// <returns></returns>
        ArrivalNoticeView GetArrivalNoticeView(int id);
        /// <summary>
        /// 获取到货单
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        ListPaged<ArrivalNoticeView> GetPurchaseOrderViewByStatus(GeArrivalNoticeRequest request);

        #endregion

        #region 添加

        bool AddPurchaseReceipt(AddPurchaseReceiptDetailRequest request);

        #endregion

        #region 修改

        /// <summary>
        /// 修改库房
        /// </summary>
        /// <param name="request"></param>
        void UpdateArrivalNoticeDetail(AddArrivalNoticeDetailRequest request);

        #endregion

        #region 删除
        /// <summary>
        /// 删除库房
        /// </summary>
        /// <param name="id"></param>
        void RemoveArrivalNoticeDetail(int id);
        #endregion

    }
}
