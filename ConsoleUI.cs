public class ConsoleUI
{
    private readonly IContatoService contatoService;

    // DIP: Dependemos da abstração IContatoService, não da implementação concreta
    public ConsoleUI(IContatoService contatoService)
    {
        this.contatoService = contatoService;
    }

    public void ExibirMenu()
    {
        while (true)
        {
            Console.WriteLine("\n1. Adicionar Contato");
            Console.WriteLine("2. Listar Contatos");
            Console.WriteLine("3. Buscar Contato");
            Console.WriteLine("4. Remover Contato");
            Console.WriteLine("5. Sair");
            Console.Write("Escolha uma opção: ");
            string opcao = Console.ReadLine();

            switch (opcao)
            {
                case "1":
                    Console.Write("Nome: ");
                    string nome = Console.ReadLine();
                    Console.Write("Telefone: ");
                    string telefone = Console.ReadLine();
                    Console.Write("Email: ");
                    string email = Console.ReadLine();
                    contatoService.AdicionarContato(nome, telefone, email);
                    break;
                case "2":
                    contatoService.ListarContatos();
                    break;
                case "3":
                    Console.Write("Nome: ");
                    contatoService.BuscarContato(Console.ReadLine());
                    break;
                case "4":
                    Console.Write("Nome: ");
                    contatoService.RemoverContato(Console.ReadLine());
                    break;
                case "5":
                    return;
                default:
                    Console.WriteLine("Opção inválida!");
                    break;
            }
        }
    }
}
