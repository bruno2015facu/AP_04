namespace Modelos;

public class Usuario
{
    public string Nome { get; private set; }
    private List<Compromisso> compromissos = new();

    public Usuario(string nome)
    {
        Nome = nome;
    }

    public void AdicionarCompromisso(Compromisso c)
    {
        if (c.DataHora <= DateTime.Now)
            throw new Exception("Compromisso deve ser no futuro.");

        compromissos.Add(c);
    }

    public IReadOnlyCollection<Compromisso> Compromissos => compromissos.AsReadOnly();
}