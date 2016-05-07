using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simangkot
{
    using System.Collections.ObjectModel;
    using System.Device.Location;

    /// <summary>
    /// List of stores
    /// </summary>
    public class StoreListGnbatu : ObservableCollection<Store>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="StoreList"/> class
        /// </summary>
        /// 

        public StoreListGnbatu()
        {
            this.Add(new Store() { GeoCoordinate = new GeoCoordinate(-6.888587, 107.567825), Address = "Terminal Gunung Batu" });
            this.Add(new Store() { GeoCoordinate = new GeoCoordinate(-6.9126, 107.60269), Address = "Stasiun Bandung" });            

        }
 
        /// <summary>
        /// Loads the current store data into the collection
        /// 
        /// </summary>


    }

}
