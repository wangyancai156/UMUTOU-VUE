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
        /// 根据状态获取采购单视图
        /// </summary>
        /// <returns></returns>
        ListPaged<ArrivalNoticeView> GetArrivalNoticePageView(GeArrivalNoticeRequest request);
         
        /// <summary>
        /// 通过id获取所有库房视图
        /// </summary>
        /// <returns></returns>
        ArrivalNoticeDetailView GetArrivalNoticeDetailView(int id);
      

        #endregion

        #region 添加

        bool AddArrivalReceiptDetail(AddArrivalReceiptDetailRequest request);

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
