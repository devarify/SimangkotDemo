using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;

namespace Simangkot
{
    public partial class Detail1 : PhoneApplicationPage
    {
        public Detail1()
        {
            InitializeComponent();
            DetailAngkot1Text.DataContext = new DetailAngkot1("Cimahi - Stasiun Bandung PP", "Hijau Orange", "Rp.4000 - Rp.8000", "Terminal Pasar Antri - Pojok - Sangkuriang - Citeureup - Pasar Atas - Tagog - Cibabat - Cimindi - Cibeureum - Rajawali - Ciroyom - Pajajaran - Cicendo - Stasiun Bandung");
        }
        public class DetailAngkot1
        {
            public DetailAngkot1() { }
            public DetailAngkot1(string NamaAngkot, string WarnaAngkot, string Tarif, string JalurTrayek)
            {
                Nama = NamaAngkot;
                Warna = WarnaAngkot;
                Ongkos = Tarif;
                Trayek = JalurTrayek; 
            }
            public string Nama { get; set; }
            public string Warna { get; set; }
            public string Ongkos { get; set; }
            public string Trayek { get; set; }
            // Override the ToString method.
            public override string ToString()
            {
                return "Angkot : " + Nama + "\n" + "Warna Angkot : " + Warna + "\n" + "\n" + "Tarif : " + Ongkos + "\n" + "\n" + "Rute Trayek : " + Trayek;
            }
        }
    }
}