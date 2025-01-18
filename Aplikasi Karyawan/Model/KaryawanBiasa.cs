using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aplikasi_Karyawan
{
    public class KaryawanBiasa : Karyawan
    {
        protected override void SetGajiPokokAndTunjangan()
        {
            GajiPokok = 2500000m;
            TunjanganJabatan = 500000m;
        }
    }

}
