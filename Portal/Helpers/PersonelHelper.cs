using System.Linq;

namespace Portal.Helpers
{
    public static class PersonelHelper
    {
        public static string ResimUrlOlustur(string statu, string sicilNo, string tcNo)
        {
            return statu == "Memur"
                ? $"http://personel.udhb.gov.tr/kugm/personel/perResim/{sicilNo}.jpg"
                : $"http://personel.udhb.gov.tr/kugm/personel/perResim/IP{tcNo}.jpg";
        }

        public static bool TcKimlikNoGecerliMi(string tcNo)
        {
            if (string.IsNullOrEmpty(tcNo) || tcNo.Length != 11 || !tcNo.All(char.IsDigit) || tcNo[0] == '0')
                return false;

            int[] digits = tcNo.Select(c => int.Parse(c.ToString())).ToArray();
            int oddSum = digits[0] + digits[2] + digits[4] + digits[6] + digits[8];
            int evenSum = digits[1] + digits[3] + digits[5] + digits[7];
            int checkDigit1 = (oddSum * 7 - evenSum) % 10;
            int checkDigit2 = (oddSum + evenSum + digits[9]) % 10;

            return checkDigit1 == digits[9] && checkDigit2 == digits[10];
        }
    }
}