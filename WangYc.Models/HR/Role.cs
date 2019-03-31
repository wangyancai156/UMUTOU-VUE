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

        public Role(Role parent, string name, string description) {

            this.Parent = parent;
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
        /// 父节点
        /// </summary>
        public virtual Role Parent { set; get; }
        /// <summary>
        /// 子节点
        /// </summary>
        public virtual IList<Role> Child { get; set; }
        /// <summary>
        /// 是否有效
        /// </summary>
        public virtual bool IsValid { get; set; }

        /// <summary>
        /// 权限
        /// </summary>
        public virtual IList<Rights> Rights { set; get; }

        //获取权限的功能
        public virtual List<int> RightsId {
            get {
                List<int> result = new List<int>();
                if (this.Rights != null) {
                    foreach (Rights one in this.Rights) {
                        result.Add(one.Id);
                    }
                }
                return result;
            }
        }
        //获取权限的功能（包括功能的父节点）
        public virtual List<int> RightsIdContainParent {
            get {
                List<int> result = new List<int>();
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

        /// <summary>
        /// 添加
        /// </summary>
        /// <param name="name"></param>
        /// <param name="descriptin"></param>
        /// <returns></returns>
        public virtual Role AddChild(string name, string descriptin) {

            Role role = new Role(this, name, descriptin);
            if (Child == null) {
                Child = new List<Role>();
                Child.Add(role);
            } else {
                Child.Add(role);
            }
            return role;
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
                if (rights.IsLeaf) {
                    Rights.Add(rights);
                }
            }
        }


        protected override void Validate() {
            throw new NotImplementedException();
        }
    }
}

