using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WangYc.Core.Infrastructure.Querying;
using WangYc.Core.Infrastructure.UnitOfWork;
using WangYc.Models.BW;
using WangYc.Models.Repository.BW;
using WangYc.Models.Repository.PO;
using WangYc.Services.Interfaces.Common;
using WangYc.Services.ViewModels.BW;
using WangYc.Services.Mapping.BW;
using WangYc.Services.Messaging.BW;
using WangYc.Core.Infrastructure.Domain;
using WangYc.Services.Interfaces.BW;

namespace WangYc.Services.Implementations.BW {
    public  class WaitArrivalService : IWaitArrivalService {

        private readonly IWaitArrivalRepository _waitArrivalRepository;
        private readonly IPurchaseOrderDetailRepository _purchaseOrderDetailRepository;
        private readonly IWorkflowActivityService _workflowActivityService;
        private readonly IUnitOfWork _uow;

        public WaitArrivalService(
            IWaitArrivalRepository waitArrivalRepository,
            IPurchaseOrderDetailRepository purchaseOrderDetailRepository,
            IWorkflowActivityService workflowActivityService,
            IUnitOfWork uow
        ) {

            this._waitArrivalRepository = waitArrivalRepository;
            this._purchaseOrderDetailRepository = purchaseOrderDetailRepository;
            this._workflowActivityService = workflowActivityService;
            this._uow = uow;
        }


        #region 到货单

        #region 查找

        /// <summary>
        /// 获取待到货单
        /// </summary>
        /// <returns></returns>
        public WaitArrival GetWaitArrival(int id) {

            return this._waitArrivalRepository.FindBy(id);
        }
 
        /// <summary>
        /// 获取待到货单
        /// </summary>
        /// <returns></returns>
        public IEnumerable<WaitArrival> GetWaitArrival(Query request) {

            IEnumerable<WaitArrival> model = this._waitArrivalRepository.FindBy(request);
            return model;
        }



        /// <summary>
        /// 通过id获取所有库房视图
        /// </summary>
        /// <returns></returns>
        public WaitArrivalView GetWaitArrivalView(int id) {

            return GetWaitArrival(id).ConvertToWaitArrivalView();
        }
        /// <summary>
        /// 获取库房视图
        /// </summary>
        /// <returns></returns>
        public IEnumerable<WaitArrivalView> GetWaitArrivalView(Query request) {

            IEnumerable<WaitArrival> model = this._waitArrivalRepository.FindBy(request);
            return model.ConvertToWaitArrivalView();
        }

        


        #endregion

        #region 添加

        #endregion

        #region 修改

        /// <summary>
        /// 修改库房
        /// </summary>
        /// <param name="request"></param>
        public void UpdateWaitArrival(AddWaitArrivalRequest request) {

            WaitArrival model = this._waitArrivalRepository.FindBy(request.Id);

            if (model == null) {
                throw new EntityIsInvalidException<string>(request.Id.ToString());
            }
            this._waitArrivalRepository.Save(model);
            this._uow.Commit();
        }

        #endregion

        #region 删除
        /// <summary>
        /// 删除库房
        /// </summary>
        /// <param name="id"></param>
        public void RemoveWaitArrival(int id) {

            WaitArrival model = this._waitArrivalRepository.FindBy(id);

            if (model == null) {
                throw new EntityIsInvalidException<string>(id.ToString());
            }
            model.IsValid = false;
            this._waitArrivalRepository.Save(model);
            this._uow.Commit();
        }
        #endregion
        #endregion

 
    }
}
