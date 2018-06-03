using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WangYc.Core.Infrastructure.Domain;
using WangYc.Services.Messaging.BW;
using WangYc.Services.ViewModels.BW;

namespace WangYc.Services.Interfaces.BW {
    public interface ISpotInventoryService {

        ListPaged<SpotInventoryView> GetSpotInventory(GetSpotInventoryRequest request);

        void InSpotInventory(int productId, int warehouseId, int qty, float price, string currency);
        void OutSpotInventory(int productId, int warehouseId, int qty);
    }
}
