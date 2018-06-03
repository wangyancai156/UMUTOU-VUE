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
    public interface IInOutReasonService {


        #region 查找

        /// <summary>
        /// 获取项目
        /// </summary>
        /// <returns></returns>
        InOutReason GetInOutReason( int id);
        /// <summary>
        /// 获取项目
        /// </summary>
        /// <returns></returns>
        IEnumerable<InOutReason> GetInOutReason(Query request);

        /// <summary>
        /// 获取项目视图
        /// </summary>
        /// <returns></returns>
        IEnumerable<InOutReasonView> GetInOutReasonView(Query request);
        /// <summary>
        /// 获取所有项目视图
        /// </summary>
        /// <returns></returns>
        IEnumerable<InOutReasonView> GetInOutReasonView(int type);

        /// <summary>
        /// 根据项目号获取项目视图
        /// </summary>
        /// <returns></returns>
        IEnumerable<InOutReasonView> GetInOutReasonViewById(int id);
        #endregion

        #region 添加

        void AddInOutReason(AddInOutReasonRequest request);

        #endregion

        #region 修改

        void UpdateInOutReason(AddInOutReasonRequest request);

        #endregion

        #region 删除
        void RemoveInOutReason(int id);

        #endregion
    }
}
