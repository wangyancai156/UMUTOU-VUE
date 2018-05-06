using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WangYc.Models.PP;
using WangYc.Services.ViewModels.PP;

namespace WangYc.Services.Mapping.PP {
  
        public static class ProjectMaterialMapper {
            public static ProjectMaterialView ConvertToProjectMaterialView(this ProjectMaterial model) {

                return Mapper.Map<ProjectMaterial, ProjectMaterialView>(model);
            }

            public static IEnumerable<ProjectMaterialView> ConvertToProjectMaterialView(this IEnumerable<ProjectMaterial> model) {

                return Mapper.Map<IEnumerable<ProjectMaterial>, IEnumerable<ProjectMaterialView>>(model);
            }
        }
    }
