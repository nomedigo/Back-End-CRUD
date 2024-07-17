// Importa o namespace que contém a classe 'Estudante'
using ApiCrud.estudantes;
// Importa o namespace para Entity Framework Core, que é usado para acessar o banco de dados
using Microsoft.EntityFrameworkCore;
// Importa o namespace para classes de banco de dados comuns
using System.Data.Common;

// Define um namespace para organizar classes relacionadas a dados
namespace ApiCrud.Data
{
    // Define a classe 'AppDbContext' que herda de 'DbContext', fornecendo funcionalidades de Entity Framework Core
    public class AppDbContext : DbContext 
    {
        // Define uma propriedade do tipo 'DbSet<Estudante>' que representa a coleção de 'Estudante' no banco de dados
        public DbSet<Estudante> Estudantes { get; set; }

        // Sobrescreve o método 'OnConfiguring' para configurar o contexto do banco de dados
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // Configura o uso do banco de dados SQLite com a string de conexão especificada
            optionsBuilder.UseSqlite(connectionString: "Data Source=Banco.sqlite");
            // Configura o log para registrar informações no console com o nível de log 'Information'
            optionsBuilder.LogTo(Console.WriteLine, LogLevel.Information);
            // Chama o método base para garantir que a configuração padrão do 'DbContext' seja aplicada
            base.OnConfiguring(optionsBuilder);
        }

    }
}
