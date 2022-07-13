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

        public static void delete(int id)
        {
            using (var context = new DB_Gestao_CompetenciasContext())
            {
                var materias = context.Materias.FirstOrDefault(i => i.Id == id);
                var mProfessor = context.MateriaProfessores.Where(i => i.MateriaId == id);
                foreach(var materia in mProfessor)
                {
                    context.MateriaProfessores.Remove(materia);
                }                
                context.Materias.Remove(materias);
                context.SaveChanges();
            }
        }
        public static List<Materia> findAll()
        {
            using (var context = new DB_Gestao_CompetenciasContext())
            {
                List<Materia> listMateria = new List<Materia>();
                var materias = context.Materias;
                foreach (var materia in materias)
                {
                    listMateria.Add(materia);
                }
                return listMateria;
            }
        }
        public static object findId(int id)
        {
            using (var context = new DB_Gestao_CompetenciasContext())
            {
                var Materia = context.Materias.FirstOrDefault(d => d.Id == id);
                var Turma = context.Turmas.FirstOrDefault(t => t.Id == Materia.TurmaId);
                return new
                {
                    Nome = Materia.Nome,
                    Descricao = Materia.Descricao,
                    DataDeInicio = Materia.DataDeInicio,
                    DataDeFim = Materia.DataDeFim,
                    TurmaNome = Turma.Nome
                };
            }
        }
    }

}
