using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WangYc.Core.Infrastructure.UnitOfWork;
using WangYc.Models.PP;
using WangYc.Models.Repository.PP;

namespace WangYc.Repository.NHibernate.Repositories.PP {
    public class ProjectAttendanceRepository : Repository<ProjectAttendance, int>, IProjectAttendanceRepository {
        public ProjectAttendanceRepository(IUnitOfWork uow)
            : base(uow) { }
    }
}