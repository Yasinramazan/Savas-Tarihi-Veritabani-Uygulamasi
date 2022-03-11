using System;
using System.Collections.Generic;
using Entities;
namespace Kutuphane
{
    public class BusinessLogicLayer
    {
        VeriTabanı data;
        public BusinessLogicLayer()
        {
            data = new VeriTabanı();
        }

        public string aciklamaVer()
        {
            string aciklama = data.aciklamaVer();
            return aciklama;
        }
        public int yeniEkle(string ad, string soyad, string dog, string ol, System.Collections.IList savaslar
            , string hizmetYillari, string aciklama, string gen, string dev, string foto, string dogYer, string olYer,string kaynak)
        {
            int bayrak;
            int bayrak2;
            Guid genId = Guid.NewGuid();
            Guid devId = Guid.NewGuid();

            if (!string.IsNullOrEmpty(ad) && !string.IsNullOrEmpty(soyad) && dog != null && ol != null
                && savaslar != null && !string.IsNullOrEmpty(hizmetYillari) && !string.IsNullOrEmpty(aciklama))
            {
                Kisi kisi = new Kisi();
                if (gen != null && dev != null)
                    kisi.kisiId = Guid.NewGuid();
                else
                    kisi.kisiId = Guid.Empty;

                if (gen != null)
                {
                    General general = new General();
                    general.girdigiSavaslar = new List<Savaslar>();
                    foreach (Savaslar item in savaslar)
                    {
                        general.girdigiSavaslar.Add(item);
                    }
                    general.kisiId = kisi.kisiId;
                    general.generalId = genId;
                    general.devletId = devId;
                    general.ad = ad;
                    general.soyad = soyad;
                    general.dogumTarihi = dog;
                    general.olumTarihi = ol;
                    general.HizmetYillari = hizmetYillari;
                    general.aciklama = aciklama;
                    general.foto = foto;
                    general.dogumYeri = dogYer;
                    general.olumYeri = olYer;
                    general.kaynak = kaynak;
                    general.general = true;
                    if (dev != null)
                        general.devletAdami = true;
                    bayrak = data.yeniGeneralEkle(general);
                }
                else
                    bayrak = 51;
                if (dev != null)
                {
                    DevletAdamlari devlet = new DevletAdamlari();
                    devlet.girdigiSavaslar = new List<Savaslar>();
                    foreach (Savaslar item in savaslar)
                    {
                        devlet.girdigiSavaslar.Add(item);
                    }
                    devlet.kisiId = kisi.kisiId;
                    devlet.devletId = devId;
                    devlet.generalId = genId;
                    devlet.ad = ad;
                    devlet.soyad = soyad;
                    devlet.dogumTarihi = dog;
                    devlet.olumTarihi = ol;
                    devlet.HizmetYillari = hizmetYillari;
                    devlet.aciklama = aciklama;
                    devlet.foto = foto;
                    devlet.dogumYeri = dogYer;
                    devlet.olumYeri = olYer;
                    devlet.devletAdami = true;
                    if (gen != null)
                        devlet.general = true;
                    bayrak2 = data.yeniDevletAdamiEkle(devlet);
                }
                else
                    bayrak2 = 51;


            }
            else
            {
                bayrak = -100;
                bayrak2 = -99;
            }
            return bayrak + bayrak2;
        }

        public List<General> generalVer()
        {
            List<General> liste = data.generalVer();
            return liste;
        }

        public List<Harita> haritaVer()
        {
            List<Harita> liste = data.haritaVer();
            return liste;
        }

