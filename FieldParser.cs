using System.Collections.Generic;
namespace RedRoverStringParser;

//remember ; enders!
    
// keep the input in mind "(id, name, email, type(id, name, customFields(c1, c2, c3)), externalId)"
public static class FieldParser
{
    public static List<Field> Parse(string input)
    {
        input = input.Trim();
        if (input.StartsWith("(") && input.EndsWith(")"))
            input = input[1..^1];

        var fields = new List<Field>();
        var i=0;
        while (i < input.Length)
        {
            while (i < input.Length && (input[i] == ',' || input[i] == ' '))
                i++;
            if (i >= input.Length) break;
            
            var start = i;
            while (i < input.Length && input[i] !=',' && input[i] != '(' && input[i] != ')')
                i++;
            
            var name = input[start..i].Trim();
            
            List<Field>? children = null;
            if (i < input.Length && input[i] == '(')
            {
                var depth = 1;
                var childStart = i;
                i++;
                while (i < input.Length && depth > 0)
                {
                    if (input[i] == '(')  depth++;
                    else if (input[i] == ')') depth--;
                    i++;
                }
                children = Parse(input[childStart..i]);
            }
            fields.Add(new Field(name, children));
        }
        return fields;
    }
}

//i no longer remember how field is spelled. 