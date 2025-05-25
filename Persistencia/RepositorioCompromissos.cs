using Modelos;
using System.Text.Json;

namespace Persistencia;

public class RepositorioCompromissos
{
    private const string CaminhoArquivo = "agenda.json";

    public static void Salvar(List<Compromisso> compromissos)
    {
        var json = JsonSerializer.Serialize(compromissos, new JsonSerializerOptions
        {
            WriteIndented = true
        });
        File.WriteAllText(CaminhoArquivo, json);
    }

    public static List<Compromisso> Carregar()
    {
        if (!File.Exists(CaminhoArquivo)) return new List<Compromisso>();

        var json = File.ReadAllText(CaminhoArquivo);
        return JsonSerializer.Deserialize<List<Compromisso>>(json) ?? new List<Compromisso>();
    }
}