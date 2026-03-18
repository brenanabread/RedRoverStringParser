using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace RedRoverStringParser;

internal class Program
{
    public static void Main(string[] args)
    {
        var input = "(id, name, email, type(id, name, customFields(c1, c2, c3)), externalId)";

        var fields = FieldParser.Parse(input);

        Console.WriteLine("Original Order:");
        FieldPrinter.PrintStandard(fields, indent: 0);

        Console.WriteLine("\nAlphabetical Order:");
        FieldPrinter.PrintAlphabetical(fields, indent: 0);
    }
}

//indent NOT intent