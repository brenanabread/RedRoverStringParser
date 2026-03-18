namespace RedRoverStringParser;

public record Field(string Name, List<Field>? Children);
