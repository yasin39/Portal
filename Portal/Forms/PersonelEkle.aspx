<%@ Page Title="" Language="C#" MasterPageFile="~/Forms/Site.Master" AutoEventWireup="true" CodeBehind="PersonelEkle.aspx.cs" Inherits="Portal.Forms.WebForm2" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <style>
        .modal {
            display: none;
            position: fixed;
            top: 50%;
            left: 50%;
            transform: translate(-50%, -50%);
            background-color: white;
            padding: 20px;
            border: 1px solid #ccc;
            z-index: 1001; /* Backdrop'tan üstte olsun */
            width: 400px; /* Sabit bir genişlik */
            height: 200px; /* Sabit bir yükseklik, kısaltıyoruz */
            overflow-y: auto; /* İçerik taşarsa kaydırma çubuğu çıksın */
        }

        .modal-backdrop {
            display: none;
            position: fixed;
            top: 0;
            left: 0;
            width: 100%;
            height: 100%;
            background: rgba(0,0,0,0.5);
            z-index: 1000; /* Modalın altında kalsın */
        }

        .modal.show {
            display: block;
        }

        .modal-backdrop.show {
            display: block;
        }
    </style>

    <div id="customModal" class="modal">
        <h3>İşlem Başarılı</h3>
        <asp:Label ID="lblModalMessage" runat="server" Text=""></asp:Label>
        <br />
        <button type="button" onclick="closeModal()">Tamam</button>
    </div>

    <div id="modalBackdrop" class="modal-backdrop"></div>
    <asp:Panel ID="pnlYazdır" runat="server">
        <div class="row-fluid sortable">
            <div class="box span12">
                <div class="box-header" data-original-title>
                    <h2><i class="halflings-icon white user"></i>

                        <span class="break"></span>Personel Kayıt</h2>
                    <div class="box-icon">

                        <a href="#" class="btn-minimize"><i class="halflings-icon white chevron-up"></i></a>
                        <a href="#" class="btn-close"><i class="halflings-icon white remove"></i></a>
                    </div>
                </div>
                <div class="box-content">
                    <form class="form-horizontal">
                        <link href="~/Content/bootstrap.min.css" rel="stylesheet" />



                        <fieldset>

                            <div class="priority high"><span><i class="icon-credit-card"></i>--Kimlik Bilgileri</span></div>
                            <div class="task high">

                                <table class="verticalChart">
                                    <tr>
                                        <td>TC Kimlik No</td>
                                        <td colspan="3">
                                            <asp:TextBox ID="txtTC" runat="server" AutoPostBack="True"></asp:TextBox>
                                            <button id="btnBilgiGetir" runat="server" onserverclick="BilgiGetir_Click" class="btn btn-primary noty" data-noty-options='{"text":"Arama Yapılıyor","layout":"top","type":"information"}'><i class="halflings-icon white white edit"></i>Bilgileri Getir</button>

                                            <asp:Label ID="Label2" runat="server" Style="font-size: xx-small"></asp:Label>

                                        </td>
                                        <td rowspan="4" style="text-align: right">
                                            <asp:Image ID="imgPersonel" runat="server" Height="186px" ImageUrl="~/resimler/personel.ico" Width="145px" /></td>
                                    </tr>
                                    <tr>
                                        <td>Adı</td>
                                        <td>
                                            <asp:TextBox ID="txtAd" runat="server"></asp:TextBox>
                                        </td>
                                        <td>Soyadı</td>
                                        <td>
                                            <asp:TextBox ID="txtSoyad" runat="server"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>Doğum Yeri</td>
                                        <td>
                                            <asp:TextBox ID="txtDogumYeri" runat="server"></asp:TextBox>
                                        </td>
                                        <td>Doğum Tarihi</td>
                                        <td>
                                            <asp:TextBox ID="txtDogumTarihi" runat="server" TextMode="Date"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>Cinsiyet</td>
                                        <td>
                                            <asp:DropDownList ID="ddlCinsiyet" runat="server">
                                                <asp:ListItem>Erkek</asp:ListItem>
                                                <asp:ListItem>Bayan</asp:ListItem>
                                            </asp:DropDownList>
                                            <asp:Label ID="Label1" runat="server" Style="color: #FF0000; font-weight: 700"></asp:Label>
                                        </td>
                                        <td>Durum</td>
                                        <td>
                                            <asp:DropDownList ID="ddlDurum" runat="server">
                                                <asp:ListItem>Aktif</asp:ListItem>
                                                <asp:ListItem>Pasif</asp:ListItem>
                                            </asp:DropDownList>
                                        </td>
                                    </tr>
                                </table>


                            </div>
                            <div class="priority high"><span><i class="icon-briefcase"></i>--Mesleki Bilgileri</span></div>

                            <div class="task  high last">

                                <table class="verticalChart">
                                    <tr>
                                        <td class="auto-style1">Sicil No</td>
                                        <td class="auto-style1">
                                            <asp:TextBox ID="txtSicil" runat="server" TextMode="Number" AutoPostBack="True" OnTextChanged="Sicil_TextChanged"></asp:TextBox>

                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtSicil" ErrorMessage="Sicil No Giriniz" ForeColor="Red" ValidationGroup="perkayit">*</asp:RequiredFieldValidator>

                                            <button id="btnSicildenBilgiGetir" runat="server" onserverclick="SicildenBilgiGetir_Click" class="btn btn-primary noty" data-noty-options='{"text":"Arama Yapılıyor","layout":"top","type":"information"}'><i class="halflings-icon white white edit"></i>Bul</button>

                                        </td>
                                        <td class="auto-style1">Personel Durumu</td>
                                        <td class="auto-style1">
                                            <asp:DropDownList ID="ddlCalismaDurumu" runat="server">
                                                <asp:ListItem>Kadrolu Aktif Çalışan</asp:ListItem>
                                                <asp:ListItem>Geçici Görevli Aktif Çalışan</asp:ListItem>
                                                <asp:ListItem>Geçici Görevde Pasif Çalışan</asp:ListItem>
                                                <asp:ListItem>Firma Personeli</asp:ListItem>
                                                <asp:ListItem>İşkur İşçi (TYP)</asp:ListItem>
                                            </asp:DropDownList>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>Unvanı</td>
                                        <td>
                                            <asp:DropDownList ID="ddlUnvan" runat="server" AppendDataBoundItems="True">
                                            </asp:DropDownList>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="ddlUnvan" ErrorMessage="Personel Ünvanını Seçiniz." ForeColor="Red" ValidationGroup="perkayit">*</asp:RequiredFieldValidator>
                                        </td>
                                        <td>Mesleki Unvanı</td>
                                        <td>
                                            <asp:TextBox ID="txtMeslekiUnvan" runat="server" placeholder="Örn:Bilgisayar Mühendisi"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>Statü</td>
                                        <td>
                                            <asp:DropDownList ID="ddlStatu" runat="server" AutoPostBack="True" OnSelectedIndexChanged="Statu_SelectedIndexChanged">
                                                <asp:ListItem>Memur</asp:ListItem>
                                                <asp:ListItem>işçi</asp:ListItem>
                                                <asp:ListItem>Firma Personeli</asp:ListItem>
                                                <asp:ListItem>İşkur İşçi (TYP)</asp:ListItem>
                                                <asp:ListItem>Sözleşmeli Personel (4-B)</asp:ListItem>
                                                <asp:ListItem>işçi (375 KHK)</asp:ListItem>
                                            </asp:DropDownList>
                                        </td>
                                        <td>Geçici Gelen Pers. Kurumu</td>
                                        <td>
                                            <asp:DropDownList ID="ddlGeciciGelenKurum" runat="server" AppendDataBoundItems="True">
                                            </asp:DropDownList>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>İlk İşe Giriş Tarihi</td>
                                        <td>
                                            <asp:TextBox ID="txtIlkGiris" runat="server" TextMode="Date"></asp:TextBox>
                                        </td>
                                        <td>Geçici Giden Pers. Kurumu</td>
                                        <td>
                                            <asp:DropDownList ID="ddlGeciciGidenKurum" runat="server" AppendDataBoundItems="True">
                                            </asp:DropDownList>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>Kuruma Başlangıç Tarihi</td>
                                        <td>
                                            <asp:TextBox ID="txtKurumaBaslamaTarihi" runat="server" TextMode="Date"></asp:TextBox>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtKurumaBaslamaTarihi" ErrorMessage="Kuruma Başlangıç Tarihini Giriniz." ForeColor="Red" ValidationGroup="perkayit">*</asp:RequiredFieldValidator>
                                        </td>
                                        <td>İşten Ayrılış Tarihi</td>
                                        <td>
                                            <asp:TextBox ID="txtIstenAyrilisTarihi" runat="server" TextMode="Date"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>Görev Yaptığı Birim</td>
                                        <td>
                                            <asp:DropDownList ID="ddlBirim" runat="server" AppendDataBoundItems="True">
                                            </asp:DropDownList>
                                        </td>
                                        <td>İşten Ayrılış Sebebi</td>
                                        <td>
                                            <asp:DropDownList ID="ddlIstenAyrilisSebebi" runat="server">
                                                <asp:ListItem> </asp:ListItem>
                                                <asp:ListItem>Geçici Görev Bitişi</asp:ListItem>
                                                <asp:ListItem>Naklen Atama</asp:ListItem>
                                                <asp:ListItem>Emeklilik</asp:ListItem>
                                                <asp:ListItem>istifa</asp:ListItem>
                                                <asp:ListItem>Atılma</asp:ListItem>
                                                <asp:ListItem>Diğer</asp:ListItem>
                                            </asp:DropDownList>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>G.Görev Baş. Tarihi</td>
                                        <td>
                                            <asp:TextBox ID="txtGGorevBaslamaTarihi" runat="server" TextMode="Date"></asp:TextBox>
                                        </td>
                                        <td>G. Görev Bitiş Tarihi</td>
                                        <td>
                                            <asp:TextBox ID="txtGGorevBitisTarihi" runat="server" TextMode="Date"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>Devreden İzin</td>
                                        <td>
                                            <asp:TextBox ID="txtDevredenIzin" runat="server"></asp:TextBox>
                                        </td>
                                        <td>Cari Yıl İzni</td>
                                        <td>
                                            <asp:TextBox ID="txtCariIzin" runat="server"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>Kadro Derecesi</td>
                                        <td>
                                            <asp:TextBox ID="txtKadroDerece" runat="server" TextMode="Number"></asp:TextBox>
                                        </td>
                                        <td>&nbsp;</td>
                                        <td>&nbsp;</td>
                                    </tr>
                                </table>

                            </div>
                            <div class="priority high"><span><i class="icon-book"></i>--Eğitim Durumu</span></div>

                            <div class="task high">


                                <table class="verticalChart">
                                    <tr>
                                        <td style="text-align: center">
                                            <center>


                                                <table class="verticalChart">
                                                    <tr>
                                                        <td>Öğrenim Durumu (Son mezun olunan)</td>
                                                        <td>
                                                            <asp:DropDownList ID="ddlOgrenimListesi" runat="server">
                                                                <asp:ListItem>İlk Okul</asp:ListItem>
                                                                <asp:ListItem>Orta Okul</asp:ListItem>
                                                                <asp:ListItem>Lise</asp:ListItem>
                                                                <asp:ListItem>Yüksek Okul</asp:ListItem>
                                                                <asp:ListItem>Lisans</asp:ListItem>
                                                                <asp:ListItem>Yüksek Lisans</asp:ListItem>
                                                            </asp:DropDownList>
                                                        </td>
                                                        <td>&nbsp;</td>
                                                        <td>&nbsp;</td>
                                                    </tr>
                                                </table>
                                                <br />


                                                <asp:GridView ID="gvOgrenimBilgileri" runat="server" BackColor="White" BorderColor="#CCCCCC" BorderWidth="1px" CellPadding="3" AutoGenerateColumns="False" BorderStyle="None">
                                                    <columns>
                                                        <asp:BoundField DataField="Ogr_Durumu" HeaderText="Öğrenim Durumu" />
                                                        <asp:BoundField DataField="Okul" HeaderText="Okul/Fakülte" />
                                                        <asp:BoundField DataField="Bolum" HeaderText="Bölüm" />
                                                        <asp:BoundField DataField="Mezuniyet_Tarihi" HeaderText="Mezuniyet Tarihi" DataFormatString="{0:dd/MM/yyyy}" />
                                                    </columns>
                                                    <footerstyle backcolor="White" forecolor="#000066" />
                                                    <headerstyle backcolor="#006699" font-bold="True" forecolor="White" />
                                                    <pagerstyle backcolor="White" forecolor="#000066" horizontalalign="Left" />
                                                    <rowstyle forecolor="#000066" />
                                                    <selectedrowstyle backcolor="#669999" forecolor="White" font-bold="True" />
                                                    <sortedascendingcellstyle backcolor="#F1F1F1" />
                                                    <sortedascendingheaderstyle backcolor="#007DBB" />
                                                    <sorteddescendingcellstyle backcolor="#CAC9C9" />
                                                    <sorteddescendingheaderstyle backcolor="#00547E" />
                                                </asp:GridView>
                                            </center>
                                        </td>
                                    </tr>
                                </table>


                            </div>
                            <div class="priority high"><span><i class="icon-phone"></i>--İletişim Bilgileri</span></div>

                            <div class="task high">


                                <table class="verticalChart">
                                    <tr>
                                        <td>Cep Telefonu</td>
                                        <td>
                                            <asp:TextBox ID="txtCep" runat="server" TextMode="Phone" placeholder="Örn:5051234567"></asp:TextBox>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="txtCep" ErrorMessage="Cep telefonu Giriniz" ForeColor="Red" ValidationGroup="perkayit">*</asp:RequiredFieldValidator>
                                        </td>
                                        <td>Mail Adresi</td>
                                        <td>
                                            <asp:TextBox ID="txtEmail" runat="server" TextMode="Email" placeholder="Örn:ankara.bolge@udhb.gov.tr"></asp:TextBox>
                                            <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="txtEmail" ErrorMessage="Geçerli bir mail adresi giriniz..." ForeColor="Red" ValidationExpression="\w+([-+.’]\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" ValidationGroup="perkayit">*</asp:RegularExpressionValidator>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>Ev Telefonu</td>
                                        <td>
                                            <asp:TextBox ID="txtEvTel" runat="server"></asp:TextBox>
                                        </td>
                                        <td>Adres</td>
                                        <td rowspan="2">
                                            <asp:TextBox ID="txtAdres" runat="server" Height="60px" TextMode="MultiLine" Width="207px"></asp:TextBox>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="txtAdres" ErrorMessage="Adresini Giriniz." ForeColor="Red" ValidationGroup="perkayit">*</asp:RequiredFieldValidator>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>Dahili</td>
                                        <td>
                                            <asp:TextBox ID="txtDahili" runat="server"></asp:TextBox>
                                        </td>
                                        <td>&nbsp;</td>
                                    </tr>
                                    <tr>
                                        <td>Acil Durumda Aranacak Kişi</td>
                                        <td>
                                            <asp:TextBox ID="txtAcilAdSoyad" runat="server" placeholder="1. Derece Yakınlarından Birinin Adı Soyadı"></asp:TextBox>
                                        </td>
                                        <td>Cep Telefonu</td>
                                        <td>
                                            <asp:TextBox ID="txtAcilCep" runat="server"></asp:TextBox>
                                        </td>
                                    </tr>
                                </table>


                            </div>
                            <div class="priority high"><span><i class="icon-cogs"></i>--Diğer Bilgiler</span></div>

                            <div class="task high">


                                <table class="verticalChart">
                                    <tr>
                                        <td>Kan Grubu</td>
                                        <td>
                                            <asp:DropDownList ID="ddlKanGrubu" runat="server">
                                                <asp:ListItem>A(+)</asp:ListItem>
                                                <asp:ListItem>A(-)</asp:ListItem>
                                                <asp:ListItem>B(+)</asp:ListItem>
                                                <asp:ListItem>B(-)</asp:ListItem>
                                                <asp:ListItem>AB(+)</asp:ListItem>
                                                <asp:ListItem>AB(-)</asp:ListItem>
                                                <asp:ListItem>0(+)</asp:ListItem>
                                                <asp:ListItem>0(-)</asp:ListItem>
                                            </asp:DropDownList>
                                        </td>
                                        <td>Medeni Hali</td>
                                        <td>
                                            <asp:DropDownList ID="ddlMedeniHal" runat="server">
                                                <asp:ListItem>Evli</asp:ListItem>
                                                <asp:ListItem>Bekar</asp:ListItem>
                                                <asp:ListItem>Boşanmış</asp:ListItem>
                                            </asp:DropDownList>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="auto-style1">Askerlik Durumu</td>
                                        <td class="auto-style1">
                                            <asp:DropDownList ID="ddlAskerlik" runat="server">
                                                <asp:ListItem></asp:ListItem>
                                                <asp:ListItem>Bitirilmiş</asp:ListItem>
                                                <asp:ListItem>Tecilli</asp:ListItem>
                                                <asp:ListItem>Muaf</asp:ListItem>
                                            </asp:DropDownList>
                                        </td>
                                        <td class="auto-style1">Engel Durumu</td>
                                        <td class="auto-style1">
                                            <asp:DropDownList ID="ddlEngelDurumu" runat="server">
                                                <asp:ListItem>Yok</asp:ListItem>
                                                <asp:ListItem>Var</asp:ListItem>
                                            </asp:DropDownList>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>Bağlı Olduğu Sendika</td>
                                        <td>
                                            <asp:DropDownList ID="ddlSendika" runat="server" AppendDataBoundItems="True">
                                            </asp:DropDownList>
                                        </td>
                                        <td>Engel Açıklama</td>
                                        <td>
                                            <asp:TextBox ID="txtEngelAciklama" runat="server" TextMode="MultiLine"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>Emeklilik Hak Ediş Tarihi</td>
                                        <td>
                                            <asp:TextBox ID="txtEmeklilikTarihi" runat="server" TextMode="Date"></asp:TextBox>
                                        </td>
                                        <td>Yaşlılık Aylığı Almaya<br />
                                            Hak Kazandığı Tarih</td>
                                        <td>
                                            <asp:TextBox ID="txtYaslilikAyligi" runat="server" TextMode="Date"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>Açıklama (Emeklilik)</td>
                                        <td>
                                            <asp:TextBox ID="txtEmeklilikAciklama" runat="server" Height="80px" TextMode="MultiLine"></asp:TextBox>
                                        </td>
                                        <td>&nbsp;</td>
                                        <td>&nbsp;</td>
                                    </tr>
                                    <tr>
                                        <td colspan="4">
                                            <asp:ValidationSummary ID="ValidationSummary1" runat="server" ForeColor="Red" Style="font-size: xx-small" ValidationGroup="perkayit" />
                                            <br />
                                            <asp:Label ID="lblSonuc" runat="server" Font-Bold="True" Font-Size="Medium"></asp:Label>
                                        </td>
                                    </tr>
                                </table>

                                <button id="btnEkle" runat="server" onserverclick="Ekle_Click" class="btn btn-primary noty" data-noty-options='{"text":"Kaydediliyor...","layout":"top","type":"information"}' validationgroup="perkayit"><i class="halflings-icon white white user"></i>Ekle</button>
                                <button id="btnGuncelle" runat="server" onserverclick="Guncelle_Click" class="btn btn-primary noty" data-noty-options='{"text":"Güncelleniyor...","layout":"top","type":"information"}' validationgroup="perkayit"><i class="halflings-icon white white edit"></i>Güncelle</button>
                                <button id="btnVazgec" runat="server" onserverclick="Vazgec_Click" class="btn btn-primary noty" data-noty-options='{"text":"İşlemden Vazgeçildi...","layout":"Center","type":"error"}'><i class="halflings-icon white minus-sign"></i>Vazgeç</button>
                                <asp:Button ID="btnYazdir" runat="server" Text="Yazdır" onserverclick="Yazdir_Click" OnClientClick="return YazdirmaPaneli();" class="btn btn-primary noty" />

                            </div>
                        </fieldset>
                    </form>
                </div>
            </div>
            <!--/span-->
    </asp:Panel>
    <script>
        function showModal() {
            document.getElementById('customModal').classList.add('show');
            document.getElementById('modalBackdrop').classList.add('show');
        }

        function closeModal() {
            document.getElementById('customModal').classList.remove('show');
            document.getElementById('modalBackdrop').classList.remove('show');
        }
</script>
</asp:Content>
