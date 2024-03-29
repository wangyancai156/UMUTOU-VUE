﻿using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using WangYc.Core.Infrastructure.Querying;
using WangYc.Core.Infrastructure.UnitOfWork;
using WangYc.Repository.NHibernate;

using WangYc.Models.BW;
using WangYc.Models.Repository.BW;
using WangYc.Repository.NHibernate.Repositories.BW;

using WangYc.Services.Interfaces.BW;
using WangYc.Services.Implementations.BW;
using WangYc.Services.Mapping.BW;
using WangYc.Services.ViewModels.BW;
using WangYc.Core.Infrastructure.Domain;

namespace WangYc.Services.Tests.BW
{
    [TestClass]
    public class WarehouseTest
    {
        private readonly IWarehouseRepository _warehouseRsponstroy;

        public WarehouseTest()
        {

            IUnitOfWork uow = new NHUnitOfWork();
            this._warehouseRsponstroy = new WarehouseRepository(uow);
            AutoMapperBootStrapper.ConfigureAutoMapper();
        }

        [TestMethod]
        public void GetWarehouse()
        {

            IEnumerable<Warehouse> model = this._warehouseRsponstroy.FindAll();
            IEnumerable<WarehouseView> modelView = model.ConvertToWarehouseView();
            foreach (Warehouse i in model)
            {
                IEnumerable<WarehouseShelf> models = i.Shelf;
            }

        }

        [TestMethod]
        public void GetWarehousePaged()
        {
            Query query = new Query();
            query.Add(Criterion.Create<Warehouse>(i => i.Id, 0, CriteriaOperator.NotEqual));
            ListPaged<Warehouse> a = this._warehouseRsponstroy.PagedFindBy(query, 1, 111);
        }

    }
}
