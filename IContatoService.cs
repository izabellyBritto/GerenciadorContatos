// IContatoService.cs - Interface para o serviço de contatos (ISP e DIP)
public interface IContatoService
{
    void AdicionarContato(string nome, string telefone, string email);
    void ListarContatos();
    void BuscarContato(string nome);
    void RemoverContato(string nome);
}

// Contato.cs - Modelo de dados que representa um contato (SRP)
public class Contato
{
    public string Nome { get; set; }
    public string Telefone { get; set; }
    public string Email { get; set; }

    public Contato(string nome, string telefone, string email)
    {
        Nome = nome;
        Telefone = telefone;
        Email = email;
    }
}
