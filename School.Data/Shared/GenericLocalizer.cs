using System.Globalization;

namespace School.Domain.Shared
{
    public class GenericLocalizable
    {
        public string Localizable(string strEng, string strAr)
        {
            CultureInfo cultureInfo = Thread.CurrentThread.CurrentCulture;

            if (cultureInfo != null && cultureInfo.TwoLetterISOLanguageName.ToLower() == "ar")
            {
                return strAr;
            }
            return strEng;

        }
    }
}
