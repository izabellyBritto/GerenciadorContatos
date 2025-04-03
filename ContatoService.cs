public class ContatoService : IContatoService
{
    private readonly List<Contato> contatos = new();

    // Adiciona um contato (SRP: única responsabilidade de gerenciar contatos)
    public void AdicionarContato(string nome, string telefone, string email)
    {
        contatos.Add(new Contato(nome, telefone, email));
        Console.WriteLine("Contato adicionado com sucesso!");
    }

    // Lista todos os contatos armazenados em memória (SRP)
    public void ListarContatos()
    {
        if (contatos.Count == 0)
        {
            Console.WriteLine("Nenhum contato cadastrado.");
            return;
        }

        foreach (var contato in contatos)
        {
            Console.WriteLine($"Nome: {contato.Nome}, Telefone: {contato.Telefone}, Email: {contato.Email}");
        }
    }

    // Busca um contato pelo nome (SRP)
    public void BuscarContato(string nome)
    {
        var contato = contatos.FirstOrDefault(c => c.Nome.Equals(nome, StringComparison.OrdinalIgnoreCase));
        if (contato != null)
        {
            Console.WriteLine($"Nome: {contato.Nome}, Telefone: {contato.Telefone}, Email: {contato.Email}");
        }
        else
        {
            Console.WriteLine("Contato não encontrado.");
        }
    }

    // Remove um contato pelo nome (SRP)
    public void RemoverContato(string nome)
    {
        var contato = contatos.FirstOrDefault(c => c.Nome.Equals(nome, StringComparison.OrdinalIgnoreCase));
        if (contato != null)
        {
            contatos.Remove(contato);
            Console.WriteLine("Contato removido com sucesso!");
        }
        else
        {
            Console.WriteLine("Contato não encontrado.");
        }
    }
}
