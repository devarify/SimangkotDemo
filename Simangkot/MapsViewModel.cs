using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simangkot
{
    class MapsViewModel
    {

        public MapsViewModel()
        {
            this.StoreList = new StoreList();
            this.StoreListDago = new StoreListDago();
            this.StoreListSarijadi = new StoreListSarijadi();
            this.StoreListGnbatu = new StoreListGnbatu();
        }
        public StoreListDago StoreListDago { get; set; }
        public StoreListSarijadi StoreListSarijadi { get; set; }
        public StoreList StoreList { get; set; }
        public StoreListGnbatu StoreListGnbatu { get; set; }
    }

}
