using Spells.Models;
using System.Text.Json;

namespace Spells;

public interface ISpellsService
{
    public Task<List<Spell>> GetSpells();
    public Task<List<Spell>> GetSpellsGenerated();
    public void MakeSpells();
    public void MakeSpellsGenerated();
}

public class SpellsService : ISpellsService
{
    private readonly JsonSerializerOptions serializerOptions = new JsonSerializerOptions
    {
        PropertyNamingPolicy = JsonNamingPolicy.SnakeCaseLower,
        WriteIndented = true,
    };

    public async Task<List<Spell>> GetSpells()
    {
        string spellsRaw = await File.ReadAllTextAsync("./spells.json");
        List<Spell> spells = JsonSerializer.Deserialize<List<Spell>>(spellsRaw, serializerOptions)!;

        return spells;
    }

    public async Task<List<Spell>> GetSpellsGenerated()
    {
        string spellsRaw = await File.ReadAllTextAsync("./spells.json");
        List<Spell> spells = JsonSerializer.Deserialize(spellsRaw, SpellJsonContext.Default.ListSpell)!;

        return spells;
    }

    public void MakeSpells()
    {
        var spells = GenerateSpells(10000);

        var serialized = JsonSerializer.Serialize(spells, serializerOptions);
        File.WriteAllText($"./normal/made_spells_{Guid.NewGuid()}.json", serialized);
    }

    public void MakeSpellsGenerated()
    {
        var spells = GenerateSpells(10000);
        var serialized = JsonSerializer.Serialize(spells, SpellJsonContext.Default.ListSpell);
        File.WriteAllText($"./generated/made_spells_{Guid.NewGuid()}.json", serialized);
    }

    private List<Spell> GenerateSpells(int number)
    {
        List<Spell> spells = new();
        foreach (int i in Enumerable.Range(0, number))
        {
            var components = new Components(RandomBool(), RandomString(), RandomBool(), RandomBool());
            int classNumber = new Random().Next(10);
            List<string> classes = Enumerable.Range(0, classNumber).Select(_ => RandomString()).ToList();
            int tagsNumber = new Random().Next(10);
            List<string> tags = Enumerable.Range(0, classNumber).Select(_ => RandomString()).ToList();
            var spell = new Spell(RandomString(), classes, components, RandomString(), RandomString(), RandomString(), RandomString(), RandomString(), RandomBool(), RandomString(), tags, RandomString());
            spells.Add(spell);
        }
        return spells;
    }

    private bool RandomBool()
    {
        return new Random().Next(2) == 1;
    }

    private string RandomString()
    {
        return Guid.NewGuid().ToString();
    }
}
