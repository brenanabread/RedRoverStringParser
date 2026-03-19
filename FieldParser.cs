using System.Collections.Generic;
namespace RedRoverStringParser;

//remember ; enders!
    
// keep the input in mind "(id, name, email, type(id, name, customFields(c1, c2, c3)), externalId)"
public static class FieldParser
{
    public static List<Field> Parse(string input)
    {
        /*takes the input and removes whitespace before the first character and after the last. Also makes sure 
        string is wrapped in ()*/
        input = input.Trim();
        if (input.StartsWith("(") && input.EndsWith(")"))
            input = input[1..^1];

        var fields = new List<Field>();
        var i=0;
        //loop time, go through everything until done
        while (i < input.Length)
        {
            while (i < input.Length && (input[i] == ',' || input[i] == ' '))
                i++;
            if (i >= input.Length) break;
            //skip , and ' ' space, stop when at end
            
            //read field names, designating the end of a field name at a delimiter (comma, parentheses) 
            var start = i;
            while (i < input.Length && input[i] !=',' && input[i] != '(' && input[i] != ')')
                i++;
            //grab name of field
            var name = input[start..i].Trim();
            
            //are there kids in the car??Check for children but assume there are none
            List<Field>? children = null;
            if (i < input.Length && input[i] == '(')
                //kids are determined if theres a new open parenthesis before the end of the string
            {
                //start looking for the closing parenthesis to indicate the end of children (teenagers??)
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
                //parse all the child fields
            }
            fields.Add(new Field(name, children));
            //add all parts of the tree, including parents and children
        }
        return fields;
    }
}

//i no longer remember how field is spelled. 