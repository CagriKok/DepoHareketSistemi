using CagriKok.VarlikKatmani.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CagriKok.VeriKatmani.Repositories.Abstract
{
    public interface IDepoHareketRepository : IRepository<DepoHareket>
    {
        ICollection<DepoHareket> GetAllWithDepoAndMalTur();
        DepoHareket GetDepoHareketlerByMalTurId(int id);
    }
}
