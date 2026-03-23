namespace LYS.Locadora.Api.ViewModel;

public record MoviewUpdateViewModel(int Id, 
    string Title,
    DateOnly ReleaseDate,
    string Genre,
    float Rating,
    string ImageUrl);