using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WangYc.Core.Infrastructure.UnitOfWork;
using WangYc.Models.Common;
using WangYc.Models.Repository.Common;

namespace WangYc.Repository.NHibernate.Repositories.Common {
    public class WorkflowActivityRepository : Repository<WorkflowActivity, int>, IWorkflowActivityRepository {
        public WorkflowActivityRepository(IUnitOfWork uow)
            : base(uow) { }
    }
}