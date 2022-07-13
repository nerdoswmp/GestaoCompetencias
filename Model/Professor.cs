using System;
using System.Collections.Generic;

namespace GestaoCompetencias.Models
{
    public partial class Professor
    {
        public Professor()
        {
            MateriaProfessores = new HashSet<MateriaProfessor>();
            TurmaProfessores = new HashSet<TurmaProfessor>();
        }

        public int Id { get; set; }
        public string Nome { get; set; } = null!;
        public string Identificador { get; set; } = null!;
        public int LoginId { get; set; }
        public bool Interno { get; set; }
        public bool Adm { get; set; }

        public virtual Login Login { get; set; }
        public virtual ICollection<MateriaProfessor> MateriaProfessores { get; set; }
        public virtual ICollection<TurmaProfessor> TurmaProfessores { get; set; }


        public int save()
        {
            int id = 0;
            using (var context = new DB_Gestao_CompetenciasContext())
            {
                context.Professores.Add(this);
                context.SaveChanges();
                id = this.Id;
            }
            return id;
        }

    }
}
