using CagriKok.VarlikKatmani.Models;
using CagriKok.VeriKatmani;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CagriKok.IsKatmani.Manager
{
    public class DepoManager : IDisposable
    {
        private readonly UnitOfWork unitOfWork;
        public DepoManager()
            => unitOfWork = new UnitOfWork();

        public List<Depo> Listele()
            => unitOfWork.DepoRepository.GetAll().ToList();

        public Depo GetDepo(int id)
            => unitOfWork.DepoRepository.GetItem(id);

        public Depo Ekle(Depo item)
        {
            var depo = unitOfWork.DepoRepository.Add(item);
            unitOfWork.Save();
            return depo;
        }

        public Depo Guncelle(Depo item)
        {
            var depo = unitOfWork.DepoRepository.Update(item);
            unitOfWork.Save();
            return depo;
        }

        public void Sil(int id)
        {
            unitOfWork.DepoRepository.Remove(id);
            unitOfWork.Save();
        }

        public void Dispose()
        {
            unitOfWork?.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}
