using NHibernate.Criterion;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using WangYc.Core.Infrastructure.Domain;
using WangYc.Core.Infrastructure.Helpers;

namespace WangYc.Repository.NHibernate {
    public class IdGenerator<T> : IIdGenerator<T, string> where T : EntityBase<string> {

        public string NewId(T saleOrder) {

            string result = saleOrder.GenerateIdPrefix();
            IList list = SessionFactory.GetCurrentSession().CreateCriteria(typeof(T))
                .SetProjection(Projections.Max("Id"))
                .Add(Expression.Like("Id", result + "[A-Z]"))
                .List();

            /*
             * 与原函数中的生成规则一致，只生成到ZZZ级别，往后没有再继续生成.（已可以满足需求）
             * select dbs.dbo.fn_mi_GetNext('SorderID','D55')
             */
            string seed = "";
            if (list[0] != null) {
                string currentMaxId = list[0].ToString();
                seed = currentMaxId.Substring(currentMaxId.Length - 1);
                if (seed == "Z") {
                    seed = "";
                    IList list2 = SessionFactory.GetCurrentSession().CreateCriteria(typeof(T))
                    .SetProjection(Projections.Max("Id"))
                    .Add(Expression.Like("Id", result + "[A-Z][A-Z]"))
                    .List();

                    if (list2[0] != null) {
                        currentMaxId = list2[0].ToString();
                        seed = currentMaxId.Substring(currentMaxId.Length - 2);
                        if (seed == "ZZ") {
                            seed = "";
                            IList list3 = SessionFactory.GetCurrentSession().CreateCriteria(typeof(T))
                            .SetProjection(Projections.Max("Id"))
                            .Add(Expression.Like("Id", result + "[A-Z][A-Z][A-Z]"))
                            .List();

                            if (list3[0] != null) {
                                currentMaxId = list3[0].ToString();
                                seed = currentMaxId.Substring(currentMaxId.Length - 3);

                                if (seed == "ZZZ") {
                                    result = result + "AAAA";
                                } else {
                                    result += IdIncrease.StringIncrease(seed);
                                }
                            } else {
                                result = result + "AAA";
                            }
                        } else {
                            result += IdIncrease.StringIncrease(seed);
                        }
                    } else {
                        result = result + "AA";
                    }
                } else {
                    result += IdIncrease.StringIncrease(seed);
                }
            } else {
                result += IdIncrease.StringIncrease(seed);
            }

            return result;
        }

        public string NewIntId(T saleOrder, int length) {

            string result = saleOrder.GenerateIdPrefix();
            /*
            初始后缀的为三位整数，超过三位加为四位,依次递增
            */
            return GetMaxId(result, length);
        }

        private string GetMaxId(string result, int i) {
            string likeString = "", defaultSeed = "";
            for (int j = 0; j < i; j++) {
                likeString += "[0-9]";
                defaultSeed = defaultSeed + "0";
            }
            IList list = SessionFactory.GetCurrentSession().CreateCriteria(typeof(T))
                   .SetProjection(Projections.Max("Id"))
                   .Add(Expression.Like("Id", result + likeString))
                   .List();

            string seed = "";
            if (list[0] != null) {
                string currentMaxId = list[0].ToString();
                seed = currentMaxId.Replace(result, "");
                Regex reg = new Regex("^[0-9]");
                Match ma = reg.Match(seed);
                if (!ma.Success) {
                    seed = defaultSeed;
                }
            } else {
                seed = defaultSeed;
            }
            string newseed = IdIncrease.IntIncrease(seed);
            if (newseed.Length > seed.Length) {
                return GetMaxId(result, (i + 1));
            } else {
                result = result + newseed;
            }
            return result;
        }

    }

}
