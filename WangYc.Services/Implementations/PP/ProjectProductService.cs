using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WangYc.Core.Infrastructure.Domain;
using WangYc.Core.Infrastructure.Querying;
using WangYc.Core.Infrastructure.UnitOfWork;
using WangYc.Models.PP;
using WangYc.Models.Repository.PP;
using WangYc.Services.Messaging.PP;
using WangYc.Services.ViewModels.PP;
using WangYc.Services.Mapping.PP;
using WangYc.Services.Interfaces.PP;

namespace WangYc.Services.Implementations.PP {
        public class ProjectProductService : IProjectProductService {

            private readonly IProjectProductRepository _projectProductRepository;
            private readonly IUnitOfWork _uow;
            public ProjectProductService(IProjectProductRepository ProjectProductRepository, IUnitOfWork uow) {

                this._projectProductRepository = ProjectProductRepository;
                this._uow = uow;
            }


            #region 查找

            /// <summary>
            /// 获取项目
            /// </summary>
            /// <returns></returns>
            public IEnumerable<ProjectProduct> GetProjectProduct(Query request) {

                IEnumerable<ProjectProduct> model = this._projectProductRepository.FindBy(request);
                return model;
            }

            /// <summary>
            /// 获取项目视图
            /// </summary>
            /// <returns></returns>
            public IEnumerable<ProjectProductView> GetProjectProductView(Query request) {

                IEnumerable<ProjectProduct> model = _projectProductRepository.FindBy(request);
                return model.ConvertToProjectProductView();
            }
            /// <summary>
            /// 获取所有项目视图
            /// </summary>
            /// <returns></returns>
            public IEnumerable<ProjectProductView> GetProjectProductViewByAll() {

                return this._projectProductRepository.FindAll().ConvertToProjectProductView();

            }

            /// <summary>
            /// 根据项目号获取项目视图
            /// </summary>
            /// <returns></returns>
            public IEnumerable<ProjectProductView> GetProjectProductViewById(int id) {

                Query query = new Query();
                query.Add(Criterion.Create<ProjectProduct>(c => c.Id, id, CriteriaOperator.Equal));
                return this._projectProductRepository.FindBy(query).ConvertToProjectProductView();

            }
            #endregion

            #region 添加

            public void AddProjectProduct(AddProjectProductRequest request) {

                ProjectProduct model = this._projectProductRepository.FindBy(request.Id);
                if (model == null) {
                    throw new EntityIsInvalidException<string>(request.Id.ToString());
                }
                this._projectProductRepository.Add(model);
                this._uow.Commit();
            }

            #endregion

            #region 修改

            public void UpdateProjectProduct(AddProjectProductRequest request) {

                ProjectProduct model = this._projectProductRepository.FindBy(request.Id);
                if (model == null) {
                    throw new EntityIsInvalidException<string>(request.Id.ToString());
                }

                this._projectProductRepository.Save(model);
                this._uow.Commit();
            }

            #endregion

            #region 删除
            public void RemoveProjectProduct(int id) {

                ProjectProduct model = this._projectProductRepository.FindBy(id);
                if (model == null) {
                    throw new EntityIsInvalidException<string>(id.ToString());
                }
                this._projectProductRepository.Remove(model);
                this._uow.Commit();
            }

            #endregion
        }
    }
