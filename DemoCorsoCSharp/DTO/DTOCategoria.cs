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

public class DTOCreaProdotto
{
    public int Id { get; set; }
    public int IdFornitore { get; set; }
    public string? Nome { get; set;}
    public decimal? PrezzoUnitario { get; set; }
    public short? ScortaMagazzino { get; set; }

}

public class DTOCreaCategoria
{
    public int Id { get; set; }

    public string? Nome { get; set; }

    public string? Descrizione { get; set; }
    public IEnumerable<DTOCreaProdotto>? Prodotti { get; set; }
}