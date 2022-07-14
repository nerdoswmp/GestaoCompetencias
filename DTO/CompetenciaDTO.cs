namespace DTO;

public class CompetenciaDTO
{

    public int Id { get; set; }
    public int? TurmaId { get; set; }
    public string Nome { get; set; } = null!;
    public string Descricao { get; set; } = null!;
    public DateTime DataDeInicio { get; set; }
    public DateTime DataDeFim { get; set; }

}