using System;
using System.Collections.Generic;

namespace backend.Models
{
    public partial class DatLich
    {
        public int DatLich1 { get; set; }
        public int? ChuongTrinh { get; set; }
        public int? Xe { get; set; }

        public virtual ChuongTrinh? ChuongTrinhNavigation { get; set; }
        public virtual Xe? XeNavigation { get; set; }
    }
}
