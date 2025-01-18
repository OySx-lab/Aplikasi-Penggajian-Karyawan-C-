using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aplikasi_Karyawan
{
    public class Absensi
    {
        public string NIK { get; set; }
        public string NamaKaryawan { get; set; }
        public DateTime Tanggal { get; set; }
        public TimeSpan JamMasuk { get; set; }
        public TimeSpan JamKeluar { get; set; }
    }

}
