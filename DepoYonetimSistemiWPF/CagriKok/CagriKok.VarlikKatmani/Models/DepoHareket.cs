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
    public class DepoHareket
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public decimal Miktar { get; set; }

        public DateTime TarihSaat { get; set; } = DateTime.Now;

        public string Description { get; set; }

        public int DepoId { get; set; }
        [ForeignKey(nameof(DepoId))]
        public Depo Depo { get; set; }

        public int MalTurId { get; set; }
        [ForeignKey(nameof(MalTurId))]
        public MalTur MalTur { get; set; }

        public DepoHareketTipleri HareketTipleri { get; set; }
        public Birim Birimler { get; set; }

    }
}
