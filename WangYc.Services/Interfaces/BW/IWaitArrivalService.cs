using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WangYc.Core.Infrastructure.Querying;
using WangYc.Models.BW;
using WangYc.Services.Messaging.BW;
using WangYc.Services.ViewModels.BW;

namespace WangYc.Services.Interfaces.BW {
   public interface IWaitArrivalService {



        #region 查找

        /// <summary>
        /// 获取待到货单
        /// </summary>
        /// <returns></returns>
        WaitArrival GetWaitArrival(int id);

        /// <summary>
        /// 获取待到货单
        /// </summary>
        /// <returns></returns>
        IEnumerable<WaitArrival> GetWaitArrival(Query request);



        /// <summary>
        /// 通过id获取所有库房视图
        /// </summary>
        /// <returns></returns>
        WaitArrivalView GetWaitArrivalView(int id);
        /// <summary>
        /// 获取库房视图
        /// </summary>
        /// <returns></returns>
        IEnumerable<WaitArrivalView> GetWaitArrivalView(Query request);




        #endregion

        #region 添加

        #endregion

        #region 修改

        /// <summary>
        /// 修改库房
        /// </summary>
        /// <param name="request"></param>
        void UpdateWaitArrival(AddWaitArrivalRequest request);

        #endregion

        #region 删除
        /// <summary>
        /// 删除库房
        /// </summary>
        /// <param name="id"></param>
        void RemoveWaitArrival(int id);
        #endregion

    }
}
