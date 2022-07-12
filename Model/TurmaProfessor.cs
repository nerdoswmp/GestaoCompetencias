using System;
using System.Collections.Generic;

namespace GestaoCompetencias.Models
{
    public partial class TurmaProfessor
    {
        public int Id { get; set; }
        public int? ProfessorId { get; set; }
        public int? TurmaId { get; set; }

        public virtual Professor? Professor { get; set; }
        public virtual Turma? Turma { get; set; }
    }
}
