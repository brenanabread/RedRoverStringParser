using System.Linq;


namespace RedRoverStringParser;

public static class FieldPrinter
{
    public static void PrintStandard(List<Field> fields, int indent)
    {
        //loop through fields
        foreach (var f in fields)
        {
            //sets up indents for when there are and are not child nodes
            Console.WriteLine($"{new string(' ', indent * 2)}- {f.Name}");
            if (f.Children != null)
                PrintStandard(f.Children, indent + 1);
        }
    }

    public static void PrintAlphabetical(List<Field> fields, int indent)
    {
        //same as line 11 but sorts into aphabetical order before looping
        foreach (var f in fields.OrderBy(f => f.Name))
        {
            Console.WriteLine($"{new string(' ', indent * 2)}- {f.Name}");
            if (f.Children != null)
                PrintAlphabetical(f.Children, indent + 1);
        }
    }
}

