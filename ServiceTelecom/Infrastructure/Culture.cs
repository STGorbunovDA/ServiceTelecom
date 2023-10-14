using System.Globalization;
using System.Threading;

namespace ServiceTelecom.Infrastructure
{
    internal static class Culture
    {
        internal static void UserCulture()
        {
            var myCulture = new CultureInfo("ru-RU");
            myCulture.NumberFormat.NumberDecimalSeparator = ".";

            Thread.CurrentThread.CurrentCulture = myCulture;
        }
    }
}
