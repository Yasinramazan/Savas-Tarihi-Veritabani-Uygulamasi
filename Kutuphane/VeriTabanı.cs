using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.IO;
using Entities;

namespace Kutuphane
{
    public class VeriTabanı
    {
        List<General> generalListesi;
        List<DevletAdamlari> devletAdamlariListesi;
        List<Muharebe> muharebeListesi;
        List<Savaslar> savaslarListesi;
        List<Harita> haritaListesi;

        public VeriTabanı()
        {
            kontrol();
            generalListesi = new List<General>();
            devletAdamlariListesi = new List<DevletAdamlari>();
            muharebeListesi = new List<Muharebe>();
            savaslarListesi = new List<Savaslar>();
            haritaListesi = new List<Harita>();
        }

        private void kontrol()
        {
            if (!Directory.Exists(@"C:\\Users\\yasin\\OneDrive\\Belgeler\\Tarih"))
                Directory.CreateDirectory(@"C:\\Users\\yasin\\OneDrive\\Belgeler\\Tarih");

            if(!File.Exists(@"C:\\Users\\yasin\\OneDrive\\Belgeler\\Tarih\\Generaller.json"))
                using (File.Create(@"C:\\Users\\yasin\\OneDrive\\Belgeler\\Tarih\\Generaller.json")) { }
            
            if(!File.Exists(@"C:\\Users\\yasin\\OneDrive\\Belgeler\\Tarih\\Devlet Adamları.json"))
                using (File.Create(@"C:\\Users\\yasin\\OneDrive\\Belgeler\\Tarih\\Devlet Adamları.json")) { }
            
            if(!File.Exists(@"C:\\Users\\yasin\\OneDrive\\Belgeler\\Tarih\\Haritalar.json"))
                using (File.Create(@"C:\\Users\\yasin\\OneDrive\\Belgeler\\Tarih\\Haritalar.json")) { }

            if(!File.Exists(@"C:\\Users\\yasin\\OneDrive\\Belgeler\\Tarih\\Muharebeler.json"))
                using (File.Create(@"C:\\Users\\yasin\\OneDrive\\Belgeler\\Tarih\\Muharebeler.json")) { }

            if(!File.Exists(@"C:\\Users\\yasin\\OneDrive\\Belgeler\\Tarih\\Savaşlar.json"))
                using (File.Create(@"C:\\Users\\yasin\\OneDrive\\Belgeler\\Tarih\\Savaşlar.json")) { }
        }

        public void generalYaz()
        {
            string general = Newtonsoft.Json.JsonConvert.SerializeObject(generalListesi);
            File.WriteAllText(@"C:\\Users\\yasin\\OneDrive\\Belgeler\\Tarih\\Generaller.json", general);
        }
        public void generalOku()
        {
            string general = File.ReadAllText(@"C:\\Users\\yasin\\OneDrive\\Belgeler\\Tarih\\Generaller.json");
            if (Newtonsoft.Json.JsonConvert.DeserializeObject<List<General>>(general) != null)
                generalListesi = Newtonsoft.Json.JsonConvert.DeserializeObject<List<General>>(general);
        }

        public void devletAdamiYaz()
        {
            string devlet = Newtonsoft.Json.JsonConvert.SerializeObject(devletAdamlariListesi);
            File.WriteAllText(@"C:\\Users\\yasin\\OneDrive\\Belgeler\\Tarih\\Devlet Adamları.json", devlet);
        }

        public void devletAdamıOku()
        {
            string devlet = File.ReadAllText(@"C:\\Users\\yasin\\OneDrive\\Belgeler\\Tarih\\Devlet Adamları.json");
            if (Newtonsoft.Json.JsonConvert.DeserializeObject<List<DevletAdamlari>>(devlet) != null)
                devletAdamlariListesi = Newtonsoft.Json.JsonConvert.DeserializeObject<List<DevletAdamlari>>(devlet);
        }

        public void muharebeYaz()
        {
            string muharebe = Newtonsoft.Json.JsonConvert.SerializeObject(muharebeListesi);
            File.WriteAllText(@"C:\\Users\\yasin\\OneDrive\\Belgeler\\Tarih\\Muharebeler.json", muharebe);
        }

        public void muharebeOku()
        {
            string muharebe = File.ReadAllText(@"C:\\Users\\yasin\\OneDrive\\Belgeler\\Tarih\\Muharebeler.json");
            if (Newtonsoft.Json.JsonConvert.DeserializeObject<List<Muharebe>>(muharebe) != null)
                muharebeListesi = Newtonsoft.Json.JsonConvert.DeserializeObject<List<Muharebe>>(muharebe);
        }

