using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WangYc.Models.PP;
using WangYc.Services.ViewModels.PP;

namespace WangYc.Services.Mapping.PP {
        public static class ProjectProductMapper {
            public static ProjectProductView ConvertToProjectProductView(this ProjectProduct model) {

                return Mapper.Map<ProjectProduct, ProjectProductView>(model);
            }

            public static IEnumerable<ProjectProductView> ConvertToProjectProductView(this IEnumerable<ProjectProduct> model) {

                return Mapper.Map<IEnumerable<ProjectProduct>, IEnumerable<ProjectProductView>>(model);
            }
        }
    }
