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
    public partial class Detail2 : PhoneApplicationPage
    {
        public Detail2()
        {
            InitializeComponent();
            DetailAngkot2Text.DataContext = new DetailAngkot2("Dago - Stasiun Bandung PP", "Hijau Strip Orange", "Rp.4000 - Rp.8500", "Terminal Dago – Jl. Ir. H. Juanda – Simpang Dago – ITB (Jl. Ganesha, Dago) – RS Boromeus (Dago) – BIP (Merdeka) – Jl. Merdeka – Jl. Perintis Kemerdekaan – Jl. Braga – Jl. Suniaraja – Jl. Stasiun Barat (Stasiun Bandung) ---- Jl. Stasiun Barat (Stasiun Bandung) – Jl. Stasiun Timur – Viaduct – Jl. Perintis Kemerdekaan – Jl. Wastu Kencana – Jl. RE. Martadinata – Jl. Ir. H. Juanda - RS Boromeus (Dago) – ITB (Jl. Ganesha, Dago) – Simpang Dago – Terminal Dago");
        }


        public class DetailAngkot2
        {
            public DetailAngkot2() { }
            public DetailAngkot2(string NamaAngkot, string WarnaAngkot, string Tarif, string JalurTrayek)
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