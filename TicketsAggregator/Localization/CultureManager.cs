using System.Globalization;

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
