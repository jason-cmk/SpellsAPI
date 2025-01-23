using Microsoft.AspNetCore.Mvc;

namespace Spells;

public record Test(string Id);
public static class Endpoints
{
    public static void RegisterEndpoints(this WebApplication app)
    {
        app.MapGet("/", () => "alive");

        app.MapGet("/spells", async ([FromServices] ISpellsService spellsService) =>
        {
            var result = await spellsService.GetSpells();
            return result;
        });

        app.MapGet("/spellsGenerated", async ([FromServices] ISpellsService spellsService) =>
        {
            var result = await spellsService.GetSpellsGenerated();
            return result;
        });

        app.MapGet("/makeSpells", ([FromServices] ISpellsService spellsService) =>
        {
            spellsService.MakeSpells();
            return "success";
        });

        app.MapGet("/makeSpellsGenerated", ([FromServices] ISpellsService spellsService) =>
        {
            spellsService.MakeSpellsGenerated();
            return "success";
        });
    }
}
