using System;
using System.Collections.Generic;

using WangYc.Core.Infrastructure.Domain;

namespace WangYc.Models.HR {
    /// <summary>
    /// Users:实体类(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    public class Users : EntityBase<string>, IAggregateRoot {
        public Users() { }
        public Users(Organization organization, string id, string username, string userpwd, string telephone) {

            this.AddOrganization(organization);
            this.Id = id;
            this.UserName = username;
            this.UserPwd = userpwd;
            this.SignState = 1;
            this.Telephone = telephone;
        }


        #region Model

        public virtual IList<Organization> Organization {
            get;
            set;
        }
        /// <summary>
        /// 
        /// </summary>
        public virtual string UserName {
            get;
            set;
        }
        /// <summary>
        /// 
        /// </summary>
        public virtual string UserPwd {
            get;
            set;
        }


        public virtual string Telephone {
            get;
            set;
        }
        /// <summary>
        /// 
        /// </summary>
        public virtual DateTime? LastSignTime {
            get;
            set;
        }
        /// <summary>
        /// 
        /// </summary>
        public virtual int SignState {
            get;
            set;
        }
        /// <summary>
        /// 
        /// </summary>
        public virtual string TickeID {
            get;
            set;
        }

        public virtual IList<Role> Role { set; get; }

        public virtual List<int> RightsIdList {
            get {
                List<int> result = new List<int>();
                foreach (Role one in this.Role) {
                    foreach (int two in one.RightsList) {
                        if (!result.Contains(two)) {
                            result.Add(two);
                        }
                    }
                }
                return result;
            }
        }

        public virtual IList<UserDevice> Device { set; get; }


        #endregion Model


        #region 事件

        #region 权限

        /// <summary>
        /// 添加权限
        /// </summary>
        /// <param name="role"></param>
        public virtual void AddOrganization(Organization model) {
            if (this.Organization == null) {
                this.Organization = new List<Organization>();
            }
            this.Organization.Add(model);
        }
        /// <summary>
        /// 添加权限
        /// </summary>
        /// <param name="role"></param>
        public virtual void AddRole(Role role) {
            if (this.Role == null) {
                this.Role = new List<Role>();
            }
            this.Role.Add(role);
        }
        #endregion

        #region 设备登陆

        /// <summary>
        /// 添加登陆记录
        /// </summary>
        /// <param name="device"></param>
        public virtual void AddDevice(UserDevice device) {
            if (this.Device == null) {
                this.Device = new List<UserDevice>();
            }
            this.Device.Add(device);
        }

        #endregion

        #endregion
        protected override void Validate() {
            throw new NotImplementedException();
        }
        public override string GenerateIdPrefix() {

            return GetChineseSpell(this.UserName.Substring(0, 1));
        }


    }
}

