using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using AutoMapper;
using WangYc.Models.HR;
using WangYc.Services.ViewModels;
using WangYc.Services.ViewModels.HR;

namespace WangYc.Services.Mapping.HR {
    public static class RoleMapper {

        public static RoleView ConvertToRoleView(this Role model) {

            return Mapper.Map<Role, RoleView>(model);
        }

        public static IEnumerable<RoleView> ConvertToRoleView(this IEnumerable<Role> model) {
            return Mapper.Map<IEnumerable<Role>, IEnumerable<RoleView>>(model);
        }

        public static DataTreeView ConvertToDataTreeView(this Role role) {

            return Mapper.Map<Role, DataTreeView>(role);
        }

        public static DataTree ConvertToDataTree(this Role role) {

            return Mapper.Map<Role, DataTree>(role);
        }

        /// <summary>
        /// 转换成树
        /// </summary>
        /// <param name="rights"></param>
        /// <returns></returns>
        public static IList<DataTree> ConvertToDataTreeView(this IEnumerable<Role> role) {

            IList<DataTree> reslut = new List<DataTree>();
            foreach (Role item in role) {
                if (item.IsValid) {
                    if (item.Child.Count > 0) {
                        DataTreeView reslutChild = new DataTreeView();
                        reslutChild.value = item.Id.ToString();
                        reslutChild.label = item.Name;
                        reslutChild.children = ConvertToDataTreeView(item.Child);
                        reslut.Add(reslutChild);
                    } else {

                        reslut.Add(item.ConvertToDataTree());
                    }
                }
            }
            return reslut;
        }

    }
}
