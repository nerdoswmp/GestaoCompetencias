using System;
using System.Collections.Generic;
using DTO;
using Microsoft.EntityFrameworkCore;

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

        public static  List<CompetenciaDTO> GetCompetenciasFromMateria(int _MateriaID){

            using var db =  new DB_Gestao_CompetenciasContext();
            var query = db.Competencias.Where(q=> q.MateriaId == _MateriaID).ToList();
            var respose = new List<CompetenciaDTO>();
            foreach (var item in query)
            {
                var element =  new CompetenciaDTO();
                element.Descricao = item.Descricao;
                element.MateriaID = item.MateriaId;
                element.Id = item.Id;
                respose.Add(element);
            }
            
            return respose;
        }
    }
}
