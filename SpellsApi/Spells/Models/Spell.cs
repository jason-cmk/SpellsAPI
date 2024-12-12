namespace Spells.Models;

public record Components(bool Material, string Raw, bool Somatic, bool Verbal);

public record Spell(string CastingTime,
    List<string> Classes,
    Components Components,
    string Description,
    string Duration,
    string Level,
    string Name,
    string Range,
    bool Ritual,
    string School,
    List<string> Tags,
    string Type);
