using System;
using System.Collections.Generic;

namespace GestaoCompetencias.Models
{
    public partial class Turma
    {
        public Turma()
        {
            Aprendizes = new HashSet<Aprendiz>();
            Materias = new HashSet<Materia>();
            TurmaProfessores = new HashSet<TurmaProfessor>();
        }

        public int Id { get; set; }
        public string Nome { get; set; } = null!;
        public DateTime DataDeInicio { get; set; }
        public DateTime DataDeFim { get; set; }

        public virtual ICollection<Aprendiz> Aprendizes { get; set; }
        public virtual ICollection<Materia> Materias { get; set; }
        public virtual ICollection<TurmaProfessor> TurmaProfessores { get; set; }

        public int save()
        {
            int id = 0;
            using (var context = new DB_Gestao_CompetenciasContext())
            {
                context.Turmas.Add(this);
                context.SaveChanges();
                id = this.Id;
            }
            return id;
        }

        public static void delete(int id)
        {
            using (var context = new DB_Gestao_CompetenciasContext())
            {                
                var materias = context.Materias.Where(i => i.TurmaId == id);
                foreach(var materia in materias)
                {
                    Materia.delete(materia.Id);
                }
                context.SaveChanges();
            }
            using(var context = new DB_Gestao_CompetenciasContext())
            {
                var turmas = context.Turmas.FirstOrDefault(i => i.Id == id);
                context.Turmas.Remove(turmas);
                context.SaveChanges();
            }
        }
        public static List<Turma> findAll()
        {
            using (var context = new DB_Gestao_CompetenciasContext())
            {
                List<Turma> listTurma = new List<Turma>();
                var turmas = context.Turmas;
                foreach (var turma in turmas)
                {
                    listTurma.Add(turma);
                }
                return listTurma;
            }
        }
        public static object findId(int id)
        {
            using (var context = new DB_Gestao_CompetenciasContext())
            {                
                var Turma = context.Turmas.FirstOrDefault(t => t.Id == id);
                return new
                {
                    Nome = Turma.Nome,                    
                    DataDeInicio = Turma.DataDeInicio,
                    DataDeFim = Turma.DataDeFim,                    
                };
            }
        }
    }
}