        public int muharebeYaz(string ad, string tarih, string kazanan, string kaybeden,
            string kazananZayiati, string kaybedenZayiati, System.Collections.IList kazananGeneraller,
            System.Collections.IList kaybedenGeneraller, string aciklama, object harita,string kaynak)
        {
            int bayrak;
            if (!string.IsNullOrEmpty(ad) && !string.IsNullOrEmpty(tarih)
                && !string.IsNullOrEmpty(kazanan) && !string.IsNullOrEmpty(kaybeden)
                && !string.IsNullOrEmpty(aciklama))
            {
                string[] _kazanan = kazanan.Split(",");
                string[] _kaybeden = kaybeden.Split(",");
                string[] _kazananZayiat = kazananZayiati.Split(",");
                string[] _kaybedenzayiat = kaybedenZayiati.Split(",");
                List<string> kazananlar = new List<string>();
                List<string> kaybedenler = new List<string>();
                List<string> kaybedenZay = new List<string>();
                List<string> kazananZay = new List<string>();

                foreach (string item in _kazanan)
                    kazananlar.Add(item);
                foreach (string item in _kaybeden)
                    kaybedenler.Add(item);
                foreach (string item in _kazananZayiat)
                    kazananZay.Add(item);
                foreach (string item in _kaybedenzayiat)
                    kaybedenZay.Add(item);

                _kazanan = null;
                _kaybeden = null;
                _kazananZayiat = null;
                _kaybedenzayiat = null;


                Muharebe muharebe = new Muharebe();
                muharebe.kazananGeneraller = new List<General>();
                muharebe.kaybedenGeneraller = new List<General>();
                muharebe.id = Guid.NewGuid();
                muharebe.ad = ad;
                muharebe.tarih = tarih;
                foreach (General item in kazananGeneraller)
                    muharebe.kazananGeneraller.Add(item);
                foreach (General item in kaybedenGeneraller)
                    muharebe.kaybedenGeneraller.Add(item);
                muharebe.kazananlar = kazananlar;
                muharebe.kaybedenler = kaybedenler;
                muharebe.kazananZayiati = kazananZay;
                muharebe.kaybedenZayiati = kaybedenZay;
                muharebe.aciklama = aciklama;
                muharebe.kaynak = kaynak;
                bayrak = data.yeniMuharebeEkle(muharebe);
            }
            else
                bayrak = -100;

            return bayrak;
        }

        public int savasYaz(string ad, string basla, string bit, string kaz, string kay,
            string kazzay, string kayzay, System.Collections.IList kazananlar, System.Collections.IList kaybedenler,
            string aciklama,string kaynak)
        {
            int bayrak;
            if (!string.IsNullOrEmpty(ad) && !string.IsNullOrEmpty(basla) && !string.IsNullOrEmpty(bit)
                    && !string.IsNullOrEmpty(basla) && !string.IsNullOrEmpty(kaz) && !string.IsNullOrEmpty(kay)
                    && !string.IsNullOrEmpty(kazzay) && !string.IsNullOrEmpty(kayzay) && kazananlar != null
                    && kaybedenler != null && !string.IsNullOrEmpty(aciklama))
            {
                string[] _kazananlar = kaz.Split(",");
                string[] _kaybedenler = kay.Split(",");
                string[] kazZayiati = kazzay.Split(",");
                string[] kayZayiati = kayzay.Split(",");

                Savaslar savas = new Savaslar();
                savas.kazananlar = new List<string>();
                savas.kaybedenler = new List<string>();
                savas.kazananZayiati = new List<string>();
                savas.kaybedenZayiati = new List<string>();
                savas.kazananGeneraller = new List<General>();
                savas.kaybedenGeneraller = new List<General>();

                foreach (string item in _kazananlar)
                    savas.kazananlar.Add(item);
                foreach (string item in _kaybedenler)
                    savas.kaybedenler.Add(item);
                foreach (string item in kazZayiati)
                    savas.kazananZayiati.Add(item);
                foreach (string item in kayZayiati)
                    savas.kaybedenZayiati.Add(item);
                foreach (General item in kazananlar)
                    savas.kazananGeneraller.Add(item);
                foreach (General item in kaybedenler)
                    savas.kaybedenGeneraller.Add(item);

                _kazananlar = null;
                _kaybedenler = null;
                kazZayiati = null;
                kazZayiati = null;
                savas.id = Guid.NewGuid();
                savas.ad = ad;
                savas.baslangic = basla;
                savas.bitis = bit;
                savas.aciklama = aciklama;
                savas.kaynak = kaynak;

                bayrak = data.savasYaz(savas);
            }
            else
            {
                bayrak = -100;
            }
            return bayrak;
        }

