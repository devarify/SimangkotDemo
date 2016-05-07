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
    public class StoreListDago : ObservableCollection<Store>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="StoreList"/> class
        /// </summary>
        /// 

        public StoreListDago()
        {
            this.Add(new Store() { GeoCoordinate = new GeoCoordinate(-6.86668, 107.620938), Address = "Terminal Dago Atas" });
            this.Add(new Store() { GeoCoordinate = new GeoCoordinate(-6.9126, 107.60269), Address = "Stasiun Bandung" });            

        }
 
        /// <summary>
        /// Loads the current store data into the collection
        /// 
        /// </summary>


    }

}
