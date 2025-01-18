using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Aplikasi_Karyawan;

namespace Aplikasi_Karyawan
{
    public class Karyawan
    {
        public string LoggedInUser { get; set; }
        public string NIK { get; set; }
        public string NamaKaryawan { get; set; }
        public string Jabatan { get; set; }
        public DateTime Tanggal { get; set; }
        public TimeSpan JamMasuk { get; set; }
        public TimeSpan JamKeluar { get; set; }
        public decimal GajiPokok { get; set; }
        public decimal TunjanganJabatan { get; set; }
        public decimal TunjanganMakan { get; set; }
        public decimal TunjanganTransportasi { get; set; }
        public string Bulan { get; set; }
        public int Alpa { get; set; }
        public int Telat { get; set; }
        public int Izin { get; set; }
        public int JumlahHariKerja { get; set; }
        public int JumlahJamLembur { get; set; }
        public decimal GajiLembur { get; set; }
        public decimal PotonganAlfa { get; set; }
        public decimal GajiBersih { get; set; }

        public void HitungGaji()
        {
            SetGajiPokokAndTunjangan();
            HitungPotongan();
            HitungGajiLembur();
            HitungGajiAkhir();
            HitungTunjanganMakanTransport();
        }

        protected virtual void SetGajiPokokAndTunjangan()
        {
            switch (Jabatan)
            {
                case "Leader":
                    GajiPokok = 5000000m;
                    TunjanganJabatan = 1000000m;
                    break;
                case "Karyawan":
                    GajiPokok = 2500000m;
                    TunjanganJabatan = 500000m;
                    break;
                default:
                    GajiPokok = 0m;
                    TunjanganJabatan = 0m;
                    break;
            }
        }
        protected virtual void HitungTunjanganMakanTransport()
        {
            
            decimal uangMakanPerHari = 25000m;
            int hariEfektif = JumlahHariKerja - Alpa;
            TunjanganMakan = hariEfektif * uangMakanPerHari;

     
            decimal uangTransportPerHari = 25000m;
            TunjanganTransportasi = hariEfektif * uangTransportPerHari;
        }

        protected virtual void HitungPotongan()
        {
            decimal potonganAlpha = Alpa * 100000m;
            decimal potonganTelat = Telat * 15000m;
            decimal potonganIzin = Izin * (GajiPokok / 30 * 0.5m);
            PotonganAlfa = potonganAlpha + potonganTelat + potonganIzin;
        }

        protected virtual void HitungGajiLembur()
        {
            GajiLembur = JumlahJamLembur * 50000m;
        }
        
        private void HitungGajiAkhir()
        {
            GajiBersih = GajiPokok + TunjanganJabatan + TunjanganMakan + TunjanganTransportasi + GajiLembur - PotonganAlfa;
        }


    }
}
