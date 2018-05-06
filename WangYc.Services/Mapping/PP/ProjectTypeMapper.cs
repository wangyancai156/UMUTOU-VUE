using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WangYc.Models.PP;
using WangYc.Services.ViewModels.PP;

namespace WangYc.Services.Mapping.PP {
    public static class ProjectTypeMapper {
        public static ProjectTypeView ConvertToProjectTypeView(this ProjectType model) {

            return Mapper.Map<ProjectType, ProjectTypeView>(model);
        }

        public static IEnumerable<ProjectTypeView> ConvertToProjectTypeView(this IEnumerable<ProjectType> model) {

            return Mapper.Map<IEnumerable<ProjectType>, IEnumerable<ProjectTypeView>>(model);
        }
    }
}
