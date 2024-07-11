using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CagriKok.VarlikKatmani.Models.Enums
{
    public enum Birim
    {
        [Description("Adet")]
        Adet = 1,
        [Description("Kg")]
        Kg = 2,
        [Description("Koli")]
        Koli = 3
    }
}
