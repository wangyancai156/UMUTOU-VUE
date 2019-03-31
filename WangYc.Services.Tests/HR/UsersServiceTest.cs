using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.VisualStudio.TestTools.UnitTesting;
using WangYc.Core.Infrastructure.UnitOfWork;
using WangYc.Core.Infrastructure.Domain;
 
using WangYc.Models.Repository.HR;

using WangYc.Repository.NHibernate;
using WangYc.Repository.NHibernate.Repositories.HR;

using WangYc.Services.Interfaces;
using WangYc.Services.Interfaces.HR;
using WangYc.Services.Implementations.HR;
using WangYc.Services.Mapping.HR;
using WangYc.Services.ViewModels.HR;
using WangYc.Models.HR;
using WangYc.Services.ViewModels;
using WangYc.Services.Messaging.HR;

namespace WangYc.Services.Tests
{
    [TestClass]
    public class UsersServiceTest
    {
        private readonly IUsersService _userService;
        private readonly IOrganizationService _organizationService;
        IIdGenerator<Users, string> _usersIdGenerator;
        public UsersServiceTest() {

            IUnitOfWork uow = new NHUnitOfWork();
            IUsersRepository _usersRepository = new UsersRepository(uow);
            IRoleRepository _roleRepository = new RoleRepository(uow);
            IOrganizationRepository _organizationRepository = new OrganizationRepository(uow);
            IOrganizationService _organizationService = new OrganizationService(_organizationRepository,uow);
            this._usersIdGenerator = new IdGenerator<Users>();

            this._userService = new UsersService(_usersRepository, _organizationService, null, this._usersIdGenerator, uow);
            this._organizationService = new OrganizationService(_organizationRepository, uow);
            
            AutoMapperBootStrapper.ConfigureAutoMapper();
        }


        [TestCategory("根据userID获取user实体")]
        [TestMethod]
        public void FindUsersByTest() {

            string userId = "123";
            UsersView user = this._userService.FindUsersBy(userId);
             
        }

        [TestMethod]
        public void GetOrganization() {
            IEnumerable<DataTree> organization = this._organizationService.GetOrganizationTreeView();
        }

        [TestMethod]
        public void AddUser() {

            AddUsersRequest request = new AddUsersRequest();
            request.Organizationid = 1;
            request.Telephone = "15010215094";
            request.Name = "王彦彩";
            request.Pwd = "liwenwen851126";
            this._userService.InsertUsers(request);

        }
    }
}
