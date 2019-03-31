using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using WangYc.Core.Infrastructure.Domain;

namespace WangYc.Models.HR {

    public class Rights : EntityBase<int>, IAggregateRoot {

        #region 属性

        public Rights() { }

        public Rights(Rights parent, string name,string url, string description, bool isshow, int level) {

            this.Name = name;
            this.Url = url;
            this.Description = description;
            this.IsShow = isshow;
            this.Level = level;
            this.CreateDate = DateTime.Now;
            this.Parent = parent;
            this.IsLeaf = true;
            if (level == 2) {
                this.PathName = parent.Name;
            } else if (level > 2) {
                this.PathName = parent.PathName + "/" + parent.Name;
            }

        }
        /// <summary>
        /// 父节点
        /// </summary>
        public virtual Rights Parent { get; set; }
        /// <summary>
        /// 子节点
        /// </summary>
        public virtual IList<Rights> Child { get; set; }
        /// <summary>
        /// 名称
        /// </summary>
        public virtual string Name { get; set; }
        /// <summary>
        /// 路径
        /// </summary>
        public virtual string Url { get; set; }

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
        /// 是否显示
        /// </summary>
        public virtual bool IsShow { get; set; }
        public virtual bool IsLeaf { get; set; }

        public virtual string PathName { get; set; }
        
        #endregion

        #region 方法

        /// <summary>
        /// 添加
        /// </summary>
        /// <param name="name"></param>
        /// <param name="descriptin"></param>
        /// <returns></returns>
        public virtual Rights AddChild(string name,string url, string descriptin, bool isshow ) {

            Rights rights = new Rights(this, name, url, descriptin, isshow,  this.Level + 1);
            if (Child == null) {
                Child = new List<Rights>();
                Child.Add(rights);
            }
            else {
                Child.Add(rights);
            }
            if (this.Child.Count > 0) {
                this.IsLeaf = false;
            } else {
                this.IsLeaf = true;
            }
            return rights;
        }

        /// <summary>
        /// 修改
        /// </summary>
        /// <param name="name"></param>
        /// <param name="descriptin"></param>
        /// <returns></returns>
        public virtual void UpdateRights(string name,string url, string description, bool isshow) {

            this.Name = name;
            this.Description = description;
            this.IsShow = isshow;
            this.Url = url;
 
            if (this.Level == 2) {
                this.PathName = this.Parent.Name;
            } else if (this.Level > 2) {
                this.PathName = this.Parent.PathName + "/" + this.Parent.Name;
            }
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        private List<int> GetRightsId(Rights model) {
          
            List<int> result = new List<int>();
            if (model != null) {
                result.Add(model.Id);
                List<int> l = GetRightsId(model.Parent);
                foreach (int one in l) {
                    if (!result.Contains(one)) {
                        result.Add(one);
                    }
                }
            }
            return result;
        }


        public virtual List<int> RightsList {
            get {
                return GetRightsId(this);
            }

        }
        
        #endregion


        protected override void Validate() {
            throw new NotImplementedException();
        }
    }
}
