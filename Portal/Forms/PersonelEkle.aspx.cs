using Portal.BusinessLogic;
using Portal.DataAccess;
using Portal.DataAccess.Model;
using Portal.Helpers;
using System;
using System.Linq;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Portal.Forms
{
    public partial class WebForm2 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Logger.Log("Personel Ekle Page Load başlatıldı.");
                // YetkiKontrol();
                DropDownListleriDoldur();

            }
        }

        // --- YARDIMCI METODLAR ---
        private void YetkiKontrol()
        {
            if (!YetkiHelper.PersonelYetkisiVar(Session["Sicil"]?.ToString()))
                Response.Redirect("anasayfa.aspx");
        }

        private void DropDownListleriDoldur()
        {
            ddlBirim.DataSource = VeriKaynagi.SubeListesiGetir();
            ddlBirim.DataTextField = "Birim_Ad";
            ddlBirim.DataValueField = "Birim_Ad";
            ddlBirim.DataBind();
            ddlBirim.Items.Insert(0, new ListItem("Seçiniz...", ""));

            ddlUnvan.DataSource = VeriKaynagi.UnvanListesiGetir();
            ddlUnvan.DataTextField = "Unvan";
            ddlUnvan.DataValueField = "Unvan";
            ddlUnvan.DataBind();
            ddlUnvan.Items.Insert(0, new ListItem("", ""));

            ddlSendika.DataSource = VeriKaynagi.SendikaListesiGetir();
            ddlSendika.DataTextField = "Sendika_Adi";
            ddlSendika.DataValueField = "Sendika_Adi";

            ddlGeciciGelenKurum.DataSource = VeriKaynagi.KurumListesiGetir(); // Yeni metod
            ddlGeciciGelenKurum.DataTextField = "Kurum_Adi";
            ddlGeciciGelenKurum.DataValueField = "Kurum_Adi";
            ddlGeciciGelenKurum.DataBind();
            ddlGeciciGelenKurum.Items.Insert(0, new ListItem("", ""));

            ddlGeciciGidenKurum.DataSource = VeriKaynagi.KurumListesiGetir(); // Yeni metod
            ddlGeciciGidenKurum.DataTextField = "Kurum_Adi";
            ddlGeciciGidenKurum.DataValueField = "Kurum_Adi";
            ddlGeciciGidenKurum.DataBind();
            ddlGeciciGidenKurum.Items.Insert(0, new ListItem("", ""));
        }


        // --- OLAY YÖNETİCİLERİ ---
        protected void Ekle_Click(object sender, EventArgs e)
        {
            try
            {
                if (!Page.IsValid)
                {
                    lblSonuc.Text = "Lütfen tüm zorunlu alanları doldurunuz";
                    return;
                }
                Personel yeniPersonel = UIdenPersonelNesnesiOlustur();
                bool sonuc = PersonelManager.PersonelEkle(yeniPersonel);

                if (sonuc)
                {
                    lblModalMessage.Text = "Ekleme işlemi başarılı.";
                    ScriptManager.RegisterStartupScript(this, GetType(), "showModal", "showModal();", true);
                }
                else
                {
                    lblSonuc.Text = "Personel eklenemedi.";
                }
            }
            catch (Exception ex)
            {
                Logger.Log(ex.ToString());
                lblSonuc.Text = $"Hata: {ex.Message}";
            }
        }

        protected void Guncelle_Click(object sender, EventArgs e)
        {
            try
            {
                Personel guncellenenPersonel = UIdenPersonelNesnesiOlustur();
                bool sonuc = PersonelManager.PersonelGuncelle(guncellenenPersonel);
                if (sonuc)
                {
                    lblModalMessage.Text = "Güncelleme işlemi başarılı.";
                    ScriptManager.RegisterStartupScript(this, GetType(), "showModal", "showModal();", true);
                }
                else
                {
                    lblSonuc.Text = "Personel güncellenemedi.";
                }
            }
            catch (Exception ex)
            {
                Logger.Log(ex.ToString());
                lblSonuc.Text = $"Hata: {ex.Message}";
            }
        }

        protected void BilgiGetir_Click(object sender, EventArgs e)
        {
            try
            {
                Personel personel = PersonelManager.PersonelGetir(txtTC.Text);
                if (personel != null)
                {
                    TCdenBilgiGetir(personel);
                    OgrenimGecmisiniGetir();
                }
            }
            catch (Exception ex)
            {
                Logger.Log(ex.ToString());
                lblSonuc.Text = $"Hata: {ex.Message}";
            }
        }

        protected void Sicil_TextChanged(object sender, EventArgs e)
        {

        }

        // --- VERİ EŞLEME METODLARI ---
        private Personel UIdenPersonelNesnesiOlustur()
        {
            return new Personel
            {
                TcKimlikNo = txtTC.Text,
                Adi = txtAd.Text,
                Soyad = txtSoyad.Text,
                DogumYeri = txtDogumYeri.Text,
                DogumTarihi = txtDogumTarihi.Text,
                Cinsiyet = ddlCinsiyet.SelectedValue,
                Statu = ddlStatu.SelectedValue,
                SicilNo = txtSicil.Text,
                ResimUrl = PersonelHelper.ResimUrlOlustur(ddlStatu.SelectedValue, txtSicil.Text, txtTC.Text),
                AcilDurumKisi = txtAcilAdSoyad.Text,
                Adres = txtAdres.Text,
                AskerlikDurumu = ddlAskerlik.SelectedValue,
                AcilDurumTelefon = txtAcilCep.Text,
                CalismaDurumu = ddlCalismaDurumu.SelectedValue,
                CariYilIzin = string.IsNullOrEmpty(txtCariIzin.Text) ? (int?)null : Convert.ToInt32(txtCariIzin.Text),
                CepTelefonu = txtCep.Text,
                DahiliTelefon = txtDahili.Text,
                DevredenIzin = string.IsNullOrEmpty(txtDevredenIzin.Text) ? (int?)null : Convert.ToInt32(txtDevredenIzin.Text),
                Durum = ddlDurum.SelectedValue,
                EmeklilikAciklama = txtEmeklilikAciklama.Text,
                EmeklilikTarihi = string.IsNullOrEmpty(txtEmeklilikTarihi.Text) ? (DateTime?)null : Convert.ToDateTime(txtEmeklilikTarihi.Text),
                EngelAciklama = txtEngelAciklama.Text,
                EngelDurumu = ddlEngelDurumu.SelectedValue,
                EvTelefonu = txtEvTel.Text,
                GeciciGelenKurum = ddlGeciciGelenKurum.SelectedValue,
                GeciciGorevBaslangic = string.IsNullOrEmpty(txtGGorevBaslamaTarihi.Text) ? (DateTime?)null : Convert.ToDateTime(txtGGorevBaslamaTarihi.Text),
                GeciciGorevBitis = string.IsNullOrEmpty(txtGGorevBitisTarihi.Text) ? (DateTime?)null : Convert.ToDateTime(txtGGorevBitisTarihi.Text),
                GeciciGidenKurum = ddlGeciciGidenKurum.SelectedValue,
                GorevYaptigiBirim = ddlBirim.SelectedValue,
                IseGirisTarihi = string.IsNullOrEmpty(txtIlkGiris.Text) ? (DateTime?)null : Convert.ToDateTime(txtIlkGiris.Text),
                IstenAyrilisTarihi = string.IsNullOrEmpty(txtIstenAyrilisTarihi.Text) ? (DateTime?)null : Convert.ToDateTime(txtIstenAyrilisTarihi),
                IstenAyrilisSebebi = ddlIstenAyrilisSebebi.SelectedValue,
                KadroDerece = txtKadroDerece.Text,
                KanGrubu = ddlKanGrubu.SelectedValue,
                KurumaGirisTarihi = string.IsNullOrEmpty(txtKurumaBaslamaTarihi.Text) ? (DateTime?)null : Convert.ToDateTime(txtKurumaBaslamaTarihi.Text),
                EmailAdresi = txtEmail.Text,
                MedeniHali = ddlMedeniHal.SelectedValue,
                MeslekiUnvan = txtMeslekiUnvan.Text,
                OgrenimDurumu = ddlOgrenimListesi.SelectedValue,
                Sendika = ddlSendika.SelectedValue,
                Unvan = ddlUnvan.SelectedValue,
                YaslilikAylikTarihi = string.IsNullOrEmpty(txtYaslilikAyligi.Text) ? (DateTime?)null : Convert.ToDateTime(txtYaslilikAyligi.Text)
            };
        }

        private void TCdenBilgiGetir(Personel personel)
        {
            imgPersonel.ImageUrl = personel.ResimUrl;
            txtAcilAdSoyad.Text = personel.AcilDurumKisi;
            txtAcilCep.Text = personel.AcilDurumTelefon;
            txtAd.Text = personel.Adi;
            txtAdres.Text = personel.Adres;
            txtCariIzin.Text = personel.CariYilIzin.ToString();
            txtCep.Text = personel.CepTelefonu;
            txtDahili.Text = personel.DahiliTelefon;
            txtDevredenIzin.Text = personel.DevredenIzin.ToString();
            txtDogumTarihi.Text = personel.DogumTarihi;
            txtDogumYeri.Text = personel.DogumYeri;
            txtEmail.Text = personel.EmailAdresi;
            txtEmeklilikAciklama.Text = personel.EmeklilikAciklama;
            txtEmeklilikTarihi.Text = personel.EmeklilikTarihi.ToString();
            txtEngelAciklama.Text = personel.EngelAciklama;
            txtEvTel.Text = personel.EvTelefonu;
            txtGGorevBaslamaTarihi.Text = personel.GeciciGorevBaslangic.ToString();
            txtGGorevBitisTarihi.Text = personel.GeciciGorevBitis.ToString();
            txtIlkGiris.Text = personel.IseGirisTarihi.ToString();
            txtIstenAyrilisTarihi.Text = personel.IstenAyrilisTarihi.ToString();
            txtKadroDerece.Text = personel.KadroDerece;
            txtKurumaBaslamaTarihi.Text = personel.KurumaGirisTarihi.ToString();
            txtMeslekiUnvan.Text = personel.MeslekiUnvan;
            txtSicil.Text = personel.SicilNo;
            txtSoyad.Text = personel.Soyad;
            txtTC.Text = personel.TcKimlikNo;
            txtYaslilikAyligi.Text = personel.YaslilikAylikTarihi.ToString();
            ddlAskerlik.Text = personel.AskerlikDurumu;
            ddlBirim.Text = personel.GorevYaptigiBirim;
            ddlCalismaDurumu.Text = personel.CalismaDurumu;
            ddlCinsiyet.Text = personel.Cinsiyet;
            ddlDurum.Text = personel.Durum;
            ddlEngelDurumu.Text = personel.EngelDurumu;
            ddlGeciciGelenKurum.Text = personel.GeciciGelenKurum;
            ddlGeciciGidenKurum.Text = personel.GeciciGelenKurum;
            ddlIstenAyrilisSebebi.Text = personel.IstenAyrilisSebebi;
            ddlKanGrubu.Text = personel.KanGrubu;
            ddlMedeniHal.Text = personel.MedeniHali;
            ddlOgrenimListesi.Text = personel.OgrenimDurumu;
            ddlSendika.Text = personel.Sendika;
            ddlStatu.Text = personel.Statu;
            ddlUnvan.Text = personel.Unvan;
        }

        private void SicildenBilgiGetir()
        {

        }

        protected void SicildenBilgiGetir_Click(object sender, EventArgs e)
        {
            try
            {
                Personel personel = PersonelManager.TumPersonelleriGetir().FirstOrDefault(p => p.SicilNo == txtSicil.Text);
                if (personel != null)
                {
                    TCdenBilgiGetir(personel);
                    OgrenimGecmisiniGetir();
                }
            }
            catch (Exception ex)
            {
                Logger.Log(ex.ToString());
                lblSonuc.Text = $"Hata: {ex.Message}";
                throw;
            }
        }

        protected void Vazgec_Click(object sender, EventArgs e)
        {
            //Response.Redirect("anasayfa.aspx"); // veya formu sıfırlama işlemi
        }

        protected void Yazdir_Click(object sender, EventArgs e)
        {
            // Yazdırma işlemi için istemci tarafı JavaScript ile bir panelin yazdırılması sağlanabilir
            lblSonuc.Text = "Yazdırma işlemi başlatıldı.";
        }

        protected void Statu_SelectedIndexChanged(object sender, EventArgs e)
        {
            imgPersonel.ImageUrl = PersonelHelper.ResimUrlOlustur(ddlStatu.SelectedValue, txtSicil.Text, txtTC.Text);
        }

        private void OgrenimGecmisiniGetir()
        {
            gvOgrenimBilgileri.DataSource = VeriKaynagi.OgrenimGecmisiGetir(txtTC.Text);
            gvOgrenimBilgileri.DataBind();
        }
    }
}