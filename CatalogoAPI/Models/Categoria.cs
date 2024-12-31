namespace CatalogoAPI.Models;
public class Categoria
{
    public Categoria()
    {
        Produtos = new List<Produto>();
    }
    public long CategoriaId { get; set; }
    public string  Nome { get; set; } = string.Empty;
    public string? UrlImagem { get; set; }

    public IList<Produto>? Produtos { get; set; }
}
