using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using WangYc.Core.Infrastructure.Domain;

namespace WangYc.Models.HR {
    /// <summary>
    /// Roles:实体类(属性说明自动提取数据库字段的描述信息)
    /// </summary>

    public class Role : EntityBase<int>, IAggregateRoot {

        #region Model

        public Role() { }

        public Role(Organization organization, string name, string description) {

            this.Organization = organization;
            this.Name = name;
            this.Description = description;
            this.CreateDate = DateTime.Now;
            this.IsValid = true;
        }

        /// <summary>
        /// 名称
        /// </summary>
        public virtual string Name { set; get; }
        /// <summary>
        /// 描述
        /// </summary>
        public virtual string Description { set; get; }
        /// <summary>
        /// 创建时间
        /// </summary>
        public virtual DateTime CreateDate { set; get; }
        /// <summary>
        /// 是否有效
        /// </summary>
        public virtual bool IsValid { get; set; }
        ///// <summary>
        ///// 组织
        ///// </summary>
        public virtual Organization Organization {
            get;
            set;
        }
        /// <summary>
        /// 权限
        /// </summary>
        public virtual IList<Rights> Rights { set; get; }

        public virtual IList<int> RightsList {
            get {
                IList<int> result = new List<int>();
                foreach (Rights one in this.Rights) {
                    foreach (int two in one.RightsList) {
                        if (!result.Contains(two)) {
                            result.Add(two);
                        }
                    }
                }
                return result;
            }
        }

        #endregion Model

        /// <summary>修改角色
        /// 修改角色
        /// </summary>
        /// <param name="name"></param>
        /// <param name="description"></param>
        public virtual void UpdateRole(string name, string description) {

            this.Name = name;
            this.Description = description;
        }

        /// <summary>添加权限
        /// 添加权限
        /// </summary>
        /// <param name="rights"></param>
        public virtual void AddRights(IEnumerable<Rights> rightsList) {

            if (Rights == null) {
                Rights = new List<Rights>();
            }

            foreach (Rights rights in rightsList) {
                Rights.Add(rights);
            }
        }

        public virtual void CancelRigths(string[] rightid) {

            int[] ids = Array.ConvertAll<string, int>(rightid, s => int.Parse(s));
            IEnumerable<Rights> rights = this.Rights.Where(s => ids.Contains(s.Id));

            for (int i = this.Rights.Count - 1; i > -1; i--) {

                if (ids.Contains(this.Rights[i].Id)) {
                    this.Rights.Remove(this.Rights[i]);
                }
            }
        }


        protected override void Validate() {
            throw new NotImplementedException();
        }
    }
}

