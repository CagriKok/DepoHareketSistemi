using CagriKok.VarlikKatmani.Models;
using CagriKok.VeriKatmani;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CagriKok.IsKatmani.Manager
{
    public class MalTurManager : IDisposable
    {
        private readonly UnitOfWork unitOfWork;

        public MalTurManager()
            => unitOfWork = new UnitOfWork();

        public List<MalTur> Listele()
            => unitOfWork.MalTurRepository.GetAll().ToList();

        public MalTur GetMalTur(int id)
            => unitOfWork.MalTurRepository.GetItem(id);

        public MalTur Ekle(MalTur item)
        {
            var maltur = unitOfWork.MalTurRepository.Add(item);
            unitOfWork.Save();
            return maltur;
        }

        public MalTur Guncelle(MalTur item)
        {
            var maltur = unitOfWork.MalTurRepository.Update(item);
            unitOfWork.Save();
            return maltur;
        }


        public void Sil(int id)
        {
            unitOfWork.MalTurRepository.Remove(id);
            unitOfWork.Save();
        }

        public void Dispose()
        {
            unitOfWork?.Dispose();
            GC.SuppressFinalize(this);
        }

    }
}
