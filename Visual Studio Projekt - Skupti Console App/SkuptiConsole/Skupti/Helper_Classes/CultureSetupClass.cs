using System.Threading;

namespace Skupti.Helper_Classes
{
    public class CultureSetupClass
    {
        public static void SetupCorrectCulture()
        {
            var customCulture =
                (System.Globalization.CultureInfo)Thread.CurrentThread.CurrentCulture.Clone();

            customCulture.NumberFormat.NumberDecimalSeparator = ".";
            Thread.CurrentThread.CurrentCulture = customCulture;
        }
    }
}
