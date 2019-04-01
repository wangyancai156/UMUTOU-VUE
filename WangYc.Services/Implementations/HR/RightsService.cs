using System.Collections.Generic;

using WangYc.Core.Infrastructure.Querying;
using WangYc.Core.Infrastructure.UnitOfWork;

using WangYc.Models.HR;
using WangYc.Models.Repository.HR;

using WangYc.Repository.NHibernate.Repositories.HR;
using WangYc.Repository.NHibernate;

using WangYc.Services.Mapping.HR;
using WangYc.Services.ViewModels.HR;
using WangYc.Services.Interfaces.HR;
using WangYc.Core.Infrastructure.Domain;
using WangYc.Services.ViewModels;
using WangYc.Services.Messaging.HR;
using System;

namespace WangYc.Services.Implementations.HR {
    public class RightsService : IRightsService {
        private readonly IRightsRepository _rightsRepository;
        private readonly IUsersRepository _usersRepository;
        private readonly IUnitOfWork _uow;

        public RightsService(IRightsRepository rightsRepository, IUsersRepository usersRepository, IUnitOfWork uow) {
            this._rightsRepository = rightsRepository;
            this._usersRepository = usersRepository;
            this._uow = uow;

        }

        #region 查询

        #region 查询对象
       
        /// <summary>
        /// 根据ID获取功能
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Rights GetRights(int id) {

            return this._rightsRepository.FindBy(id);
        }
        /// <summary>
        /// 根据ID数据获取功能列表
        /// </summary>
        /// <param name="rightsIdList"></param>
        /// <returns></returns>
        public IEnumerable<Rights> GetRights(string[] rightsIdList) {

            int[] ids = Array.ConvertAll<string, int>(rightsIdList, s => int.Parse(s));
            Query query = new Query();
            if (rightsIdList != null)
                query.Add(Criterion.Create<Rights>(p => p.Id, ids, CriteriaOperator.InOfInt32));

            IEnumerable<Rights> rights = this._rightsRepository.FindBy(query);
            return rights;
        }
        #endregion

        #region 查询视图

        /// <summary>
        /// 根据Id获取功能视图
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public RightsView GetRightsView(int id) {

            return this.GetRights(id).ConvertToRightsView();
        }

        /// <summary>
        /// 根据Id获取
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public IEnumerable<RightsView> GetRightsIsLeafView(int id) {

            RightsView model = this.GetRights(id).ConvertToRightsView();

            if (model == null) {
                throw new EntityIsInvalidException<string>(id.ToString());
            }
            return ForeachChild(model, true);
        }

        /// <summary>
        /// 根据Id和权限ID获取权限没有的功能
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public IEnumerable<RightsView> GetRightsIsLeafView(int id, int roleid) {

            RightsView model = this.GetRights(id).ConvertToRightsView();

            if (model == null) {
                throw new EntityIsInvalidException<string>(id.ToString());
            }
            return ForeachChild(model, true);
        }

        private IList<RightsView> ForeachChild(RightsView model, bool isleaf) {

            IList<RightsView> reslut = new List<RightsView>();
            foreach (RightsView item in model.Child) {

                if (item.IsLeaf) {
                    reslut.Add(item);
                } else {
                    IList<RightsView> child = ForeachChild(item, isleaf);
                    foreach (RightsView childitem in child) {
                        reslut.Add(childitem);
                    }
                }
            }
            return reslut;
        }

        public IEnumerable<RightsView> GetRightsViewByRole(int roleid) {

            Query query = new Query();
            query.Add(new Criterion("fndbyroleid", roleid, CriteriaOperator.Equal));
            IEnumerable<Rights> rights = _rightsRepository.FindBy(query);
            return rights.ConvertToRightsView();
        }
        #endregion

        #region 查询树
        /// <summary>
        /// 获取功能树视图
        /// </summary>
        /// <returns></returns>
        public IList<DataTree> GetRightsTreeView() {

            Query query = new Query();
            query.Add(Criterion.Create<Rights>(c => c.Parent, null, CriteriaOperator.IsNull));
            IEnumerable<Rights> rights = _rightsRepository.FindBy(query);
            return rights.ConvertToDataTreeView();
        }
        
        /// <summary>
        /// 获取用户的功能
        /// </summary>
        /// <returns></returns>
        public IList<Menu> GetMenuView( string userid ) {

            Users user = this._usersRepository.FindBy(userid);
            Query query = new Query();
            query.Add(Criterion.Create<Rights>(c => c.Parent, null, CriteriaOperator.IsNull));
            IEnumerable<Rights> rights = _rightsRepository.FindBy(query);
            return rights.ConvertToDataMenuView(user);
        }




        #endregion

        #endregion

        #region 添加

        public RightsView AddRights(AddRightsRequest request) {

            Rights rights = this._rightsRepository.FindBy(request.ParentId);
            if (rights == null) {
                throw new EntityIsInvalidException<string>(request.ParentId.ToString());
            }

            Rights result = rights.AddChild(request.Name, request.Url, request.Description, request.IsShow, request.Icon);
            this._uow.Commit();
            return result.ConvertToRightsView();
        }


        #endregion

        #region 修改

        public RightsView UpdateRights(int id, string name,string url, string description, bool isshow) {

            Rights rights = this._rightsRepository.FindBy(id);
            if (rights == null) {
                throw new EntityIsInvalidException<string>(rights.ToString());
            }

            rights.UpdateRights(name, url, description, isshow);
            this._uow.Commit();
            return rights.ConvertToRightsView();
        }

        #endregion

        #region 删除

        public void DeleteRights(int id) {

            Rights rights = this._rightsRepository.FindBy(id);
            if (rights == null) {
                throw new EntityIsInvalidException<string>(rights.ToString());
            }
            this._rightsRepository.Remove(rights);
            this._uow.Commit();
        }
        #endregion

    }
}
