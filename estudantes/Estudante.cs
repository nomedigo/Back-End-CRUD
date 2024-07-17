namespace ApiCrud.estudantes;

// Declaração da classe Estudante no namespace ApiCrud.estudantes
public class Estudante
{
    // Propriedade para armazenar o ID único do estudante
    public Guid id { get; init; }

    // Propriedade para armazenar o nome do estudante (só pode ser definido no construtor)
    public string Nome { get; private set; }

    // Propriedade para armazenar o status de ativação do estudante (só pode ser definido no construtor)
    public bool Ativo { get; private set; } 

    // Construtor da classe Estudante, recebe o nome do estudante como parâmetro
    public Estudante(string nome)
    {
        // Atribui o nome recebido como parâmetro à propriedade Nome
        Nome = nome;
        // Gera um novo GUID para o ID do estudante
        id = Guid.NewGuid();
        // Define o status Ativo como true por padrão ao criar um novo estudante
        Ativo = true;
    }
}