        public List<Muharebe> muharebeVer()
        {
            List<Muharebe> muharebe = new List<Muharebe>();
            muharebe = data.muharebeVer();
            return muharebe;
        }

        public int haritaYaz(string harita,string tarih,string yer, string aciklama,object muharebe,string yol,string kaynak)
        {
            int bayrak;
            if (!string.IsNullOrEmpty(harita) && !string.IsNullOrEmpty(tarih) && !string.IsNullOrEmpty(yer)
                && !string.IsNullOrEmpty(aciklama)&&!string.IsNullOrEmpty(yol))
            {
                Harita har = new Harita();
                har.id = Guid.NewGuid();
                har.harita = harita;
                har.tarih = tarih;
                har.yerAdi = yer;
                har.aciklama = aciklama;
                har.muharebe = (Muharebe)muharebe;
                har.resim = yol;
                har.kaynak = kaynak;
                bayrak = data.haritaYaz(har);
            }
            else
            {
                bayrak = -100;
            }
            return bayrak;
        }

        public List<DevletAdamlari> devletAdamiVer()
        {
            List<DevletAdamlari> devlet = data.devletAdamiVer();
            return devlet;
        }

        public List<Savaslar> savasVer()
        {
            List<Savaslar> savas = data.savasVer();
            return savas;
        }

        public int savasSil(object gelen)
        {
            Savaslar silinecek = (Savaslar)gelen;
            int bayrak = data.savasSil(silinecek.id);
            return bayrak;
        }

        public int muharebeSil(object gelen)
        {
            Muharebe silinecek = (Muharebe)gelen;
            int bayrak = data.muharebeSil(silinecek.id);
            return bayrak;
        }

        public int generalSil(object gelen)
        {
            General silinecek = (General)gelen;
            int bayrak = data.generalSil(silinecek.generalId);
            return bayrak;
        }

        public int devletAdamiSil(object gelen)
        {
            DevletAdamlari silinecek = (DevletAdamlari)gelen;
            int bayrak = data.devletAdamiSil(silinecek.devletId);
            return bayrak;
        }

        public int haritaSil(object gelen)
        {
            Harita silinecek = (Harita)gelen;
            int bayrak = data.haritaSil(silinecek.id);
            return bayrak;
        }

        public int kisiGeneralSil(object gelen)
        {
            int bayrak;
            if (gelen != null)
            {
                Guid id = (Guid)gelen;
                data.kisiGeneralSil(id);
                bayrak = 1;
            }
            else
                bayrak = -1;

            return bayrak;
        }

        public int kisiDevletAdamiSil(object gelen)
        {
            int bayrak;
            if (gelen != null)
            {
                Guid id = (Guid)gelen;
            data.devletAdamiSil(id);
                bayrak = 1;
            }
            else
                bayrak = -1;

            return bayrak;
        }

