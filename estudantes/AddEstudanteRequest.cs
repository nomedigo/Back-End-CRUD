namespace ApiCrud.Estudantes;
// Declaração do namespace ApiCrud.Estudantes para organizar classes relacionadas aos estudantes
// Namespace é usado para agrupar e organizar classes e tipos relacionados.
public record AddEstudanteRequest(string Nome);
// Declaração de um record chamado AddEstudanteRequest, que representa uma estrutura de dados imutável.
// Records são introduzidos no C# 9.0 e são ideais para representar dados simples e imutáveis.
// Este record possui uma única propriedade pública chamada Nome, que é definida apenas na criação do objeto.