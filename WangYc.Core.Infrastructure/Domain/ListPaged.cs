﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WangYc.Core.Infrastructure.Domain
{
    public class ListPaged<T> 
    {

        public ListPaged()
        {
            this.EntityList = new List<T>();
        }
        public IList<T> EntityList { get; set; }
        public int TotalCount { get; set; }
        public int PageSize { get; set; }
        public int PageCount { get; set; }
        public int PageIndex { get; set; }
    }
}
