using Portal.Configuration;
using Portal.DataAccess;
using Portal.DataAccess.Model;
using Portal.Helpers;
using System;
using System.Collections.Generic;

namespace Portal.BusinessLogic
{
    public static class PersonelManager
    {
        private static readonly PersonelDataAccess _dataAccess = new PersonelDataAccess();

        public static bool PersonelEkle(Personel personel)
        {
            if (!PersonelHelper.TcKimlikNoGecerliMi(personel.TcKimlikNo))
                throw new ArgumentException("Geçersiz TC Kimlik Numarası");

            if (personel.Statu == Constants.MemurStatu && string.IsNullOrEmpty(personel.SicilNo))
                throw new ArgumentException("Memur statüsü için sicil no zorunludur");

            return _dataAccess.PersonelEkle(personel);
        }

        public static Personel PersonelGetir(string tcKimlikNo)
        {
            if (!PersonelHelper.TcKimlikNoGecerliMi(tcKimlikNo))
                throw new ArgumentException("Geçersiz TC Kimlik Numarası");

            return _dataAccess.PersonelGetir(tcKimlikNo);
        }

        public static List<Personel> TumPersonelleriGetir() => _dataAccess.TumPersonelleriGetir();

        public static bool PersonelGuncelle(Personel personel)
        {
            if (personel.Statu == Constants.MemurStatu && string.IsNullOrEmpty(personel.SicilNo))
                throw new ArgumentException("Memur statüsü için sicil no zorunludur");

            return _dataAccess.PersonelGuncelle(personel);
        }

        public static bool PersonelSil(string tcKimlikNo)
        {
            if (!PersonelHelper.TcKimlikNoGecerliMi(tcKimlikNo))
                throw new ArgumentException("Geçersiz TC Kimlik Numarası");

            return _dataAccess.PersonelSil(tcKimlikNo);
        }
    }
}