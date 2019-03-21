using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;

using WangYc.Models.HR;
using WangYc.Services.ViewModels.HR;
using WangYc.Services.ViewModels;

namespace WangYc.Services.Mapping.HR
{
    public static class RightsMapper
    {
        public static RightsView ConvertToRightsView(this Rights permission)
        {

            return Mapper.Map<Rights, RightsView>(permission);
        }

        public static IEnumerable<RightsView> ConvertToRightsView(this IEnumerable<Rights> permissions)
        {
            return Mapper.Map<IEnumerable<Rights>, IEnumerable<RightsView>>(permissions);
        }


        public static DataTreeView ConvertToDataTreeView(this Rights rights) {

            return Mapper.Map<Rights, DataTreeView>(rights);
        }

        public static DataTree ConvertToDataTree(this Rights rights) {

            return Mapper.Map<Rights, DataTree>(rights);
        }

        public static IList<DataTree> ConvertToDataTreeView(this IEnumerable<Rights> rights) {

            IList<DataTree> reslut = new List<DataTree>();
            foreach (Rights item in rights) {
                if (item.Child.Count > 0) {
                    DataTreeView reslutChild = new DataTreeView();
                    reslutChild.value = item.Id.ToString();
                    reslutChild.label = item.Name;
                    reslutChild.children = ConvertToDataTreeView(item.Child);
                    reslut.Add(reslutChild);
                }
                else {
                    reslut.Add(item.ConvertToDataTree());
                }
            }
            return reslut;
        }

        public static IList<DataTree> ConvertToDataTreeView(this IEnumerable<Rights> rights, List<int> rightid) {

            IList<DataTree> reslut = new List<DataTree>();

            foreach (Rights item in rights) {
                if (rightid.Contains(item.Id)) {
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

        public static IList<DataTree> ConvertToDataTreeNoLeafView(this IEnumerable<Rights> rights) {

            IList<DataTree> reslut = new List<DataTree>();
            foreach (Rights item in rights) {
                if (item.Child.Count > 0) {
                    if (ConvertToDataTreeNoLeafView(item.Child).Count > 0) {
                        DataTreeView reslutChild = new DataTreeView();
                        reslutChild.value = item.Id.ToString();
                        reslutChild.label = item.Name;
                        reslutChild.children = ConvertToDataTreeNoLeafView(item.Child);
                        reslut.Add(reslutChild);
                    } else {
                        reslut.Add(item.ConvertToDataTree());
                    }
                  
                } else {
                    if (!item.IsLeaf) {
                        reslut.Add(item.ConvertToDataTree());
                    }
                }
            }
            return reslut;
        }


    }
}
