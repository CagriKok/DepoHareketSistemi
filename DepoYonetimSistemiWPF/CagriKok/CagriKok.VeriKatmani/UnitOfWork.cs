using CagriKok.VarlikKatmani.Models;
using CagriKok.VeriKatmani.DatabaseAccess;
using CagriKok.VeriKatmani.Repositories.Abstract;
using CagriKok.VeriKatmani.Repositories.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CagriKok.VeriKatmani
{
    public class UnitOfWork : IDisposable
    {
        private AppDbContext context;
        private IKullaniciRepository _kullaniciRepository;
        private IDepoHareketRepository _depoHareketRepository;
        private IRepository<Depo> _depoRepository;
        private IRepository<MalTur> _malTurRepository;
        public UnitOfWork() => context = new AppDbContext();

        public IKullaniciRepository KullaniciRepository
        {
            get
            {
                if (_kullaniciRepository == null)
                {
                    _kullaniciRepository = new KullaniciRepository(context);
                }
                return _kullaniciRepository;
            }
        }

        public IDepoHareketRepository DepoHareketRepository
        {
            get
            {
                if (_depoHareketRepository == null)
                {
                    _depoHareketRepository = new DepoHareketRepository(context);
                }
                return _depoHareketRepository;
            }
        }

        public IRepository<MalTur> MalTurRepository
        {
            get
            {
                if (_malTurRepository == null)
                {
                    _malTurRepository = new Repository<MalTur>(context);
                }
                return _malTurRepository;
            }
        }

        public IRepository<Depo> DepoRepository
        {
            get
            {
                if (_depoRepository == null)
                {
                    _depoRepository = new Repository<Depo>(context);
                }
                return _depoRepository;
            }
        }


        public void Save()
        {
            using (var transaction = context.Database.BeginTransaction())
            {
                try
                {
                    context.SaveChanges();
                    transaction.Commit();
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    throw ex;
                }
            }
        }


        public void Dispose()
        {
            context?.Dispose();
            _kullaniciRepository?.Dispose();
            _depoHareketRepository?.Dispose();
            _malTurRepository?.Dispose();
            _depoRepository?.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}

