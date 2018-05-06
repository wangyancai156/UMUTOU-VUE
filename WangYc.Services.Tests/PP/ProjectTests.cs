using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WangYc.Core.Infrastructure.UnitOfWork;
using WangYc.Models.Repository.PP;
using WangYc.Repository.NHibernate;
using WangYc.Repository.NHibernate.Repositories.PP;
using WangYc.Services.Implementations.PP;
using WangYc.Services.Interfaces.PP;

namespace WangYc.Services.Tests.PP {
    [TestClass]
    public class ProjectTests {
        private readonly IProjectService _projectService;
        private readonly IProjectRepository _projectRepository;

        public ProjectTests() {

            IUnitOfWork uow = new NHUnitOfWork();
            this._projectRepository = new ProjectRepository(uow);
            this._projectService = new ProjectService(this._projectRepository, uow);
        }

        [TestMethod]
        public void GetPurchaseOrder() {

            this._projectService.GetProjectViewByAll();
        }

    }
}
