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
    public partial class Detail3 : PhoneApplicationPage
    {
        public Detail3()
        {
            InitializeComponent();
            DetailAngkot3Text.DataContext = new DetailAngkot3("Ciroyom - Sarijadi", "Hijau Strip Putih", "Rp.4000 - Rp.8500", "Terminal Ciroyom – Jl. Arjuna – Jl. Pajajaran – Jl. Baladewa – Jl. Dursasana – Jl. Pasir Kaliki – Jl. Sukajadi – Jl. Sindang Sirna – Jl. Sindang Sirna – Jl. Geger Kalong Hilir – Jl. Sari Endah – Jl. Sari Jadi – Jl. Sari Manah (Sarijadi) – Jl. Sari Wangi (Sarijadi) – Terminal Sarijadi ===== Terminal Sarijadi – Jl. Sari Wangi (Sarijadi) – Jl. Sari Manah (Sarijadi) – Jl. Sari Asih (Sarijadi) – Jl. Sari Jadi – Jl. Geger Kalong Hilir – Jl. Cipedes – Jl. Sindang Sirna – Jl. Sirnagalih – Jl. Sukajadi – Jl. Sukamaju – Jl. Sederhana – RS. Hasan Sadikin - Jl. Pasir Kaliki – Jl. Pajajaran – Jl. Abdul Rahman Saleh – Jl. Ciroyom – Terminal Ciroyom");
        }

        public class DetailAngkot3
        {
            public DetailAngkot3() { }
            public DetailAngkot3(string NamaAngkot, string WarnaAngkot, string Tarif, string JalurTrayek)
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