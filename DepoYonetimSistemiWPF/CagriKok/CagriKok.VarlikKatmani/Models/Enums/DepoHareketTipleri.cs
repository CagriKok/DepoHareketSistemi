using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CagriKok.VarlikKatmani.Models.Enums
{
    public enum DepoHareketTipleri
    {
        [Description("Giris")]
        Giris = 1,
        [Description("Cikis")]
        Cikis = 2
    }
}
