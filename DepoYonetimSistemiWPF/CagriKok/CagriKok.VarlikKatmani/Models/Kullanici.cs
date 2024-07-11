using CagriKok.VarlikKatmani.Models.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CagriKok.VarlikKatmani.Models
{
    public class Kullanici
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public string Ad { get; set; }

        public string Soyad { get; set; }

        [NotMapped]
        public string AdSoyad
        {
            get
            {
                return this.Ad + "" + this.Soyad;
            }
        }

        public string EPosta { get; set; }
        public string Parola { get; set; }
        public string ParolaTekrar { get; set; }
        public Yetki Yetkiler { get; set; } = Yetki.DepoSorumlusu;
    }
}
