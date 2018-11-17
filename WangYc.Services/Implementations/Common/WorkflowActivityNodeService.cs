using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WangYc.Core.Infrastructure.UnitOfWork;
using WangYc.Models.Common;
using WangYc.Models.Repository.Common;
using WangYc.Services.Interfaces.Common;

namespace WangYc.Services.Implementations.Common {


    public class WorkflowActivityNodeService : IWorkflowActivityNodeService {

        private readonly IPurchaseWorkflowActivityNodeRepository _purchaseWorkflowActivityNodeRepository;
        private readonly IUnitOfWork _uow;
        public WorkflowActivityNodeService(IPurchaseWorkflowActivityNodeRepository purchaseWorkflowActivityNodeRepository, IUnitOfWork uow) {

            this._purchaseWorkflowActivityNodeRepository = purchaseWorkflowActivityNodeRepository;
            this._uow = uow;
        }

        public PurchaseWorkflowActivityNode GetPurchaseWorkflowActivityNode(string id) {

           return this._purchaseWorkflowActivityNodeRepository.FindBy(id);
        }


    }
}
