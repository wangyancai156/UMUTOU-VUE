using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WangYc.Services.ViewModels {
    public class MenuView: Menu {
         
        public IList<Menu> children { get; set; }

    }
}
