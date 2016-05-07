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
    public partial class Detail4 : PhoneApplicationPage
    {
        public Detail4()
        {
            InitializeComponent();
            DetailAngkot4Text.DataContext = new DetailAngkot4("Gunung Batu - Stasiun Hall", "Biru Muda - Strip Kuning - Hijau", "Rp.4000 - Rp.8500", "Terminal Gunung Batu - Jl. Gunung Batu – Jl. DR. Junjunan (Terusan Pasteur) – Jl. Westhoff – Jl. Pasteur – BEC (Pasteur) – Jl. Cihampelas – Jl. Wastu Kencana – Jl. Pajajaran – Jl. Cicendo – Jl. Kebon Kawung – Stasiun Bandung (Kebon Kawung) – Jl. Pasir Kaliki – Jl. Kebon Jati - Jl. Suniaraja – Terminal Stasiun ===== Terminal Stasiun – Jl. Otista - Jl. Stasiun Timur – Viaduct – Jl. Perintis Kemerdekaan – Jl. Wastu Kencana – Jl. Pajajaran – Jl. Cihampelas – Jl. Rivai – Jl. Rum – Jl. Gunawan – Jl. Otten – Jl. Pasteur – BEC (Pasteur) - Jl. Westhoff – Jl. DR. Junjunan (Terusan Pasteur) – Jl. Gunung Batu – Terminal Gunung Batu");
        }

        public class DetailAngkot4
        {
            public DetailAngkot4() { }
            public DetailAngkot4(string NamaAngkot, string WarnaAngkot, string Tarif, string JalurTrayek)
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