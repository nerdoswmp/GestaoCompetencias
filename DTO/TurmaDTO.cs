namespace DTO
{
    public class TurmaDTO
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public DateTime DataDeInicio { get; set; }
        public DateTime DataDeFim { get; set; }
        public int? ProfessorId { get; set; } 
    }
}
