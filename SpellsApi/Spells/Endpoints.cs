namespace Spells;

public record Test(string Id);
public static class Endpoints
{
    public static void RegisterEndpoints(this WebApplication app)
    {
        app.MapGet("/", () => "alive");

        app.MapGet("/spells", async ([FromKeyedServices("SpellsService")] ISpellsService spellsService) =>
        {
            var result = await spellsService.GetSpells();
            return result;
        });

        app.MapGet("/spellsGenerated", async ([FromKeyedServices("SpellsService")] ISpellsService spellsService) =>
        {
            var result = await spellsService.GetSpellsGenerated();
            return result;
        });

        app.MapGet("/makeSpells", ([FromKeyedServices("SpellsService")] ISpellsService spellsService) =>
        {
            spellsService.MakeSpells();
            return "success";
        });

        app.MapGet("/makeSpellsGenerated", ([FromKeyedServices("SpellsService")] ISpellsService spellsService) =>
        {
            spellsService.MakeSpellsGenerated();
            return "success";
        });
    }
}
