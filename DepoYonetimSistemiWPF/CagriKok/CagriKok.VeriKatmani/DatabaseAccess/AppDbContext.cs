using CagriKok.VarlikKatmani.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CagriKok.VeriKatmani.DatabaseAccess
{
    public class AppDbContext : DbContext
    {
        public DbSet<Depo> Depolar { get; set; }
        public DbSet<DepoHareket> DepoHareketleri { get; set; }
        public DbSet<Kullanici> Kullanicilar { get; set; }
        public DbSet<MalTur> MalTurleri { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<DepoHareket>()
                .HasRequired<Depo>(d => d.Depo)
                .WithMany()
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<DepoHareket>()
               .HasRequired<MalTur>(mt => mt.MalTur)
               .WithMany()
               .WillCascadeOnDelete(false);

        }
        public AppDbContext() : base("CagriKokGorsel8")
        {
            Database.SetInitializer(new MyDatabaseInitializer());
        }

        public class MyDatabaseInitializer : CreateDatabaseIfNotExists<AppDbContext>
        {
            protected override void Seed(AppDbContext context)
            {
                context.Kullanicilar.Add(new Kullanici { Ad = "Çağrı", Soyad = "Kök", EPosta = "kokcagri224@gmail.com", Parola = "1234", ParolaTekrar = "1234", Yetkiler = VarlikKatmani.Models.Enums.Yetki.Admin });
                context.Kullanicilar.Add(new Kullanici { Ad = "Çağrı", Soyad = "Kök", EPosta = "kokcagri225@gmail.com", Parola = "123", ParolaTekrar = "123", Yetkiler = VarlikKatmani.Models.Enums.Yetki.DepoSorumlusu });
                context.Kullanicilar.Add(new Kullanici { Ad = "Şuayip", Soyad = "Kök", EPosta = "kokcagri226@gmail.com", Parola = "12345", ParolaTekrar = "12345", Yetkiler = VarlikKatmani.Models.Enums.Yetki.DepoSorumlusu });


                context.SaveChanges();

                context.Depolar.Add(new Depo { Ad = "Malzeme Deposu" });
                context.Depolar.Add(new Depo { Ad = "Şube Depo" });
                context.Depolar.Add(new Depo { Ad = "Geçici Depo" });

                context.SaveChanges();

                context.MalTurleri.Add(new MalTur { Ad = "Mal1" });
                context.MalTurleri.Add(new MalTur { Ad = "Mal2" });
                context.MalTurleri.Add(new MalTur { Ad = "Mal3" });

                context.SaveChanges();

                context.DepoHareketleri.Add(new DepoHareket { Miktar = 2, TarihSaat = DateTime.Now, Description = "Açıklama 1", DepoId = 1, MalTurId = 1, HareketTipleri = VarlikKatmani.Models.Enums.DepoHareketTipleri.Giris, Birimler = VarlikKatmani.Models.Enums.Birim.Koli });
                context.DepoHareketleri.Add(new DepoHareket { Miktar = 3, TarihSaat = DateTime.Now, Description = "Açıklama 2", DepoId = 2, MalTurId = 2, HareketTipleri = VarlikKatmani.Models.Enums.DepoHareketTipleri.Giris, Birimler = VarlikKatmani.Models.Enums.Birim.Adet });
                context.DepoHareketleri.Add(new DepoHareket { Miktar = 4, TarihSaat = DateTime.Now, Description = "Açıklama 3", DepoId = 3, MalTurId = 3, HareketTipleri = VarlikKatmani.Models.Enums.DepoHareketTipleri.Cikis, Birimler = VarlikKatmani.Models.Enums.Birim.Kg });

                context.SaveChanges();

            }
        }
    }
}
