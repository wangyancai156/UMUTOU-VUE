using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WangYc.Core.Infrastructure.Domain;
using WangYc.Core.Infrastructure.Querying;
using WangYc.Core.Infrastructure.UnitOfWork;
using WangYc.Models.BW;
using WangYc.Models.Repository.BW;
using WangYc.Services.Messaging.BW;
using WangYc.Services.ViewModels.BW;
using WangYc.Services.Mapping.BW;
using WangYc.Services.Interfaces.BW;

namespace WangYc.Services.Implementations.BW {

 
        public class InOutReasonService : IInOutReasonService {

            private readonly IInOutReasonRepository _inOutReasonRepository;
            private readonly IUnitOfWork _uow;
            public InOutReasonService(IInOutReasonRepository InOutReasonRepository, IUnitOfWork uow) {

                this._inOutReasonRepository = InOutReasonRepository;
                this._uow = uow;
            }


            #region 查找

            /// <summary>
            /// 获取项目
            /// </summary>
            /// <returns></returns>
            public IEnumerable<InOutReason> GetInOutReason(Query request) {

                IEnumerable<InOutReason> model = this._inOutReasonRepository.FindBy(request);
                return model;
            }

            /// <summary>
            /// 获取项目视图
            /// </summary>
            /// <returns></returns>
            public IEnumerable<InOutReasonView> GetInOutReasonView(Query request) {

                IEnumerable<InOutReason> model = _inOutReasonRepository.FindBy(request);
                return model.ConvertToInOutReasonView();
            }
            /// <summary>
            /// 获取所有项目视图
            /// </summary>
            /// <returns></returns>
            public IEnumerable<InOutReasonView> GetInOutReasonViewByAll() {

                return this._inOutReasonRepository.FindAll().ConvertToInOutReasonView();

            }

            /// <summary>
            /// 根据项目号获取项目视图
            /// </summary>
            /// <returns></returns>
            public IEnumerable<InOutReasonView> GetInOutReasonViewById(int id) {

                Query query = new Query();
                query.Add(Criterion.Create<InOutReason>(c => c.Id, id, CriteriaOperator.Equal));
                return this._inOutReasonRepository.FindBy(query).ConvertToInOutReasonView();

            }
            #endregion

            #region 添加

            public void AddInOutReason(AddInOutReasonRequest request) {

                InOutReason model = this._inOutReasonRepository.FindBy(request.Id);
                if (model == null) {
                    throw new EntityIsInvalidException<string>(request.Id.ToString());
                }
                this._inOutReasonRepository.Add(model);
                this._uow.Commit();
            }

            #endregion

            #region 修改

            public void UpdateInOutReason(AddInOutReasonRequest request) {

                InOutReason model = this._inOutReasonRepository.FindBy(request.Id);
                if (model == null) {
                    throw new EntityIsInvalidException<string>(request.Id.ToString());
                }

                this._inOutReasonRepository.Save(model);
                this._uow.Commit();
            }

            #endregion

            #region 删除
            public void RemoveInOutReason(int id) {

                InOutReason model = this._inOutReasonRepository.FindBy(id);
                if (model == null) {
                    throw new EntityIsInvalidException<string>(id.ToString());
                }
                this._inOutReasonRepository.Remove(model);
                this._uow.Commit();
            }

            #endregion
        }
    }
