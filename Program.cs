

namespace RedRoverStringParser;

internal class Program
{
    public static void Main(string[] args)
    {
        //get input, currently hardcoded here.
        var input = "(id, name, email, type(id, name, customFields(c1, c2, c3)), externalId)";
        
        /*string examples:
         Good: (id, name, email, type(id, name, customFields(c1, c2, c3)), externalId)
         Bad 1: just empty
         Bad 2: (id, name, email, type(id, name, customFields(c1, c2, c3)), externalId --no ending )
         Bad 3: (id, name, email, type(id, name, customFields(c1,, c3)), externalId)*/
        
        
        //using FieldValidated to validate input, check for issues incase this moves to accepting input string from other sources

        var errors = FieldValidator.Validate(input);
        if (errors.Count > 0)
        {
            Console.WriteLine("Invalid Input:");
            foreach (var error in errors)
                    Console.WriteLine($" - {error}");
            return;
           
        }
        
        //Parsing--or sectioning the string into chunks based on delimiters () and , using FieldParser 
        var fields = FieldParser.Parse(input);

        //calling FieldPrinter to print the string into a Nested Tree in the original order it was received 
        Console.WriteLine("Original Order:");
        FieldPrinter.PrintStandard(fields, indent: 0);
        
        //indent: 0 means to start with no indentation at the main root
        
        //calling FieldPrinter to print the string into a Nested Tree in alphabetical order 
        Console.WriteLine("\nAlphabetical Order:");
        FieldPrinter.PrintAlphabetical(fields, indent: 0);
    }
}

//indent NOT intent