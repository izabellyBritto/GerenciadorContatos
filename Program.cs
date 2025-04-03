class Program
{
    static void Main()
    {
        IContatoService contatoService = new ContatoService(); // DIP: Criamos a implementação separadamente
        ConsoleUI ui = new ConsoleUI(contatoService); // Injeção de dependência
        ui.ExibirMenu();
    }
}