        public void savasYaz()
        {
            string savas = Newtonsoft.Json.JsonConvert.SerializeObject(savaslarListesi);
            File.WriteAllText(@"C:\\Users\\yasin\\OneDrive\\Belgeler\\Tarih\\Savaşlar.json", savas);
        }

        public void savasOku()
        {
            string savas = File.ReadAllText(@"C:\\Users\\yasin\\OneDrive\\Belgeler\\Tarih\\Savaşlar.json");
            if (Newtonsoft.Json.JsonConvert.DeserializeObject<List<Savaslar>>(savas) != null)
                savaslarListesi = Newtonsoft.Json.JsonConvert.DeserializeObject<List<Savaslar>>(savas);
        }

        public void haritaYaz()
        {
            string harita = Newtonsoft.Json.JsonConvert.SerializeObject(haritaListesi);
            File.WriteAllText(@"C:\\Users\\yasin\\OneDrive\\Belgeler\\Tarih\\Haritalar.json", harita);
        }

        public void haritaOku()
        {
            string harita = File.ReadAllText(@"C:\\Users\\yasin\\OneDrive\\Belgeler\\Tarih\\Haritalar.json");
            if (Newtonsoft.Json.JsonConvert.DeserializeObject<List<Savaslar>>(harita) != null)
                haritaListesi = Newtonsoft.Json.JsonConvert.DeserializeObject<List<Harita>>(harita);
        }

        public List<General> generalVer()
        {
            generalOku();
            return generalListesi;
        }

        public List<Harita> haritaVer()
        {
            haritaOku();
            return haritaListesi;
        }

        public int yeniGeneralEkle(General g)
        {
            int bayrak = Try.TryCatch(() =>
                {
                    generalOku();
                    if(!generalListesi.Contains(g))
                        generalListesi.Add(g);
                    generalYaz();
                });

            return bayrak;
        }

        public int yeniDevletAdamiEkle(DevletAdamlari d)
        {
            int bayrak = Try.TryCatch(() =>
             {
                 devletAdamıOku();
                 if(!devletAdamlariListesi.Contains(d))
                    devletAdamlariListesi.Add(d);
                 devletAdamiYaz();
             });
            return bayrak;
        }
        public int yeniMuharebeEkle(Muharebe m)
        {
            int bayrak = Try.TryCatch(()=>
            {
                muharebeOku();
                muharebeListesi.Add(m);
                muharebeYaz();
            });
            return bayrak;
        }

        public string aciklamaVer()
        {
            Random rand = new Random();
            int rast = rand.Next(1, 5);
            int sayi;
            string aciklama;
            
            if (rast == 1)
            {
                generalOku();
                if (generalListesi != null || generalListesi.Count != 0)
                {
                    sayi = generalListesi.Count;
                    General gen = new General();
                    gen = generalListesi[rand.Next(0, sayi-1)];
                    aciklama = gen.aciklama;
                }
                else
                    aciklama = "Hoşgeldiniz";
                
            }
            else if (rast == 2)
            {
                if (devletAdamlariListesi != null || devletAdamlariListesi.Count != 0)
                {
                    devletAdamıOku();
                sayi = devletAdamlariListesi.Count;
                DevletAdamlari dev = new DevletAdamlari();
                dev = devletAdamlariListesi[rand.Next(0,sayi-1)];
                aciklama = dev.aciklama;
                }
                else
                    aciklama = "Hoşgeldiniz";
            }
            else if (rast == 3)
            {
                if (muharebeListesi != null || muharebeListesi.Count != 0)
                {
                    muharebeOku();
                    sayi = muharebeListesi.Count;
                    Muharebe muh = new Muharebe();
                    muh = muharebeListesi[rand.Next(0, sayi-1)];
                    aciklama = muh.aciklama;
                }
                else
                    aciklama = "Hoşgeldiniz";
                }
            else if (rast == 4)
            {
                if (savaslarListesi != null || savaslarListesi.Count != 0)
                {
                    savasOku();
                    sayi = savaslarListesi.Count;
                    Savaslar sav = new Savaslar();
                    sav = savaslarListesi[rand.Next(0, sayi-1)];
                    aciklama = sav.aciklama;
                }
                else
                    aciklama = "Hoşgeldiniz";
            }
            else
            {
                if (haritaListesi != null || haritaListesi.Count != 0)
                {
                    haritaOku();
                sayi = haritaListesi.Count;
                Harita har = new Harita();
                har = haritaListesi[rand.Next(0, sayi-1)];
                aciklama = har.aciklama;
                }
                else
                    aciklama = "Hoşgeldiniz";
            }

            return aciklama;
        }

