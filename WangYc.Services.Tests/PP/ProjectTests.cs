﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
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

        private readonly IProjectAttendanceService _projectAttendanceService;
        private readonly IProjectAttendanceRepository _projectAttendanceRepository;

        public ProjectTests() {

            IUnitOfWork uow = new NHUnitOfWork();
            this._projectRepository = new ProjectRepository(uow);
            this._projectAttendanceRepository = new ProjectAttendanceRepository(uow);

            this._projectService = new ProjectService(this._projectRepository, uow);
            this._projectAttendanceService = new ProjectAttendanceService(this._projectAttendanceRepository, uow);
        }

        [TestMethod]
        public void GetProject() {

            this._projectService.GetProjectViewByAll();
        }

        [TestMethod]
        public void GetAttendance() {

            this._projectAttendanceService.GetProjectAttendanceViewByAll();
        }

    }
}