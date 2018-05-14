using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WangYc.Models.Common;
using WangYc.Services.ViewModels.Common;

namespace WangYc.Services.Mapping.Common {
    public static class WorkflowActivityMapper {
        public static WorkflowActivityView ConvertToWorkflowActivityView(this WorkflowActivity model) {

            return Mapper.Map<WorkflowActivity, WorkflowActivityView>(model);
        }

        public static IEnumerable<WorkflowActivityView> ConvertToWorkflowActivityView(this IEnumerable<WorkflowActivity> model) {

            return Mapper.Map<IEnumerable<WorkflowActivity>, IEnumerable<WorkflowActivityView>>(model);
        }
    }
}