        public int savasDuzenle(string ad, string basla, string bit, string kaz, string kay,
            string kazzay, string kayzay, System.Collections.IList kazananlar, System.Collections.IList kaybedenler,
            string aciklama, string kaynak,object id)
        {
            int bayrak;
            if (!string.IsNullOrEmpty(ad) && !string.IsNullOrEmpty(basla) && !string.IsNullOrEmpty(bit)
                    && !string.IsNullOrEmpty(basla) && !string.IsNullOrEmpty(kaz) && !string.IsNullOrEmpty(kay)
                    && !string.IsNullOrEmpty(kazzay) && !string.IsNullOrEmpty(kayzay) && kazananlar != null
                    && kaybedenler != null && !string.IsNullOrEmpty(aciklama))
            {
                string[] _kazananlar = kaz.Split(",");
                string[] _kaybedenler = kay.Split(",");
                string[] kazZayiati = kazzay.Split(",");
                string[] kayZayiati = kayzay.Split(",");

                Savaslar savas = new Savaslar();
                savas.kazananlar = new List<string>();
                savas.kaybedenler = new List<string>();
                savas.kazananZayiati = new List<string>();
                savas.kaybedenZayiati = new List<string>();
                savas.kazananGeneraller = new List<General>();
                savas.kaybedenGeneraller = new List<General>();

                foreach (string item in _kazananlar)
                    savas.kazananlar.Add(item);
                foreach (string item in _kaybedenler)
                    savas.kaybedenler.Add(item);
                foreach (string item in kazZayiati)
                    savas.kazananZayiati.Add(item);
                foreach (string item in kayZayiati)
                    savas.kaybedenZayiati.Add(item);
                foreach (General item in kazananlar)
                    savas.kazananGeneraller.Add(item);
                foreach (General item in kaybedenler)
                    savas.kaybedenGeneraller.Add(item);

                _kazananlar = null;
                _kaybedenler = null;
                kazZayiati = null;
                kazZayiati = null;
                savas.id = (Guid)id;
                savas.ad = ad;
                savas.baslangic = basla;
                savas.bitis = bit;
                savas.aciklama = aciklama;
                savas.kaynak = kaynak;

                bayrak = data.savasDuzenle(savas);
            }
            else
            {
                bayrak = -100;
            }
            return bayrak;
        }

        public int muharebeDuzenle(string ad, string tarih, string kazanan, string kaybeden,
            string kazananZayiati, string kaybedenZayiati, System.Collections.IList kazananGeneraller,
            System.Collections.IList kaybedenGeneraller, string aciklama, object harita, string kaynak,object id)
        {
            int bayrak;
            if (!string.IsNullOrEmpty(ad) && !string.IsNullOrEmpty(tarih)
                && !string.IsNullOrEmpty(kazanan) && !string.IsNullOrEmpty(kaybeden)
                && !string.IsNullOrEmpty(aciklama))
            {
                string[] _kazanan = kazanan.Split(",");
                string[] _kaybeden = kaybeden.Split(",");
                string[] _kazananZayiat = kazananZayiati.Split(",");
                string[] _kaybedenzayiat = kaybedenZayiati.Split(",");
                List<string> kazananlar = new List<string>();
                List<string> kaybedenler = new List<string>();
                List<string> kaybedenZay = new List<string>();
                List<string> kazananZay = new List<string>();

                foreach (string item in _kazanan)
                    kazananlar.Add(item);
                foreach (string item in _kaybeden)
                    kaybedenler.Add(item);
                foreach (string item in _kazananZayiat)
                    kazananZay.Add(item);
                foreach (string item in _kaybedenzayiat)
                    kaybedenZay.Add(item);

                _kazanan = null;
                _kaybeden = null;
                _kazananZayiat = null;
                _kaybedenzayiat = null;


                Muharebe muharebe = new Muharebe();
                muharebe.kazananGeneraller = new List<General>();
                muharebe.kaybedenGeneraller = new List<General>();
                muharebe.id = (Guid)id;
                muharebe.ad = ad;
                muharebe.tarih = tarih;
                foreach (General item in kazananGeneraller)
                    muharebe.kazananGeneraller.Add(item);
                foreach (General item in kaybedenGeneraller)
                    muharebe.kaybedenGeneraller.Add(item);
                muharebe.kazananlar = kazananlar;
                muharebe.kaybedenler = kaybedenler;
                muharebe.kazananZayiati = kazananZay;
                muharebe.kaybedenZayiati = kaybedenZay;
                
                muharebe.kaynak = kaynak;
                muharebe.aciklama = aciklama;
                bayrak = data.muharebeDuzenle(muharebe);
            }
            else
                bayrak = -100;

            return bayrak;
        }

