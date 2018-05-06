using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WangYc.Models.PP;
using WangYc.Services.ViewModels.PP;

namespace WangYc.Services.Mapping.PP {
    public static class ProjectAttendanceAttendanceMapper {
            public static ProjectAttendanceView ConvertToProjectAttendanceView(this ProjectAttendance model) {

                return Mapper.Map<ProjectAttendance, ProjectAttendanceView>(model);
            }

            public static IEnumerable<ProjectAttendanceView> ConvertToProjectAttendanceView(this IEnumerable<ProjectAttendance> model) {

                return Mapper.Map<IEnumerable<ProjectAttendance>, IEnumerable<ProjectAttendanceView>>(model);
            }
        }
    }

