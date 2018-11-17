using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WangYc.Core.Infrastructure.UnitOfWork;
using WangYc.Models.Common;
using WangYc.Models.Repository.Common;

namespace WangYc.Repository.NHibernate.Repositories.Common {
    public class WorkflowActivityNodeRepository : Repository<WorkflowActivityNode, string>, IWorkflowActivityNodeRepository {
        public WorkflowActivityNodeRepository(IUnitOfWork uow)
            : base(uow) { }
    }
}