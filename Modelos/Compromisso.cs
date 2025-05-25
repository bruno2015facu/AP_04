namespace Modelos;

public class Compromisso
{
    public DateTime DataHora { get; private set; }
    public string Descricao { get; private set; }
    public Usuario Usuario { get; private set; }
    public Local Local { get; private set; }
    public List<Participante> Participantes { get; private set; } = new();
    public List<Anotacao> Anotacoes { get; private set; } = new();

    public Compromisso(DateTime dataHora, string descricao, Usuario usuario, Local local)
    {
        if (string.IsNullOrWhiteSpace(descricao))
            throw new Exception("Descrição obrigatória.");

        if (dataHora <= DateTime.Now)
            throw new Exception("Data/hora deve ser no futuro.");

        DataHora = dataHora;
        Descricao = descricao;
        Usuario = usuario;
        Local = local;
    }

    public void AdicionarParticipante(Participante p)
    {
        Participantes.Add(p);
        p.AdicionarCompromisso(this);
    }

    public void AdicionarAnotacao(string texto)
    {
        Anotacoes.Add(new Anotacao(texto));
    }

    public override string ToString()
    {
        return $"{DataHora} - {Descricao} ({Local.Nome})";
    }
}