        public int savasYaz(Savaslar s)
        {
            int bayrak = Try.TryCatch(()=>
            {
                savasOku();
                savaslarListesi.Add(s);
                savasYaz();
            });
            return bayrak;
        }

        public List<Muharebe> muharebeVer()
        {
            muharebeOku();
            return muharebeListesi;
        }

        public int haritaYaz(Harita h)
        {
            int bayrak = Try.TryCatch(() =>
              {
                  haritaOku();
                  haritaListesi.Add(h);
                  haritaYaz();
              });
            return bayrak;
        }

       public List<DevletAdamlari> devletAdamiVer()
        {
            devletAdamıOku();
            return devletAdamlariListesi;
        }
        
        public List<Savaslar> savasVer()
        {
            savasOku();
            return savaslarListesi;
        }

        public int savasSil(Guid id)
        {
            savasOku();
            int bayrak = Try.TryCatch(() =>
            {
                Savaslar silinecek = savaslarListesi.Find(i => i.id == id);
                savaslarListesi.Remove(silinecek);
                savasYaz();
            });
            return bayrak;
        }

        public int muharebeSil(Guid id)
        {
            muharebeOku();
            int bayrak = Try.TryCatch(() =>
            {
                Muharebe silinecek = muharebeListesi.Find(i => i.id == id);
                muharebeListesi.Remove(silinecek);
                muharebeYaz();
            });
            return bayrak;
        }
        public int generalSil(Guid id)
        {
            generalOku();
            int bayrak = Try.TryCatch(() =>
            {
                General silinecek = generalListesi.Find(i => i.generalId == id);
                generalListesi.Remove(silinecek);
                generalYaz();
            });
            return bayrak;
        }

        public int devletAdamiSil(Guid id)
        {
            devletAdamıOku();
            int bayrak = Try.TryCatch(() =>
            {
                DevletAdamlari silinecek = devletAdamlariListesi.Find(i => i.devletId == id);
                devletAdamlariListesi.Remove(silinecek);
                devletAdamiYaz();
            });
            return bayrak;
        }

        public void kisiGeneralSil(Guid id)
        {
            Try.TryCatch(() =>
            {
                generalOku();
                int index = generalListesi.FindIndex(i => i.generalId == id);
                generalListesi.Remove(generalListesi[index]);
                generalYaz();

            });
        }

        public void kisiDevletAdamiSil(Guid id)
        {
            Try.TryCatch(() =>
            {
                devletAdamıOku();
                int index = devletAdamlariListesi.FindIndex(i => i.devletId == id);
                devletAdamlariListesi.Remove(devletAdamlariListesi[index]);
                devletAdamiYaz();

            });
        }

        

        public int haritaSil(Guid id)
        {
            haritaOku();
            int bayrak = Try.TryCatch(() =>
            {
                Harita silinecek = haritaListesi.Find(i => i.id == id);
                haritaListesi.Remove(silinecek);
                haritaYaz();
            });
            return bayrak;
        }

        public int savasDuzenle(Savaslar s)
        {
            savasOku();
            int bayrak = Try.TryCatch(() =>
            {
                int index = savaslarListesi.FindIndex(i => i.id == s.id);
                savaslarListesi[index].id = s.id;
                savaslarListesi[index].ad = s.ad;
                savaslarListesi[index].baslangic = s.baslangic;
                savaslarListesi[index].bitis = s.bitis;
                savaslarListesi[index].kazananlar = s.kazananlar;
                savaslarListesi[index].kaybedenler = s.kaybedenler;
                savaslarListesi[index].kazananZayiati = s.kazananZayiati;
                savaslarListesi[index].kaybedenZayiati = s.kaybedenZayiati;
                savaslarListesi[index].kazananGeneraller = s.kazananGeneraller;
                savaslarListesi[index].kaybedenGeneraller = s.kaybedenGeneraller;
                savaslarListesi[index].kaynak = s.kaynak;
                savaslarListesi[index].aciklama = s.aciklama;
                savasYaz();
            });
            return bayrak;
        }

