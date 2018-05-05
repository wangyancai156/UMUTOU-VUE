using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WangYc.Core.Infrastructure.Querying;
using WangYc.Models.FI;
using WangYc.Services.Messaging.FI;
using WangYc.Services.ViewModels.FI;

namespace WangYc.Services.Interfaces.FI {
     public  interface IPaymentTypeService {

        #region 查找

        /// <summary>
        /// 获取付款类型
        /// </summary>
        /// <returns></returns>
        IEnumerable<PaymentType> GetPaymentType(Query request);

        /// <summary>
        /// 获取付款类型视图
        /// </summary>
        /// <returns></returns>
        IEnumerable<PaymentTypeView> GetPaymentTypeView(Query request);
        /// <summary>
        /// 获取所有付款类型视图
        /// </summary>
        /// <returns></returns>
        IEnumerable<PaymentTypeView> GetPaymentTypeViewByAll();

        /// <summary>
        /// 根据付款类型号获取付款类型视图
        /// </summary>
        /// <returns></returns>
        IEnumerable<PaymentTypeView> GetPaymentTypeViewById(int id);
        #endregion

        #region 添加

        void AddPaymentType(AddPaymentTypeRequest request);

        #endregion

        #region 修改

        void UpdatePaymentType(AddPaymentTypeRequest request);

        #endregion

        #region 删除
        void RemovePaymentType(int id);
        #endregion
    }
}
