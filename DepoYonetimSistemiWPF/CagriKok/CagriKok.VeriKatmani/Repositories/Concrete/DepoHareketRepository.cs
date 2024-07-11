using CagriKok.VarlikKatmani.Models;
using CagriKok.VeriKatmani.DatabaseAccess;
using CagriKok.VeriKatmani.Repositories.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace CagriKok.VeriKatmani.Repositories.Concrete
{
    public class DepoHareketRepository : Repository<DepoHareket>, IDepoHareketRepository
    {
        public DepoHareketRepository(AppDbContext context) : base(context)
        {
        }
        public ICollection<DepoHareket> GetAllWithDepoAndMalTur()
            => context.DepoHareketleri.Include(x => x.Depo).Include(x => x.MalTur).ToList();

        public DepoHareket GetDepoHareketlerByMalTurId(int id)
            => context.DepoHareketleri.Include(x => x.MalTur).Include(x => x.Depo).FirstOrDefault(x => x.Id == id);
    }
}
