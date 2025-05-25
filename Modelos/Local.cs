namespace Modelos;

public class Local
{
    public string Nome { get; private set; }
    public int CapacidadeMaxima { get; private set; }

    public Local(string nome, int capacidade)
    {
        Nome = nome;
        CapacidadeMaxima = capacidade;
    }

    public bool ValidarCapacidade(int quantidade)
    {
        return quantidade <= CapacidadeMaxima;
    }
}