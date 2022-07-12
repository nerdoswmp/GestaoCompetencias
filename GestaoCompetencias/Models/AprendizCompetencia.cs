using System;
using System.Collections.Generic;

namespace GestaoCompetencias.Models
{
    public partial class AprendizCompetencia
    {
        public int Id { get; set; }
        public int? AprendizId { get; set; }
        public int? CompetenciasId { get; set; }
        public bool? Status { get; set; }

        public virtual Aprendiz? Aprendiz { get; set; }
        public virtual Competencia? Competencias { get; set; }
    }
}
