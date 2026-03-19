namespace RedRoverStringParser;

public record Field(string Name, List<Field>? Children);

//creates field named type with nested children. ? means it doesnt have to have kids. 