        public int muharebeDuzenle(Muharebe m)
        {
            int bayrak = Try.TryCatch(() =>
            {
                muharebeOku();
                int index = muharebeListesi.FindIndex(i => i.id == m.id);
                muharebeListesi[index].id = m.id;
                muharebeListesi[index].ad = m.ad;
                
                muharebeListesi[index].aciklama = m.aciklama;
                muharebeListesi[index].tarih = m.tarih;
                muharebeListesi[index].kaynak = m.kaynak;
                muharebeListesi[index].kazananlar = m.kazananlar;
                muharebeListesi[index].kaybedenler = m.kaybedenler;
                muharebeListesi[index].kazananZayiati = m.kazananZayiati;
                muharebeListesi[index].kaybedenZayiati = m.kaybedenZayiati;
                muharebeListesi[index].kazananGeneraller = m.kazananGeneraller;
                muharebeListesi[index].kaybedenGeneraller = m.kaybedenGeneraller;

                muharebeYaz();
            });
            return bayrak;
        }

        public int haritaDuzenle(Harita h)
        {
            int bayrak = Try.TryCatch(() =>
            {
                haritaOku();
                int index = haritaListesi.FindIndex(i => i.id == h.id);
                haritaListesi[index].id = h.id;
                haritaListesi[index].harita = h.harita;
                haritaListesi[index].yerAdi = h.yerAdi;
                haritaListesi[index].aciklama = h.aciklama;
                haritaListesi[index].kaynak = h.kaynak;
                haritaListesi[index].muharebe = h.muharebe;
                haritaListesi[index].resim = h.resim;
                haritaListesi[index].tarih = h.tarih;
                haritaYaz();
            });
            return bayrak;
        }

        public int generalDuzenle(General g)
        {
            int bayrak = Try.TryCatch(() =>
              {
                  generalOku();
                  
                      int index = generalListesi.FindIndex(i => i.generalId == g.generalId);
                      if (index != -1)
                      {
                          generalListesi[index].ad = g.ad;
                          generalListesi[index].soyad = g.soyad;
                          generalListesi[index].dogumTarihi = g.dogumTarihi;
                          generalListesi[index].olumTarihi = g.olumTarihi;
                          generalListesi[index].dogumYeri = g.dogumYeri;
                          generalListesi[index].olumYeri = g.olumYeri;
                          generalListesi[index].girdigiSavaslar = g.girdigiSavaslar;
                          generalListesi[index].kaynak = g.kaynak;
                          generalListesi[index].aciklama = g.aciklama;
                          generalListesi[index].foto = g.foto;
                          generalListesi[index].general = g.general;
                          generalListesi[index].devletAdami = g.devletAdami;
                          generalListesi[index].HizmetYillari = g.HizmetYillari;
                          generalListesi[index].generalId = g.generalId;
                      }
                      else
                      {
                          yeniGeneralEkle(g);
                      }
                  
                  generalYaz();
              });
            return bayrak;
        }

        public int devletAdamiDuzenle(DevletAdamlari d)
        {
            int bayrak = Try.TryCatch(() =>
            {
                devletAdamıOku();
                int index = devletAdamlariListesi.FindIndex(i => i.devletId == d.devletId);
                if (index != -1)
                {
                    devletAdamlariListesi[index].ad = d.ad;
                    devletAdamlariListesi[index].soyad = d.soyad;
                    devletAdamlariListesi[index].dogumTarihi = d.dogumTarihi;
                    devletAdamlariListesi[index].olumTarihi = d.olumTarihi;
                    devletAdamlariListesi[index].dogumYeri = d.dogumYeri;
                    devletAdamlariListesi[index].olumYeri = d.olumYeri;
                    devletAdamlariListesi[index].girdigiSavaslar = d.girdigiSavaslar;
                    devletAdamlariListesi[index].kaynak = d.kaynak;
                    devletAdamlariListesi[index].aciklama = d.aciklama;
                    devletAdamlariListesi[index].foto = d.foto;
                    devletAdamlariListesi[index].general = d.general;
                    devletAdamlariListesi[index].devletAdami = d.devletAdami;
                    devletAdamlariListesi[index].HizmetYillari = d.HizmetYillari;
                    devletAdamlariListesi[index].devletId = d.devletId;
                }
                else
                    yeniDevletAdamiEkle(d);
                devletAdamiYaz();
            });
            return bayrak;
        }
        
    }

}
