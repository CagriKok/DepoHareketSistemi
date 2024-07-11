using CagriKok.VarlikKatmani.Models;
using CagriKok.VeriKatmani;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CagriKok.IsKatmani.Manager
{
    public class DepoHareketManager : IDisposable
    {
        private readonly UnitOfWork unitOfWork;

        public DepoHareketManager()
           => unitOfWork = new UnitOfWork();

        public List<DepoHareket> Listele()
           => unitOfWork.DepoHareketRepository.GetAllWithDepoAndMalTur().ToList();

        public DepoHareket GetDepoHareket(int id)
          => unitOfWork.DepoHareketRepository.GetDepoHareketlerByMalTurId(id);

        public DepoHareket Ekle(DepoHareket item)
        {
            var depoHareket = unitOfWork.DepoHareketRepository.Add(item);       
            unitOfWork.Save();
            return depoHareket;
        }

        public DepoHareket Guncelle(DepoHareket item)
         {
            var depohareket = unitOfWork.DepoHareketRepository.Update(item);
            unitOfWork.Save();
            return depohareket;
         }

        public void Sil(int id)
        {
            unitOfWork.DepoHareketRepository.Remove(id);
            unitOfWork.Save();
        }

        public void Dispose()
        {
            unitOfWork?.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}
