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
    public class StoreList : ObservableCollection<Store>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="StoreList"/> class
        /// </summary>
        /// 

        public StoreList()
        {
            this.Add(new Store() { GeoCoordinate = new GeoCoordinate(-6.86985, 107.54384), Address = "Terminal Pasar Atas Cimahi" });
            this.Add(new Store() { GeoCoordinate = new GeoCoordinate(-6.9126, 107.60269), Address = "Stasiun Bandung" });            

        }
 
        /// <summary>
        /// Loads the current store data into the collection
        /// 
        /// </summary>

    }


    public class StoreList2 : ObservableCollection<Store>
    {
        public StoreList2()
        {
            this.Add(new Store() { GeoCoordinate = new GeoCoordinate(-6.86668, 107.620938), Address = "Terminal Dago Atas" });
            this.Add(new Store() { GeoCoordinate = new GeoCoordinate(-6.906917, 107.610595), Address = "Stasiun Bandung" });
        }


    }


    public class StoreList3 : ObservableCollection<Store>
    {
        public StoreList3()
        {
            LoadData();
        }

        public void LoadData()
        {
            this.Add(new Store() { GeoCoordinate = new GeoCoordinate(-6.86668, 107.620938), Address = "Terminal Dago Atas" });
            this.Add(new Store() { GeoCoordinate = new GeoCoordinate(-6.906917, 107.610595), Address = "Stasiun Bandung" });
        }

        public class StoreList4 : ObservableCollection<Store>
        {
            public StoreList4()
            {
                LoadData();
            }

            public void LoadData()
            {
                this.Add(new Store() { GeoCoordinate = new GeoCoordinate(-6.86668, 107.620938), Address = "Terminal Dago Atas" });
                this.Add(new Store() { GeoCoordinate = new GeoCoordinate(-6.906917, 107.610595), Address = "Stasiun Bandung" });
            }


        }


    }

}
