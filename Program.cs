using Modelos;
using Persistencia;

Console.Write("Informe seu nome: ");
var nomeUsuario = Console.ReadLine();
var usuario = new Usuario(nomeUsuario);

var compromissos = RepositorioCompromissos.Carregar();

int opcao;
do
{
    Console.WriteLine("\n1 - Adicionar compromisso");
    Console.WriteLine("2 - Listar compromissos");
    Console.WriteLine("0 - Sair");
    Console.Write("Opção: ");
    opcao = int.Parse(Console.ReadLine());

    switch (opcao)
    {
        case 1:
            Console.Write("Data (yyyy-MM-dd): ");
            var data = DateTime.Parse(Console.ReadLine());

            Console.Write("Hora (HH:mm): ");
            var hora = TimeSpan.Parse(Console.ReadLine());
            var dataHora = data + hora;

            Console.Write("Descrição: ");
            var desc = Console.ReadLine();

            Console.Write("Local: ");
            var localNome = Console.ReadLine();

            Console.Write("Capacidade: ");
            var capacidade = int.Parse(Console.ReadLine());

            var local = new Local(localNome, capacidade);
            var compromisso = new Compromisso(dataHora, desc, usuario, local);

            usuario.AdicionarCompromisso(compromisso);
            compromissos.Add(compromisso);
            RepositorioCompromissos.Salvar(compromissos);

            Console.WriteLine("Compromisso adicionado!");
            break;

        case 2:
            foreach (var c in usuario.Compromissos)
                Console.WriteLine(c);
            break;
    }
} while (opcao != 0);

Console.WriteLine("Fim.");