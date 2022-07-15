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

        public int save()
        {
            int id = 0;
            using (var context = new DB_Gestao_CompetenciasContext())
            {
                context.TurmaProfessores.Add(this);
                context.SaveChanges();
                id = this.Id;
            }
            return id;
        }
    }
}
