namespace LYS.Locadora.Api.ViewModel;

public record MovieCreateViewModel(string Title,
    DateOnly ReleaseDate,
    string Genre,
    float Rating);