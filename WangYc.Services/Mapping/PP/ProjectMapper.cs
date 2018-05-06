using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WangYc.Models.PP;
using WangYc.Services.ViewModels.PP;

namespace WangYc.Services.Mapping.PP {
    public static class ProjectMapper {
        public static ProjectView ConvertToProjectView(this Project model) {

            return Mapper.Map<Project, ProjectView>(model);
        }

        public static IEnumerable<ProjectView> ConvertToProjectView(this IEnumerable<Project> model) {

            return Mapper.Map<IEnumerable<Project>, IEnumerable<ProjectView>>(model);
        }
    }
}
