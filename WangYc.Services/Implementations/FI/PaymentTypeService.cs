using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WangYc.Core.Infrastructure.Domain;
using WangYc.Core.Infrastructure.Querying;
using WangYc.Core.Infrastructure.UnitOfWork;
using WangYc.Models.FI;
using WangYc.Models.Repository.FI;
using WangYc.Services.Messaging.FI;
using WangYc.Services.ViewModels.FI;
using WangYc.Services.Mapping.FI;
using WangYc.Services.Interfaces.FI;

namespace WangYc.Services.Implementations.FI {
    public class PaymentTypeService : IPaymentTypeService {

        private readonly IPaymentTypeRepository _paymentTypeRepository;
        private readonly IUnitOfWork _uow;
        public PaymentTypeService(IPaymentTypeRepository paymentTypeRepository, IUnitOfWork uow) {

            this._paymentTypeRepository = paymentTypeRepository;
            this._uow = uow;
        }


        #region 查找

        /// <summary>
        /// 获取付款类型
        /// </summary>
        /// <returns></returns>
        public IEnumerable<PaymentType> GetPaymentType(Query request) {

            IEnumerable<PaymentType> model = this._paymentTypeRepository.FindBy(request);
            return model;
        }

        /// <summary>
        /// 获取付款类型视图
        /// </summary>
        /// <returns></returns>
        public IEnumerable<PaymentTypeView> GetPaymentTypeView(Query request) {

            IEnumerable<PaymentType> model = _paymentTypeRepository.FindBy(request);
            return model.ConvertToPaymentTypeView();
        }
        /// <summary>
        /// 获取所有付款类型视图
        /// </summary>
        /// <returns></returns>
        public IEnumerable<PaymentTypeView> GetPaymentTypeViewByAll() {

            return this._paymentTypeRepository.FindAll().ConvertToPaymentTypeView();

        }

        /// <summary>
        /// 根据付款类型号获取付款类型视图
        /// </summary>
        /// <returns></returns>
        public IEnumerable<PaymentTypeView> GetPaymentTypeViewById(int id) {

            Query query = new Query();
            query.Add(Criterion.Create<PaymentType>(c => c.Id, id, CriteriaOperator.Equal));
            return this._paymentTypeRepository.FindBy(query).ConvertToPaymentTypeView();

        }
        #endregion

        #region 添加

        public void AddPaymentType(AddPaymentTypeRequest request) {

            PaymentType model = this._paymentTypeRepository.FindBy(request.Id);
            if (model == null) {
                throw new EntityIsInvalidException<string>(request.Id.ToString());
            }
            this._paymentTypeRepository.Add(model);
            this._uow.Commit();
        }

        #endregion

        #region 修改

        public void UpdatePaymentType(AddPaymentTypeRequest request) {

            PaymentType model = this._paymentTypeRepository.FindBy(request.Id);
            if (model == null) {
                throw new EntityIsInvalidException<string>(request.Id.ToString());
            }
           
            this._paymentTypeRepository.Save(model);
            this._uow.Commit();
        }

        #endregion

        #region 删除
        public void RemovePaymentType(int id) {

            PaymentType model = this._paymentTypeRepository.FindBy(id);
            if (model == null) {
                throw new EntityIsInvalidException<string>(id.ToString());
            }
            this._paymentTypeRepository.Remove(model);
            this._uow.Commit();
        }

        #endregion
    }
}
