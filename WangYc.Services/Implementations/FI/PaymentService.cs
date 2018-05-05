using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WangYc.Core.Infrastructure.Querying;
using WangYc.Core.Infrastructure.UnitOfWork;
using WangYc.Models.FI;
using WangYc.Models.Repository.FI;
using WangYc.Services.ViewModels.FI;
using WangYc.Services.Mapping.FI;
using WangYc.Core.Infrastructure.Domain;
using WangYc.Services.Messaging.FI;
using WangYc.Services.Interfaces.FI;

namespace WangYc.Services.Implementations.FI {
    public class PaymentService  : IPaymentService {

        private readonly IPaymentRepository _paymentRepository;
        private readonly IUnitOfWork _uow;
        public PaymentService(IPaymentRepository paymentRepository, IUnitOfWork uow) {

            this._paymentRepository = paymentRepository;
            this._uow = uow;
        }


        #region 查找

        /// <summary>
        /// 获取付款类型
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Payment> GetPayment(Query request) {

            IEnumerable<Payment> model = this._paymentRepository.FindBy(request);
            return model;
        }

        /// <summary>
        /// 获取付款类型视图
        /// </summary>
        /// <returns></returns>
        public IEnumerable<PaymentView> GetPaymentView(Query request) {

            IEnumerable<Payment> model = _paymentRepository.FindBy(request);
            return model.ConvertToPaymentView();
        }
        /// <summary>
        /// 获取所有付款类型视图
        /// </summary>
        /// <returns></returns>
        public IEnumerable<PaymentView> GetPaymentViewByAll() {

            return this._paymentRepository.FindAll().ConvertToPaymentView();

        }

        /// <summary>
        /// 根据付款类型号获取付款类型视图
        /// </summary>
        /// <returns></returns>
        public IEnumerable<PaymentView> GetPaymentViewById(int id) {

            Query query = new Query();
            query.Add(Criterion.Create<Payment>(c => c.Id, id, CriteriaOperator.Equal));
            return this._paymentRepository.FindBy(query).ConvertToPaymentView();

        }
        #endregion

        #region 添加

        public void AddPayment(AddPaymentRequest request) {

            Payment model = this._paymentRepository.FindBy(request.Id);
            if (model == null) {
                throw new EntityIsInvalidException<string>(request.Id.ToString());
            }
            this._paymentRepository.Add(model);
            this._uow.Commit();
        }

        #endregion

        #region 修改

        public void UpdatePayment(AddPaymentRequest request) {

            Payment model = this._paymentRepository.FindBy(request.Id);
            if (model == null) {
                throw new EntityIsInvalidException<string>(request.Id.ToString());
            }

            this._paymentRepository.Save(model);
            this._uow.Commit();
        }

        #endregion

        #region 删除
        public void RemovePayment(int id) {

            Payment model = this._paymentRepository.FindBy(id);
            if (model == null) {
                throw new EntityIsInvalidException<string>(id.ToString());
            }
            this._paymentRepository.Remove(model);
            this._uow.Commit();
        }

        #endregion
    }
}
