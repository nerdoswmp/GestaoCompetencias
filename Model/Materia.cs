using System;
using System.Collections.Generic;

namespace GestaoCompetencias.Models
{
    public partial class Materia
    {
        public Materia()
        {
            Competencia = new HashSet<Competencia>();
            MateriaProfessores = new HashSet<MateriaProfessor>();
        }

        public int Id { get; set; }
        public int? TurmaId { get; set; }
        public string Nome { get; set; } = null!;
        public string Descricao { get; set; } = null!;
        public DateTime DataDeInicio { get; set; }
        public DateTime DataDeFim { get; set; }

        public virtual Turma? Turma { get; set; }
        public virtual ICollection<Competencia> Competencia { get; set; }
        public virtual ICollection<MateriaProfessor> MateriaProfessores { get; set; }

        public int save()
        {
            int id = 0;
            using (var context = new DB_Gestao_CompetenciasContext())
            {
                context.Materias.Add(this);
                context.SaveChanges();
                id = this.Id;
            }
            return id;
        }

    }

}
