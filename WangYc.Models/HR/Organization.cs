using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using WangYc.Core.Infrastructure.Domain;

namespace WangYc.Models.HR {
    public class Organization : EntityBase<int>, IAggregateRoot {

        #region 属性

        public Organization() { }

        public Organization(Organization parent, string name, string description, int level) {

            this.Name = name;
            this.Description = description;
            this.Level = level;
            this.CreateDate = DateTime.Now;
            this.Parent = parent;

        }
        /// <summary>
        /// 父节点
        /// </summary>
        public virtual Organization Parent { get; set; }
        /// <summary>
        /// 子节点
        /// </summary>
        public virtual IList<Organization> Child { get; set; }
        /// <summary>
        /// 名称
        /// </summary>
        public virtual string Name { get; set; }
        /// <summary>
        /// 描述
        /// </summary>
        public virtual string Description { get; set; }
        /// <summary>
        /// 创建时间
        /// </summary>
        public virtual DateTime CreateDate { get; set; }
        /// <summary>
        /// 等级
        /// </summary>
        public virtual int Level { get; set; }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        private List<int> GetOrganizationId(Organization model) {

            List<int> result = new List<int>();
            if (model != null && model.Level > 0) {
                result.Add( model.Id);
                List<int> l = GetOrganizationId(model.Parent);
                foreach (int one in l) {
                    if (!result.Contains(one)) {
                        result.Add(one);
                    }
                }
            }
            return result;
        }
        public virtual List<int> OrganizationIdList {
            get {
                return GetOrganizationId(this).OrderBy(s=>s).ToList();
            }
        }


        #endregion

        #region 方法

        /// <summary>
        /// 添加
        /// </summary>
        /// <param name="name"></param>
        /// <param name="descriptin"></param>
        /// <returns></returns>
        public virtual Organization AddChild(string name, string descriptin) {

            Organization organization = new Organization(this, name, descriptin, this.Level + 1);
            if (Child == null) {
                Child = new List<Organization>();
                Child.Add(organization);
            }
            else {
                Child.Add(organization);
            }

            return organization;
        }

        /// <summary>
        /// 修改
        /// </summary>
        /// <param name="name"></param>
        /// <param name="descriptin"></param>
        /// <returns></returns>
        public virtual void UpdateOrganization(string name, string description) {

            this.Name = name;
            this.Description = description;
        }


        #endregion

        protected override void Validate() {
            throw new NotImplementedException();
        }

    }
}
