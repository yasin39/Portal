using System;

namespace Portal.DataAccess.Model
{
    public class Personel
    {
        public string TcKimlikNo { get; set; }
        public string Adi { get; set; }
        public string Soyad { get; set; }
        public string DogumYeri { get; set; }
        public string DogumTarihi { get; set; }
        public string Cinsiyet { get; set; }
        public string SicilNo { get; set; }
        public string Unvan { get; set; }
        public string Statu { get; set; }
        public string GorevYaptigiBirim { get; set; }
        public string CepTelefonu { get; set; }
        public string EmailAdresi { get; set; }

        public string CalismaDurumu { get; set; }

        public string GeciciGidenKurum { get; set; }
        public string Durum { get; set; }

        public string Adres { get; set; }

        public string EvTelefonu { get; set; }
        public string DahiliTelefon { get; set; }
        public string AcilDurumKisi { get; set; }
        public string AcilDurumTelefon { get; set; }
        public string KanGrubu { get; set; }
        public string MedeniHali { get; set; }
        public string AskerlikDurumu { get; set; }
        public string EngelDurumu { get; set; }
        public string EngelAciklama { get; set; }
        public string Sendika { get; set; }
        public string MeslekiUnvan { get; set; }
        public string OgrenimDurumu { get; set; }
        public string ResimUrl { get; set; }
        public DateTime? IseGirisTarihi { get; set; }
        public DateTime? KurumaGirisTarihi { get; set; }
        public DateTime? IstenAyrilisTarihi { get; set; }
        public string IstenAyrilisSebebi { get; set; }
        public DateTime? GeciciGorevBaslangic { get; set; }
        public DateTime? GeciciGorevBitis { get; set; }
        public string GeciciGelenKurum { get; set; }
        public DateTime? EmeklilikTarihi { get; set; }
        public DateTime? YaslilikAylikTarihi { get; set; }
        public string EmeklilikAciklama { get; set; }
        public string KadroDerece { get; set; }
        public int? DevredenIzin { get; set; }
        public int? CariYilIzin { get; set; }
    }
}