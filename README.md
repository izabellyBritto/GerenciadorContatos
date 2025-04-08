# 📒 Gerenciador de Contatos  

Este projeto é um **sistema simples** de gerenciamento de contatos em **C#**, seguindo os princípios **SOLID** e utilizando **injeção de dependência** para maior flexibilidade. O sistema roda **totalmente em memória** e interage com o usuário por meio do **console**.  

---

## 📌 Funcionalidades  

✅ Adicionar contatos  
✅ Listar contatos  
✅ Buscar contatos pelo nome  
✅ Remover contatos  

---

## 🛠 Aplicação dos Princípios **SOLID**  

### **✔ S – Princípio da Responsabilidade Única (SRP)**  
Cada classe tem **uma única responsabilidade**, facilitando manutenção e extensibilidade.  
📌 **Exemplo no código:**  

- `Contato.cs` → Apenas define os dados do contato.  
- `ContatoService.cs` → Apenas gerencia os contatos (CRUD).  
- `ConsoleUI.cs` → Apenas interage com o usuário.  

```csharp
public class Contato  
{  
    public string Nome { get; set; }  
    public string Telefone { get; set; }  
    public string Email { get; set; }  
}
```
```csharp
public class ContatoService : IContatoService  
{  
    private readonly List<Contato> contatos = new();  

    public void AdicionarContato(string nome, string telefone, string email)  
    {  
        contatos.Add(new Contato(nome, telefone, email));  
        Console.WriteLine("Contato adicionado com sucesso!");  
    }  
}
```
Cada classe possui **apenas uma responsabilidade**, evitando código misturado.  

---

### **✔️ O – Princípio do Aberto/Fechado (OCP)**  
O sistema pode ser **expandido sem modificar o código existente**.  
📌 **Exemplo no código:**  

Podemos adicionar outra forma de armazenar contatos sem alterar `ContatoService` diretamente:  

```csharp
public class ContatoServiceBanco : IContatoService  
{  
    public void AdicionarContato(string nome, string telefone, string email)  
    {  
    }  
}
```
Isso permite **novas funcionalidades** sem alterar código existente!  

---

### **✔️ L – Princípio da Substituição de Liskov (LSP)**  
Qualquer implementação de `IContatoService` pode substituir outra sem impacto no código.  
📌 **Exemplo no código:**  

```csharp
public interface IContatoService  
{  
    void AdicionarContato(string nome, string telefone, string email);  
    void ListarContatos();  
    void BuscarContato(string nome);  
    void RemoverContato(string nome);  
}
```
Se `ContatoServiceBanco` implementar `IContatoService`, podemos trocar `ContatoService` sem quebrar nada.  

---

### **✔️ I – Princípio da Segregação de Interfaces (ISP)**  
Interfaces devem ser **específicas e não forçar classes a implementar métodos desnecessários**.  
📌 **Exemplo no código:**  

Aqui, `IContatoService` contém **apenas os métodos necessários** para gerenciamento de contatos. Se tivéssemos mais serviços (ex: notificações), poderíamos separar as interfaces:  

```csharp
public interface IContatoService  
{  
    void AdicionarContato(string nome, string telefone, string email);  
    void ListarContatos();  
}
public interface INotificacaoService  
{  
    void EnviarNotificacao(string mensagem);  
}
```
Isso evita que classes implementem **métodos desnecessários**.  

---

### **✔️ D – Princípio da Inversão de Dependência (DIP)**  
As classes **dependem de abstrações (`IContatoService`) e não de implementações concretas**.  
📌 **Exemplo no código:**  

```csharp
public class ConsoleUI  
{  
    private readonly IContatoService contatoService;  

    public ConsoleUI(IContatoService contatoService)  
    {  
        this.contatoService = contatoService;  
    }  
}
```
Aqui, `ConsoleUI` **não sabe** qual implementação de `IContatoService` está sendo usada.  

No `Program.cs`, podemos trocar `ContatoService` sem modificar `ConsoleUI`:  

```csharp
IContatoService contatoService = new ContatoService();  
ConsoleUI ui = new ConsoleUI(contatoService);  
ui.ExibirMenu();
```
---
