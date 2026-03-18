using System.Linq;


namespace RedRoverStringParser;

public static class FieldPrinter
{
    public static void PrintStandard(List<Field> fields, int indent)
    {
        foreach (var f in fields)
        {
            Console.WriteLine($"{new string(' ', indent * 2)}- {f.Name}");
            if (f.Children != null)
                PrintStandard(f.Children, indent + 1);
        }
    }

    public static void PrintAlphabetical(List<Field> fields, int indent)
    {
        foreach (var f in fields.OrderBy(f => f.Name))
        {
            Console.WriteLine($"{new string(' ', indent * 2)}- {f.Name}");
            if (f.Children != null)
                PrintAlphabetical(f.Children, indent + 1);
        }
    }
}

