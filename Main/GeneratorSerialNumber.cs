using System.Collections.Concurrent;

namespace ConsoleApp2.Main;

public class GeneratorSerialNumber
{
    private static Dictionary<string, int> _counters = new Dictionary<string, int>();
    public static string GenerateSerialNumber(string containterTypeCode)
    {
        if (!_counters.ContainsKey(containterTypeCode))
        {
            _counters[containterTypeCode] = 1;
        }
        else
        {
            _counters[containterTypeCode]++;
        }

        return $"KON-{containterTypeCode}-{_counters[containterTypeCode]}";
    }
}