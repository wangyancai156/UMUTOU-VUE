﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WangYc.Core.Infrastructure.UnitOfWork;
using WangYc.Models.Repository.PP;
using WangYc.Repository.NHibernate.Repositories.PP;

namespace WangYc.Repository.NHibernate.Tests.PP {
    [TestClass]
    public class ProjectTests {

        private readonly IProjectRepository _projectRepository;
        private readonly IProjectAttendanceRepository _projectAttendanceRepository;
        
        public ProjectTests() {

            IUnitOfWork uow = new NHUnitOfWork();
            this._projectRepository = new ProjectRepository(uow);
            this._projectAttendanceRepository = new ProjectAttendanceRepository(uow);
        }
 

        [TestMethod]
        public void GetProject() {

            this._projectRepository.FindAll();
        }


        [TestMethod]
        public void GetProjectAttendance() {

            this._projectAttendanceRepository.FindAll();
        }
    }
}