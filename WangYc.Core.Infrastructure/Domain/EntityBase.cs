using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WangYc.Core.Infrastructure.Domain {
    public abstract class EntityBase<TId> {

        private List<BusinessRule> brokenRules = new List<BusinessRule>();

        public virtual TId Id { get; set; }
        public virtual TId GenerateIdPrefix() {
            return Id;
        }

        protected abstract void Validate();

        public virtual IEnumerable<BusinessRule> GetBrokenRules() {
            brokenRules.Clear();
            Validate();
            return brokenRules;
        }

        protected virtual void AddBrokenRule(BusinessRule businessRule) {
            brokenRules.Add(businessRule);
        }

        public override bool Equals(object entity) {
            return entity != null && entity is EntityBase<TId> && this == (EntityBase<TId>)entity;
        }

        public override int GetHashCode() {
            return this.Id.GetHashCode();
        }

        public static bool operator ==(EntityBase<TId> entity1, EntityBase<TId> entity2) {
            if ((object)entity1 == null && (object)entity2 == null) {
                return true;
            }
            if ((object)entity1 == null || (object)entity2 == null) {
                return false;
            }
            if (entity1.Id.ToString().Trim().ToUpper() == entity2.Id.ToString().Trim().ToUpper()) {
                return true;
            }
            return false;
        }

        public static bool operator !=(EntityBase<TId> entity1, EntityBase<TId> entity2) {
            return (!(entity1 == entity2));
        }

        /// <summary>
        /// 获取中文首字母
        /// </summary>
        /// <param name="strText"></param>
        /// <returns></returns>
        public virtual string GetChineseSpell(string strText) {
            int len = strText.Length;
            string myStr = "";
            for (int i = 0; i < len; i++) {
                myStr += getSpell(strText.Substring(i, 1));
            }
            return myStr;
        }

        public virtual string getSpell(string cnChar) {
            byte[] arrCN = Encoding.Default.GetBytes(cnChar);
            if (arrCN.Length > 1) {
                int area = (short)arrCN[0];
                int pos = (short)arrCN[1];
                int code = (area << 8) + pos;
                int[] areacode = { 45217, 45253, 45761, 46318, 46826, 47010, 47297, 47614, 48119, 48119, 49062, 49324, 49896, 50371, 50614, 50622, 50906, 51387, 51446, 52218, 52698, 52698, 52698, 52980, 53689, 54481 };
                for (int i = 0; i < 26; i++) {
                    int max = 55290;
                    if (i != 25) max = areacode[i + 1];
                    if (areacode[i] <= code && code < max) {
                        return Encoding.Default.GetString(new byte[] { (byte)(65 + i) });
                    }
                }
                return "*";
            } else
                return cnChar;
        }
    }
}
