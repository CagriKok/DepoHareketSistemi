using CagriKok.VarlikKatmani.Models;
using CagriKok.VeriKatmani.DatabaseAccess;
using CagriKok.VeriKatmani.Repositories.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CagriKok.VeriKatmani.Repositories.Concrete
{
    public class KullaniciRepository : Repository<Kullanici>, IKullaniciRepository
    {
        public KullaniciRepository(AppDbContext context) : base(context)
        {
        }

        public Kullanici Giris(string eposta, string parola)
        {
            return context.Set<Kullanici>().FirstOrDefault(x =>
             x.EPosta.ToLower().Equals(eposta.ToLower()) &&
             x.Parola.Equals(parola));
        }


        public bool Login(string eposta, string parola)
        {
            if (context.Set<Kullanici>().FirstOrDefault(x =>
            x.EPosta.ToLower().Equals(eposta.ToLower()) &&
            x.Parola.Equals(parola)) != null)

                return true;
            else
                return false;
        }
    }
}
