using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WangYc.Core.Infrastructure.Domain;
using WangYc.Models.Common;

namespace WangYc.Models.Repository.Common {
    public interface IWorkflowActivityNodeRepository : IRepository<WorkflowActivityNode, int> {
    }
}

