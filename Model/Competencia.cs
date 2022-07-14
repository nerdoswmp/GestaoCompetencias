using System;
using System.Collections.Generic;

namespace GestaoCompetencias.Models
{
    public partial class Competencia
    {
        public Competencia()
        {
            AprendizCompetencias = new HashSet<AprendizCompetencia>();
        }

        public int Id { get; set; }
        public int? MateriaId { get; set; }
        public string Descricao { get; set; } = null!;

        public virtual Materia? Materia { get; set; }
        public virtual ICollection<AprendizCompetencia> AprendizCompetencias { get; set; }

        public void save(){
            using var db =  new DB_Gestao_CompetenciasContext();
            db.Competencias.Add(this);
            db.SaveChanges();
            return;
        }
    }
}
