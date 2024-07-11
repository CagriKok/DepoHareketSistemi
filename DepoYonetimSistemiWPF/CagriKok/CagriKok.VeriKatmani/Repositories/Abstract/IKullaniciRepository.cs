using CagriKok.VarlikKatmani.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CagriKok.VeriKatmani.Repositories.Abstract
{
    public interface IKullaniciRepository : IRepository<Kullanici>
    {
        bool Login(string eposta, string parola);

        Kullanici Giris(string eposta, string parola);
    }
}
