namespace DTO
{
    public class AprendizDTO
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string EDV { get; set; }
        public int LoginId { get; set; }
        public TurmaDTO turmaDTO { get; set; }
    }
}
