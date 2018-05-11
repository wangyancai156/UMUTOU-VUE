using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WangYc.Core.Infrastructure.UnitOfWork;
using WangYc.Models.Common;
using WangYc.Models.Repository.Common;
using WangYc.Repository.NHibernate.Repositories.Common;

namespace WangYc.Repository.NHibernate.Tests.Common {
    [TestClass]
    public class WorkflowActivityTests {

        private readonly IWorkflowActivityRepository _workflowActivityRepository;
        private readonly IWorkflowActivityNodeRepository _workflowActivityNodeRepository;

        public WorkflowActivityTests() {

            IUnitOfWork uow = new NHUnitOfWork();
            this._workflowActivityNodeRepository = new WorkflowActivityNodeRepository(uow);
            this._workflowActivityRepository = new WorkflowActivityRepository(uow);

        }

        [TestMethod]
        public void GetWorkflowActivity() {

            IEnumerable<WorkflowActivity> model = this._workflowActivityRepository.FindAll();
        }

        [TestMethod]
        public void GetWorkflowActivityNode() {

            IEnumerable<WorkflowActivityNode> model = this._workflowActivityNodeRepository.FindAll();
        }
    }
}
