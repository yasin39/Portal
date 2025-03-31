using Portal.DataAccess.Model;
using Portal.Helpers;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;

namespace Portal.DataAccess
{
    public class PersonelDataAccess
    {
        private readonly string _connectionString;

        public PersonelDataAccess()
        {
            _connectionString = ConfigurationManager.ConnectionStrings["Laptop"].ConnectionString;
        }

        // Personel ekleme
        public bool PersonelEkle(Personel personel)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(_connectionString))
                {
                    string sorgu = @"
                    INSERT INTO personel (
                        TcKimlikNo, Adi, Soyad, DogumYeri, DogumTarihi, Cinsiyet, Durum, SicilNo, Unvan, Statu,
                        ilkisegiristarihi, KurumaBaslamaTarihi, GorevYaptigiBirim, CalismaDurumu, 
                        GeciciGelenPersonelKurumu, GeciciGidenPersonelKurumu, istenAyrilisTarihi, istenAyrilmaSebebi,
                        GGorevBaslangicTarihi, GGorevBitisTarihi, CepTelefonu, MailAdresi, EvTelefonu, Adres,
                        AcilDurumdaAranacakKisi, AcilCep, KanGrubu, MedeniHali, AskerlikDurumu, EngelDurumu,
                        EngelAciklama, Sendika, MeslekiUnvan, KayitTarihi, KayitKullanici, Resim, Devredenizin,
                        cariyilizni, Ogrenim_Durumu, Dahili, EmeklilikTarihi, YaslilikAylikTarihi, EmeklilikAciklama,
                        KadroDerece
                    ) VALUES (
                        @TcKimlikNo, @Adi, @Soyad, @DogumYeri, @DogumTarihi, @Cinsiyet, @Durum, @SicilNo, @Unvan, @Statu,
                        @ilkisegiristarihi, @KurumaBaslamaTarihi, @GorevYaptigiBirim, @CalismaDurumu, 
                        @GeciciGelenPersonelKurumu, @GeciciGidenPersonelKurumu, @istenAyrilisTarihi, @istenAyrilmaSebebi,
                        @GGorevBaslangicTarihi, @GGorevBitisTarihi, @CepTelefonu, @MailAdresi, @EvTelefonu, @Adres,
                        @AcilDurumdaAranacakKisi, @AcilCep, @KanGrubu, @MedeniHali, @AskerlikDurumu, @EngelDurumu,
                        @EngelAciklama, @Sendika, @MeslekiUnvan, @KayitTarihi, @KayitKullanici, @Resim, @Devredenizin,
                        @cariyilizni, @Ogrenim_Durumu, @Dahili, @EmeklilikTarihi, @YaslilikAylikTarihi, @EmeklilikAciklama,
                        @KadroDerece
                    )";

                    SqlCommand komut = new SqlCommand(sorgu, con);

                    // Zorunlu alanlar
                    komut.Parameters.AddWithValue("@TcKimlikNo", personel.TcKimlikNo);
                    komut.Parameters.AddWithValue("@Adi", personel.Adi);
                    komut.Parameters.AddWithValue("@Soyad", personel.Soyad);
                    komut.Parameters.AddWithValue("@DogumYeri", personel.DogumYeri ?? (object)DBNull.Value);
                    komut.Parameters.AddWithValue("@DogumTarihi", personel.DogumTarihi ?? (object)DBNull.Value);
                    komut.Parameters.AddWithValue("@Cinsiyet", personel.Cinsiyet ?? (object)DBNull.Value);
                    komut.Parameters.AddWithValue("@Durum", personel.Durum ?? (object)DBNull.Value);
                    komut.Parameters.AddWithValue("@SicilNo", personel.SicilNo ?? (object)DBNull.Value);
                    komut.Parameters.AddWithValue("@Unvan", personel.Unvan ?? (object)DBNull.Value);
                    komut.Parameters.AddWithValue("@Statu", personel.Statu ?? (object)DBNull.Value);
                    komut.Parameters.AddWithValue("@ilkisegiristarihi", personel.IseGirisTarihi ?? (object)DBNull.Value);
                    komut.Parameters.AddWithValue("@KurumaBaslamaTarihi", personel.KurumaGirisTarihi ?? (object)DBNull.Value);
                    komut.Parameters.AddWithValue("@GorevYaptigiBirim", personel.GorevYaptigiBirim ?? (object)DBNull.Value);
                    komut.Parameters.AddWithValue("@CalismaDurumu", personel.CalismaDurumu ?? (object)DBNull.Value);
                    komut.Parameters.AddWithValue("@CepTelefonu", personel.CepTelefonu ?? (object)DBNull.Value);
                    komut.Parameters.AddWithValue("@MailAdresi", personel.EmailAdresi ?? (object)DBNull.Value);
                    komut.Parameters.AddWithValue("@Adres", personel.Adres ?? (object)DBNull.Value);
                    komut.Parameters.AddWithValue("@AcilDurumdaAranacakKisi", personel.AcilDurumKisi ?? (object)DBNull.Value);
                    komut.Parameters.AddWithValue("@AcilCep", personel.AcilDurumTelefon ?? (object)DBNull.Value);
                    komut.Parameters.AddWithValue("@KanGrubu", personel.KanGrubu ?? (object)DBNull.Value);
                    komut.Parameters.AddWithValue("@MedeniHali", personel.MedeniHali ?? (object)DBNull.Value);
                    komut.Parameters.AddWithValue("@AskerlikDurumu", personel.AskerlikDurumu ?? (object)DBNull.Value);
                    komut.Parameters.AddWithValue("@EngelDurumu", personel.EngelDurumu ?? (object)DBNull.Value);
                    komut.Parameters.AddWithValue("@Sendika", personel.Sendika ?? (object)DBNull.Value);
                    komut.Parameters.AddWithValue("@MeslekiUnvan", personel.MeslekiUnvan ?? (object)DBNull.Value);
                    komut.Parameters.AddWithValue("@KayitTarihi", DateTime.Now);
                    komut.Parameters.AddWithValue("@KayitKullanici", Environment.UserName);
                    komut.Parameters.AddWithValue("@Resim", personel.ResimUrl ?? (object)DBNull.Value);
                    komut.Parameters.AddWithValue("@Ogrenim_Durumu", personel.OgrenimDurumu ?? (object)DBNull.Value);
                    komut.Parameters.AddWithValue("@Dahili", personel.DahiliTelefon ?? (object)DBNull.Value);
                    komut.Parameters.AddWithValue("@KadroDerece", personel.KadroDerece ?? (object)DBNull.Value);

                    // Nullable alanlar
                    komut.Parameters.AddWithValue("@GeciciGelenPersonelKurumu", personel.GeciciGelenKurum ?? (object)DBNull.Value);
                    komut.Parameters.AddWithValue("@GeciciGidenPersonelKurumu", personel.GeciciGidenKurum ?? (object)DBNull.Value);
                    komut.Parameters.AddWithValue("@istenAyrilisTarihi", personel.IstenAyrilisTarihi ?? (object)DBNull.Value);
                    komut.Parameters.AddWithValue("@istenAyrilmaSebebi", personel.IstenAyrilisSebebi ?? (object)DBNull.Value);
                    komut.Parameters.AddWithValue("@GGorevBaslangicTarihi", personel.GeciciGorevBaslangic ?? (object)DBNull.Value);
                    komut.Parameters.AddWithValue("@GGorevBitisTarihi", personel.GeciciGorevBitis ?? (object)DBNull.Value);
                    komut.Parameters.AddWithValue("@EvTelefonu", personel.EvTelefonu ?? (object)DBNull.Value);
                    komut.Parameters.AddWithValue("@EngelAciklama", personel.EngelAciklama ?? (object)DBNull.Value);
                    komut.Parameters.AddWithValue("@Devredenizin", personel.DevredenIzin ?? (object)DBNull.Value);
                    komut.Parameters.AddWithValue("@cariyilizni", personel.CariYilIzin ?? (object)DBNull.Value);
                    komut.Parameters.AddWithValue("@EmeklilikTarihi", personel.EmeklilikTarihi ?? (object)DBNull.Value);
                    komut.Parameters.AddWithValue("@YaslilikAylikTarihi", personel.YaslilikAylikTarihi ?? (object)DBNull.Value);
                    komut.Parameters.AddWithValue("@EmeklilikAciklama", personel.EmeklilikAciklama ?? (object)DBNull.Value);

                    con.Open();
                    int etkilenenSatir = komut.ExecuteNonQuery();
                    return etkilenenSatir > 0;
                }
            }
            catch (Exception ex)
            {
                Logger.Log(ex.Message);
                throw new Exception("Personel ekleme hatası: " + ex.Message);
            }
        }

        // TC'ye göre personel getirme
        public Personel PersonelGetir(string tcKimlikNo)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(_connectionString))
                {
                    string sorgu = "SELECT * FROM personel WHERE TcKimlikNo = @TcKimlikNo";
                    SqlCommand komut = new SqlCommand(sorgu, con);
                    komut.Parameters.AddWithValue("@TcKimlikNo", tcKimlikNo);

                    con.Open();
                    SqlDataReader reader = komut.ExecuteReader();

                    if (reader.Read())
                    {
                        return new Personel
                        {
                            TcKimlikNo = reader["TcKimlikNo"].ToString(),
                            Adi = reader["Adi"].ToString(),
                            Soyad = reader["Soyad"].ToString(),
                            DogumYeri = reader["DogumYeri"].ToString(),
                            DogumTarihi = reader["DogumTarihi"].ToString(),
                            Cinsiyet = reader["Cinsiyet"].ToString(),
                            CalismaDurumu = reader["CalismaDurumu"].ToString(),
                            SicilNo = reader["SicilNo"].ToString(),
                            Unvan = reader["Unvan"].ToString(),
                            Statu = reader["Statu"].ToString(),
                            IseGirisTarihi = reader["ilkisegiristarihi"] != DBNull.Value ? Convert.ToDateTime(reader["ilkisegiristarihi"]) : (DateTime?)null,
                            KurumaGirisTarihi = reader["KurumaBaslamaTarihi"] != DBNull.Value ? Convert.ToDateTime(reader["KurumaBaslamaTarihi"]) : (DateTime?)null,
                            GorevYaptigiBirim = reader["GorevYaptigiBirim"].ToString(),
                            Durum = reader["Durum"].ToString(),
                            GeciciGelenKurum = reader["GeciciGelenPersonelKurumu"].ToString(),
                            GeciciGidenKurum = reader["GeciciGidenPersonelKurumu"].ToString(),
                            IstenAyrilisTarihi = reader["istenAyrilisTarihi"] != DBNull.Value ? Convert.ToDateTime(reader["istenAyrilisTarihi"]) : (DateTime?)null,
                            IstenAyrilisSebebi = reader["istenAyrilmaSebebi"].ToString(),
                            GeciciGorevBaslangic = reader["GGorevBaslangicTarihi"] != DBNull.Value ? Convert.ToDateTime(reader["GGorevBaslangicTarihi"]) : (DateTime?)null,
                            GeciciGorevBitis = reader["GGorevBitisTarihi"] != DBNull.Value ? Convert.ToDateTime(reader["GGorevBitisTarihi"]) : (DateTime?)null,
                            CepTelefonu = reader["CepTelefonu"].ToString(),
                            EmailAdresi = reader["MailAdresi"].ToString(),
                            EvTelefonu = reader["EvTelefonu"].ToString(),
                            Adres = reader["Adres"].ToString(),
                            AcilDurumKisi = reader["AcilDurumdaAranacakKisi"].ToString(),
                            AcilDurumTelefon = reader["AcilCep"].ToString(),
                            KanGrubu = reader["KanGrubu"].ToString(),
                            MedeniHali = reader["MedeniHali"].ToString(),
                            AskerlikDurumu = reader["AskerlikDurumu"].ToString(),
                            EngelDurumu = reader["EngelDurumu"].ToString(),
                            EngelAciklama = reader["EngelAciklama"].ToString(),
                            Sendika = reader["Sendika"].ToString(),
                            MeslekiUnvan = reader["MeslekiUnvan"].ToString(),
                            ResimUrl = reader["Resim"].ToString(),
                            OgrenimDurumu = reader["Ogrenim_Durumu"].ToString(),
                            DahiliTelefon = reader["Dahili"].ToString(),
                            EmeklilikTarihi = reader["EmeklilikTarihi"] != DBNull.Value ? Convert.ToDateTime(reader["EmeklilikTarihi"]) : (DateTime?)null,
                            YaslilikAylikTarihi = reader["YaslilikAylikTarihi"] != DBNull.Value ? Convert.ToDateTime(reader["YaslilikAylikTarihi"]) : (DateTime?)null,
                            EmeklilikAciklama = reader["EmeklilikAciklama"].ToString(),
                            KadroDerece = reader["KadroDerece"].ToString(),
                            DevredenIzin = reader["Devredenizin"] != DBNull.Value ? Convert.ToInt32(reader["Devredenizin"]) : (int?)null,
                            CariYilIzin = reader["cariyilizni"] != DBNull.Value ? Convert.ToInt32(reader["cariyilizni"]) : (int?)null
                        };
                    }
                    return null;
                }
            }
            catch (Exception ex)
            {
                Logger.Log(ex.Message);
                throw new Exception("Personel getirme hatası: " + ex.Message);
            }
        }

        // Tüm personelleri getirme
        public List<Personel> TumPersonelleriGetir()
        {
            List<Personel> personeller = new List<Personel>();
            try
            {
                using (SqlConnection con = new SqlConnection(_connectionString))
                {
                    string sorgu = "SELECT * FROM personel";
                    SqlCommand komut = new SqlCommand(sorgu, con);

                    con.Open();
                    SqlDataReader reader = komut.ExecuteReader();

                    while (reader.Read())
                    {
                        personeller.Add(new Personel
                        {
                            TcKimlikNo = reader["TcKimlikNo"].ToString(),
                            Adi = reader["Adi"].ToString(),
                            Soyad = reader["Soyad"].ToString(),
                            DogumYeri = reader["DogumYeri"].ToString(),
                            DogumTarihi = reader["DogumTarihi"].ToString(),
                            Cinsiyet = reader["Cinsiyet"].ToString(),
                            CalismaDurumu = reader["CalismaDurumu"].ToString(),
                            SicilNo = reader["SicilNo"].ToString(),
                            Unvan = reader["Unvan"].ToString(),
                            Statu = reader["Statu"].ToString(),
                            IseGirisTarihi = reader["ilkisegiristarihi"] != DBNull.Value ? Convert.ToDateTime(reader["ilkisegiristarihi"]) : (DateTime?)null,
                            KurumaGirisTarihi = reader["KurumaBaslamaTarihi"] != DBNull.Value ? Convert.ToDateTime(reader["KurumaBaslamaTarihi"]) : (DateTime?)null,
                            GorevYaptigiBirim = reader["GorevYaptigiBirim"].ToString(),
                            Durum = reader["Durum"].ToString(),
                            GeciciGelenKurum = reader["GeciciGelenPersonelKurumu"].ToString(),
                            GeciciGidenKurum = reader["GeciciGidenPersonelKurumu"].ToString(),
                            IstenAyrilisTarihi = reader["istenAyrilisTarihi"] != DBNull.Value ? Convert.ToDateTime(reader["istenAyrilisTarihi"]) : (DateTime?)null,
                            IstenAyrilisSebebi = reader["istenAyrilmaSebebi"].ToString(),
                            GeciciGorevBaslangic = reader["GGorevBaslangicTarihi"] != DBNull.Value ? Convert.ToDateTime(reader["GGorevBaslangicTarihi"]) : (DateTime?)null,
                            GeciciGorevBitis = reader["GGorevBitisTarihi"] != DBNull.Value ? Convert.ToDateTime(reader["GGorevBitisTarihi"]) : (DateTime?)null,
                            CepTelefonu = reader["CepTelefonu"].ToString(),
                            EmailAdresi = reader["MailAdresi"].ToString(),
                            EvTelefonu = reader["EvTelefonu"].ToString(),
                            Adres = reader["Adres"].ToString(),
                            AcilDurumKisi = reader["AcilDurumdaAranacakKisi"].ToString(),
                            AcilDurumTelefon = reader["AcilCep"].ToString(),
                            KanGrubu = reader["KanGrubu"].ToString(),
                            MedeniHali = reader["MedeniHali"].ToString(),
                            AskerlikDurumu = reader["AskerlikDurumu"].ToString(),
                            EngelDurumu = reader["EngelDurumu"].ToString(),
                            EngelAciklama = reader["EngelAciklama"].ToString(),
                            Sendika = reader["Sendika"].ToString(),
                            MeslekiUnvan = reader["MeslekiUnvan"].ToString(),
                            ResimUrl = reader["Resim"].ToString(),
                            OgrenimDurumu = reader["Ogrenim_Durumu"].ToString(),
                            DahiliTelefon = reader["Dahili"].ToString(),
                            EmeklilikTarihi = reader["EmeklilikTarihi"] != DBNull.Value ? Convert.ToDateTime(reader["EmeklilikTarihi"]) : (DateTime?)null,
                            YaslilikAylikTarihi = reader["YaslilikAylikTarihi"] != DBNull.Value ? Convert.ToDateTime(reader["YaslilikAylikTarihi"]) : (DateTime?)null,
                            EmeklilikAciklama = reader["EmeklilikAciklama"].ToString(),
                            KadroDerece = reader["KadroDerece"].ToString(),
                            DevredenIzin = reader["Devredenizin"] != DBNull.Value ? Convert.ToInt32(reader["Devredenizin"]) : (int?)null,
                            CariYilIzin = reader["cariyilizni"] != DBNull.Value ? Convert.ToInt32(reader["cariyilizni"]) : (int?)null
                        });
                    }
                    return personeller;
                }
            }
            catch (Exception ex)
            {
                Logger.Log(ex.Message);
                throw new Exception("Personel listesi getirme hatası: " + ex.Message);
            }
        }

        // Personel güncelleme
        public bool PersonelGuncelle(Personel personel)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(_connectionString))
                {
                    string sorgu = @"
                    UPDATE personel SET 
                        Adi = @Adi, Soyad = @Soyad, DogumYeri = @DogumYeri, DogumTarihi = @DogumTarihi,
                        Cinsiyet = @Cinsiyet, Durum = @Durum, SicilNo = @SicilNo, Unvan = @Unvan, Statu = @Statu,
                        ilkisegiristarihi = @ilkisegiristarihi, KurumaBaslamaTarihi = @KurumaBaslamaTarihi,
                        GorevYaptigiBirim = @GorevYaptigiBirim, CalismaDurumu = @CalismaDurumu,
                        GeciciGelenPersonelKurumu = @GeciciGelenPersonelKurumu, GeciciGidenPersonelKurumu = @GeciciGidenPersonelKurumu,
                        istenAyrilisTarihi = @istenAyrilisTarihi, istenAyrilmaSebebi = @istenAyrilmaSebebi,
                        GGorevBaslangicTarihi = @GGorevBaslangicTarihi, GGorevBitisTarihi = @GGorevBitisTarihi,
                        CepTelefonu = @CepTelefonu, MailAdresi = @MailAdresi, EvTelefonu = @EvTelefonu, Adres = @Adres,
                        AcilDurumdaAranacakKisi = @AcilDurumdaAranacakKisi, AcilCep = @AcilCep,
                        KanGrubu = @KanGrubu, MedeniHali = @MedeniHali, AskerlikDurumu = @AskerlikDurumu,
                        EngelDurumu = @EngelDurumu, EngelAciklama = @EngelAciklama, Sendika = @Sendika,
                        MeslekiUnvan = @MeslekiUnvan, Resim = @Resim, Ogrenim_Durumu = @Ogrenim_Durumu,
                        Dahili = @Dahili, EmeklilikTarihi = @EmeklilikTarihi, YaslilikAylikTarihi = @YaslilikAylikTarihi,
                        EmeklilikAciklama = @EmeklilikAciklama, KadroDerece = @KadroDerece,
                        Devredenizin = @Devredenizin, cariyilizni = @cariyilizni,
                        SonGuncellemeTarihi = @SonGuncellemeTarihi, SonGuncellemeKullanici = @SonGuncellemeKullanici
                    WHERE TcKimlikNo = @TcKimlikNo";

                    SqlCommand komut = new SqlCommand(sorgu, con);

                    // Zorunlu alanlar
                    komut.Parameters.AddWithValue("@TcKimlikNo", personel.TcKimlikNo);
                    komut.Parameters.AddWithValue("@Adi", personel.Adi);
                    komut.Parameters.AddWithValue("@Soyad", personel.Soyad);
                    komut.Parameters.AddWithValue("@DogumYeri", personel.DogumYeri ?? (object)DBNull.Value);
                    komut.Parameters.AddWithValue("@DogumTarihi", personel.DogumTarihi ?? (object)DBNull.Value);
                    komut.Parameters.AddWithValue("@Cinsiyet", personel.Cinsiyet ?? (object)DBNull.Value);
                    komut.Parameters.AddWithValue("@Durum", personel.Durum ?? (object)DBNull.Value);
                    komut.Parameters.AddWithValue("@SicilNo", personel.SicilNo ?? (object)DBNull.Value);
                    komut.Parameters.AddWithValue("@Unvan", personel.Unvan ?? (object)DBNull.Value);
                    komut.Parameters.AddWithValue("@Statu", personel.Statu ?? (object)DBNull.Value);
                    komut.Parameters.AddWithValue("@ilkisegiristarihi", personel.IseGirisTarihi ?? (object)DBNull.Value);
                    komut.Parameters.AddWithValue("@KurumaBaslamaTarihi", personel.KurumaGirisTarihi ?? (object)DBNull.Value);
                    komut.Parameters.AddWithValue("@GorevYaptigiBirim", personel.GorevYaptigiBirim ?? (object)DBNull.Value);
                    komut.Parameters.AddWithValue("@CalismaDurumu", personel.CalismaDurumu ?? (object)DBNull.Value);
                    komut.Parameters.AddWithValue("@CepTelefonu", personel.CepTelefonu ?? (object)DBNull.Value);
                    komut.Parameters.AddWithValue("@MailAdresi", personel.EmailAdresi ?? (object)DBNull.Value);
                    komut.Parameters.AddWithValue("@Adres", personel.Adres ?? (object)DBNull.Value);
                    komut.Parameters.AddWithValue("@AcilDurumdaAranacakKisi", personel.AcilDurumKisi ?? (object)DBNull.Value);
                    komut.Parameters.AddWithValue("@AcilCep", personel.AcilDurumTelefon ?? (object)DBNull.Value);
                    komut.Parameters.AddWithValue("@KanGrubu", personel.KanGrubu ?? (object)DBNull.Value);
                    komut.Parameters.AddWithValue("@MedeniHali", personel.MedeniHali ?? (object)DBNull.Value);
                    komut.Parameters.AddWithValue("@AskerlikDurumu", personel.AskerlikDurumu ?? (object)DBNull.Value);
                    komut.Parameters.AddWithValue("@EngelDurumu", personel.EngelDurumu ?? (object)DBNull.Value);
                    komut.Parameters.AddWithValue("@Sendika", personel.Sendika ?? (object)DBNull.Value);
                    komut.Parameters.AddWithValue("@MeslekiUnvan", personel.MeslekiUnvan ?? (object)DBNull.Value);
                    komut.Parameters.AddWithValue("@KayitTarihi", DateTime.Now);
                    komut.Parameters.AddWithValue("@KayitKullanici", Environment.UserName);
                    komut.Parameters.AddWithValue("@Resim", personel.ResimUrl ?? (object)DBNull.Value);
                    komut.Parameters.AddWithValue("@Ogrenim_Durumu", personel.OgrenimDurumu ?? (object)DBNull.Value);
                    komut.Parameters.AddWithValue("@Dahili", personel.DahiliTelefon ?? (object)DBNull.Value);
                    komut.Parameters.AddWithValue("@KadroDerece", personel.KadroDerece ?? (object)DBNull.Value);

                    // Nullable alanlar
                    komut.Parameters.AddWithValue("@GeciciGelenPersonelKurumu", personel.GeciciGelenKurum ?? (object)DBNull.Value);
                    komut.Parameters.AddWithValue("@GeciciGidenPersonelKurumu", personel.GeciciGidenKurum ?? (object)DBNull.Value);
                    komut.Parameters.AddWithValue("@istenAyrilisTarihi", personel.IstenAyrilisTarihi ?? (object)DBNull.Value);
                    komut.Parameters.AddWithValue("@istenAyrilmaSebebi", personel.IstenAyrilisSebebi ?? (object)DBNull.Value);
                    komut.Parameters.AddWithValue("@GGorevBaslangicTarihi", personel.GeciciGorevBaslangic ?? (object)DBNull.Value);
                    komut.Parameters.AddWithValue("@GGorevBitisTarihi", personel.GeciciGorevBitis ?? (object)DBNull.Value);
                    komut.Parameters.AddWithValue("@EvTelefonu", personel.EvTelefonu ?? (object)DBNull.Value);
                    komut.Parameters.AddWithValue("@EngelAciklama", personel.EngelAciklama ?? (object)DBNull.Value);
                    komut.Parameters.AddWithValue("@Devredenizin", personel.DevredenIzin ?? (object)DBNull.Value);
                    komut.Parameters.AddWithValue("@cariyilizni", personel.CariYilIzin ?? (object)DBNull.Value);
                    komut.Parameters.AddWithValue("@EmeklilikTarihi", personel.EmeklilikTarihi ?? (object)DBNull.Value);
                    komut.Parameters.AddWithValue("@YaslilikAylikTarihi", personel.YaslilikAylikTarihi ?? (object)DBNull.Value);
                    komut.Parameters.AddWithValue("@EmeklilikAciklama", personel.EmeklilikAciklama ?? (object)DBNull.Value);

                    komut.Parameters.AddWithValue("@SonGuncellemeTarihi", DateTime.Now);
                    komut.Parameters.AddWithValue("@SonGuncellemeKullanici", Environment.UserName);

                    con.Open();
                    int etkilenenSatir = komut.ExecuteNonQuery();
                    return etkilenenSatir > 0;
                }
            }
            catch (Exception ex)
            {
                Logger.Log(ex.Message);
                throw new Exception("Personel güncelleme hatası: " + ex.Message);
            }
        }

        // Personel silme
        public bool PersonelSil(string tcKimlikNo)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(_connectionString))
                {
                    string sorgu = "DELETE FROM personel WHERE TcKimlikNo = @TcKimlikNo";
                    SqlCommand komut = new SqlCommand(sorgu, con);
                    komut.Parameters.AddWithValue("@TcKimlikNo", tcKimlikNo);

                    con.Open();
                    int etkilenenSatir = komut.ExecuteNonQuery();
                    return etkilenenSatir > 0;
                }
            }
            catch (Exception ex)
            {
                Logger.Log(ex.Message);
                throw new Exception("Personel silme hatası: " + ex.Message);
            }
        }
    }
}