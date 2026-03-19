

namespace RedRoverStringParser;

public static class FieldValidator
{
    public static List<string> Validate(string input)
    {
        var errors = new List<string>();
     //does string exist at all
     if (string.IsNullOrWhiteSpace(input))
     {
         errors.Add("No input provided");
         return errors;
     }
     
     //does string have both starting and ending () parentheses 
     if (!input.StartsWith("(") || !input.EndsWith(")"))
     {
         errors.Add("Input needs to begin with ( and end with ) to be valid.");
         return errors;
     }
     /*does string have all expected fields, based on the assumption that the comma delimiter would still be provided 
     even if the field name is not*/
     if (input.Contains(",,") || input.Contains("(,") || input.Contains(",)"))
         //checks for double commas at the start, middle and end of string
         errors.Add("Check for missing field names in input");
     return errors;
    }
}

