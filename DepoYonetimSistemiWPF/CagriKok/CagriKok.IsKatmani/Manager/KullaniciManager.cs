using CagriKok.VarlikKatmani.Models;
using CagriKok.VeriKatmani;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CagriKok.IsKatmani.Manager
{
    public class KullaniciManager : IDisposable
    {
        private readonly UnitOfWork unitOfWork;
        public KullaniciManager()
            => unitOfWork = new UnitOfWork();

        public List<Kullanici> Listele()
            => unitOfWork.KullaniciRepository.GetAll().ToList();

        public Kullanici GetKullanici(int id)
            => unitOfWork.KullaniciRepository.GetItem(id);

        public Kullanici Ekle(Kullanici item)
        {
            var kullanici = unitOfWork.KullaniciRepository.Add(item);
            unitOfWork.Save();
            return kullanici;
        }

        public Kullanici Guncelle(Kullanici item)
        {
            var kullanici = unitOfWork.KullaniciRepository.Update(item);
            unitOfWork.Save();
            return kullanici;
        }


        public void Sil(int id)
        {
            unitOfWork.KullaniciRepository.Remove(id);
            unitOfWork.Save();
        }

        public void Dispose()
        {
            unitOfWork?.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}
