namespace Modelos;

public class Participante
{
    public string Nome { get; private set; }
    public List<Compromisso> Compromissos { get; private set; } = new();

    public Participante(string nome)
    {
        Nome = nome;
    }

    public void AdicionarCompromisso(Compromisso c)
    {
        if (!Compromissos.Contains(c))
            Compromissos.Add(c);
    }
}