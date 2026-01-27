namespace Locadora.Application.DTOs;

public sealed record VeiculoDto(
    Guid Id,
    string Placa,
    string Modelo,
    int Ano,
    string Categoria,
    decimal ValorDiaria,
    bool Ativo,
    bool Disponivel
);
