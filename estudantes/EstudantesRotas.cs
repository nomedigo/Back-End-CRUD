using ApiCrud.Data;// Importa o namespace ApiCrud.Data para acessar o contexto do banco de dados
using ApiCrud.estudantes; // Importa o namespace ApiCrud.estudantes para acessar a classe Estudante
using ApiCrud.Estudantes; // Importa o namespace ApiCrud.Estudantes para acessar a classe AddEstudanteRequest
using Microsoft.AspNetCore.Builder; // Importa o namespace Microsoft.AspNetCore.Builder para configurar o pipeline HTTP
using Microsoft.EntityFrameworkCore; // Importa o namespace Microsoft.EntityFrameworkCore para usar métodos de extensão do EF Core

namespace ApiCrud.Estudantes 
{
    // Declaração de uma classe estática EstudantesRotas no namespace ApiCrud.Estudantes
    public static class EstudantesRotas
    {
        // Método de extensão para adicionar rotas de estudantes à aplicação WebApplication
        public static void AddRotasEstudantes(this WebApplication app)
        {
            // Mapeia um grupo de rotas chamado "estudantes" usando o método MapGroup do WebApplication
            var rotasEstudantes = app.MapGroup("estudantes");

            // Define uma rota POST para adicionar um novo estudante
            rotasEstudantes.MapPost("", 
                async (AddEstudanteRequest request, AppDbContext context) => 
                {
                    // Verifica se já existe um estudante com o mesmo nome no banco de dados
                    var jaExiste = await context.Estudantes
                        .AnyAsync(estudante => estudante.Nome == request.Nome);

                    // Se já existe um estudante com o mesmo nome, retorna um resultado de conflito
                    if (jaExiste)
                        return Results.Conflict("Já existe!");
                    // Cria um novo objeto Estudante com o nome fornecido na requisição
                    var novoEstudante = new Estudante(request.Nome);
                    // Adiciona o novo estudante ao contexto do banco de dados
                    await context.Estudantes.AddAsync(novoEstudante);
                    // Salva as mudanças no banco de dado
                    await context.SaveChangesAsync();
                    // Retorna um resultado Ok com o novo estudante adicionado
                    return Results.Ok(novoEstudante);
                });
        }
    }
}
