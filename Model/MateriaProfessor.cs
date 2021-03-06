using System;
using System.Collections.Generic;

namespace GestaoCompetencias.Models
{
    public partial class MateriaProfessor
    {
        public int Id { get; set; }
        public int? ProfessorId { get; set; }
        public int? MateriaId { get; set; }

        public virtual Materia? Materia { get; set; }
        public virtual Professor? Professor { get; set; }


        public int save()
        {
            int id = 0;
            using (var context = new DB_Gestao_CompetenciasContext())
            {
                context.MateriaProfessores.Add(this);
                context.SaveChanges();
                id = this.Id;
            }
            return id;
        }
    }
}
