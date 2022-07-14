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

        public static void delete(int id)
        {
            using (var context = new DB_Gestao_CompetenciasContext())
            {
                var professores = context.Professores.FirstOrDefault(i => i.Id == id);
                context.Professores.Remove(professores);
                context.SaveChanges();
            }
        }

        public static object findId(int id)
        {
            using (var context = new DB_Gestao_CompetenciasContext())
            {
                var Professor = context.Professores.FirstOrDefault(d => d.Id == id);
                return new
                {
                    Nome = Professor.Nome,
                    Identificador = Professor.Identificador,
                    Interno = Professor.Interno,
                    Adm = Professor.Adm
                };
            }
        }

        public static List<Professor> findAll()
        {
            using (var context = new DB_Gestao_CompetenciasContext())
            {
                List<Professor> listProfessor = new List<Professor>();
                var Professores = context.Professores;
                foreach (var professor in Professores)
                {
                    listProfessor.Add(professor);
                }
                return listProfessor;
            }
        }
    }
}
