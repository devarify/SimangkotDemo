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
    public class StoreListSarijadi : ObservableCollection<Store>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="StoreList"/> class
        /// </summary>
        /// 

        public StoreListSarijadi()
        {
            this.Add(new Store() { GeoCoordinate = new GeoCoordinate(-6.88174, 107.575389), Address = "Terminal Sarijadi" });
            
            this.Add(new Store() { GeoCoordinate = new GeoCoordinate(-6.915454, 107.586867), Address = "Terminal Pasar Ciroyom" });            
        
        }
 
        /// <summary>
        /// Loads the current store data into the collection
        /// 
        /// </summary>


    }

}
