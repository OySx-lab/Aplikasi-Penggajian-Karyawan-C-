using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aplikasi_Karyawan
{
    public class Leader : Karyawan
    {
        protected override void SetGajiPokokAndTunjangan()
        {
            GajiPokok = 5000000m;
            TunjanganJabatan = 1000000m;
        }

        protected override void HitungPotongan()
        {
            decimal potonganAlpha = Alpa * 250000m;
            decimal potonganTelat = Telat * 40000m;
            decimal potonganIzin = Izin * (GajiPokok / 30 * 0.5m);
            PotonganAlfa = potonganAlpha + potonganTelat + potonganIzin;
        }

        protected override void HitungGajiLembur()
        {
            GajiLembur = JumlahJamLembur * 100000m;
        }
    }
}
