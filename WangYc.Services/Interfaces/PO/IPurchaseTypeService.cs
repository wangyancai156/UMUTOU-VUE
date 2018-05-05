using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WangYc.Core.Infrastructure.Querying;
using WangYc.Services.Messaging.PO;
using WangYc.Services.ViewModels.PO;

namespace WangYc.Services.Interfaces.PO {
    public interface IPurchaseTypeService {

        #region 查找

        /// <summary>
        /// 获取采购单类型视图
        /// </summary>
        /// <returns></returns>
        IEnumerable<PurchaseTypeView> GetPurchaseTypeView(Query request);
        /// <summary>
        /// 获取所有采购单类型视图
        /// </summary>
        /// <returns></returns>
        IEnumerable<PurchaseTypeView> GetPurchaseTypeViewByAll();

        /// <summary>
        /// 根据采购单类型号获取采购单类型视图
        /// </summary>
        /// <returns></returns>
        IEnumerable<PurchaseTypeView> GetPurchaseTypeViewById(int id);
        #endregion

        #region 添加

        void AddPurchaseType(AddPurchaseTypeRequest request);

        #endregion

        #region 修改

        void UpdatePurchaseType(AddPurchaseTypeRequest request);

        #endregion

        #region 删除
        void RemovePurchaseType(int id);

        #endregion

    }
}
