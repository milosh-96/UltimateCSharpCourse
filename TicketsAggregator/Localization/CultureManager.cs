using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicketsAggregator.Localization;
internal static class CultureManager
{
    public static void SetCurrentCultureOrUseInvariant(CultureInfo? culture = null)
    {
        if (culture is null)
        {
            CultureInfo.CurrentCulture = CultureInfo.InvariantCulture;
        }
        else
        {
            CultureInfo.CurrentCulture = culture;
        }
    }
}
