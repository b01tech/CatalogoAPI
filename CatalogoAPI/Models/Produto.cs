namespace CatalogoAPI.Models;
public class Produto
{
    public long ProdutoId { get; set; }
    public string Nome { get; set; } = string.Empty;
    public string? Descricao { get; set; }
    public decimal Preco { get; set; }
    public float Estoque { get; set; }
    public bool Ativo { get; set; } = true;
    public string? UrlImagem { get; set; }
    public Categoria? Categoria { get; set; }
    public long CategoriaId { get; set; }
}
