namespace LYS.Locadora.Api.ViewModel;

public record MovieViewModel(int Id, 
    string Title,
    DateOnly ReleaseDate,
    string Genre,
    float Rating);