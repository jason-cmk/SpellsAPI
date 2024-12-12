using Spells.Models;
using System.Text.Json.Serialization;

namespace Spells;

[JsonSerializable(typeof(List<Spell>))]
[JsonSourceGenerationOptions(GenerationMode = JsonSourceGenerationMode.Default,
        PropertyNamingPolicy = JsonKnownNamingPolicy.SnakeCaseLower,
        WriteIndented = true)]
public partial class SpellJsonContext : JsonSerializerContext
{}
