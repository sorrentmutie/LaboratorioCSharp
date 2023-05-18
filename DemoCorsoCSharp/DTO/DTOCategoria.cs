namespace DemoCorsoCSharp.DTO;

public class DTOCategoria
{
    public int Id { get; set; }
    public string? Nome { get; set; }
    public int NumeroProdotti { get; set; }
    public IEnumerable<DTOProdotto>? Prodotti { get; set; }
}

public class DTOProdotto
{
    public int Id { get; set; }
    public string? Nome { get; set;}
    public string? Fornitore { get; set; }
}