        public int haritaDuzenle(string harita, string tarih, string yer, string aciklama, object muharebe, string yol, string kaynak,object id)
        {
            int bayrak;
            if (!string.IsNullOrEmpty(harita) && !string.IsNullOrEmpty(tarih) && !string.IsNullOrEmpty(yer)
                && !string.IsNullOrEmpty(aciklama) && !string.IsNullOrEmpty(yol))
            {
                Harita har = new Harita();
                har.id = (Guid)id;
                har.harita = harita;
                har.tarih = tarih;
                har.yerAdi = yer;
                har.aciklama = aciklama;
                har.muharebe = (Muharebe)muharebe;
                har.resim = yol;
                har.kaynak = kaynak;
                bayrak = data.haritaDuzenle(har);
            }
            else
            {
                bayrak = -100;
            }
            return bayrak;
        }

        public int generalDuzenle(string ad, string soyad, string dog, string ol, System.Collections.IList savaslar
            , string hizmetYillari, string aciklama, string gen, string dev, string foto, string dogYer, string olYer, string kaynak,object genId,object devId)
        {
            int bayrak;
            
            

            if (!string.IsNullOrEmpty(ad) && !string.IsNullOrEmpty(soyad) && dog != null && ol != null
                && savaslar != null && !string.IsNullOrEmpty(hizmetYillari) && !string.IsNullOrEmpty(aciklama))
            {
                


                
                    General general = new General();
                    general.girdigiSavaslar = new List<Savaslar>();
                    foreach (Savaslar item in savaslar)
                    {
                        general.girdigiSavaslar.Add(item);
                    }
                if (genId != null)
                    general.generalId = (Guid)genId;
                else
                    general.generalId = Guid.NewGuid();
                    general.devletId = (Guid)devId;
                    general.ad = ad;
                    general.soyad = soyad;
                    general.dogumTarihi = dog;
                    general.olumTarihi = ol;
                    general.HizmetYillari = hizmetYillari;
                    general.aciklama = aciklama;
                    general.foto = foto;
                    general.dogumYeri = dogYer;
                    general.olumYeri = olYer;
                    general.kaynak = kaynak;
                    general.general = true;
                if (dev != null)
                    general.devletAdami = true;
                    bayrak = data.generalDuzenle(general);
                
            }
            else
            {
                bayrak = -100;
                
            }
            return bayrak ;
        }

        public int devletAdamiDuzenle(string ad, string soyad, string dog, string ol, System.Collections.IList savaslar
            , string hizmetYillari, string aciklama, string gen, string dev, string foto, string dogYer, string olYer, string kaynak,object devId,object genID)
        {
            int bayrak;

            

            if (!string.IsNullOrEmpty(ad) && !string.IsNullOrEmpty(soyad) && dog != null && ol != null
                && savaslar != null && !string.IsNullOrEmpty(hizmetYillari) && !string.IsNullOrEmpty(aciklama))
            {
                



                DevletAdamlari devlet = new DevletAdamlari();
                devlet.girdigiSavaslar = new List<Savaslar>();
                foreach (Savaslar item in savaslar)
                {
                    devlet.girdigiSavaslar.Add(item);
                }
                if (devId != null)
                    devlet.devletId = (Guid)devId;
                else
                    devlet.devletId = Guid.NewGuid();
                devlet.generalId = (Guid)genID;
                devlet.ad = ad;
                devlet.soyad = soyad;
                devlet.dogumTarihi = dog;
                devlet.olumTarihi = ol;
                devlet.HizmetYillari = hizmetYillari;
                devlet.aciklama = aciklama;
                devlet.foto = foto;
                devlet.dogumYeri = dogYer;
                devlet.olumYeri = olYer;
                devlet.kaynak = kaynak;
                devlet.devletAdami = true;
                if (gen != null)
                    devlet.general = true;
                bayrak = data.devletAdamiDuzenle(devlet);

            }
            else
            {
                bayrak = -100;

            }
            return bayrak;
        }

    }
}
