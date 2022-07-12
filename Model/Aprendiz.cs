using System;
using System.Collections.Generic;

namespace GestaoCompetencias.Models
{
    public partial class Aprendiz
    {
        public Aprendiz()
        {
            AprendizCompetencias = new HashSet<AprendizCompetencia>();
        }

        public int Id { get; set; }
        public string Nome { get; set; } = null!;
        public string Edv { get; set; } = null!;
        public int? LoginId { get; set; }
        public int? TurmaId { get; set; }

        public virtual Login? Login { get; set; }
        public virtual Turma? Turma { get; set; }
        public virtual ICollection<AprendizCompetencia> AprendizCompetencias { get; set; }
    }
}
