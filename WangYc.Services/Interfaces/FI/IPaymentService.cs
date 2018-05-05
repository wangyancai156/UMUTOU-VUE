using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WangYc.Core.Infrastructure.Querying;
using WangYc.Services.Messaging.FI;
using WangYc.Services.ViewModels.FI;

namespace WangYc.Services.Interfaces.FI {
      public interface IPaymentService {


        #region 查找

        
        /// <summary>
        /// 获取付款类型视图
        /// </summary>
        /// <returns></returns>
        IEnumerable<PaymentView> GetPaymentView(Query request);
        /// <summary>
        /// 获取所有付款类型视图
        /// </summary>
        /// <returns></returns>
        IEnumerable<PaymentView> GetPaymentViewByAll();

        /// <summary>
        /// 根据付款类型号获取付款类型视图
        /// </summary>
        /// <returns></returns>
        IEnumerable<PaymentView> GetPaymentViewById(int id);
        #endregion

        #region 添加

        void AddPayment(AddPaymentRequest request);

        #endregion

        #region 修改

        void UpdatePayment(AddPaymentRequest request);

        #endregion

        #region 删除
        void RemovePayment(int id);
        #endregion
    }
}
