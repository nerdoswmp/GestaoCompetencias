using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using DTO;

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

        public void save()
        {
            Console.WriteLine("PAssou daq");
            using var db = new DB_Gestao_CompetenciasContext();
            db.AprendizCompetencias.Add(this);
            db.SaveChanges();
            return;
        }

        public static List<AprendizCompetenciaDTO> TodasCompetenciasDeUmaMateria(int AprendizID, int MateriaID)
        {
            using var db = new DB_Gestao_CompetenciasContext();
            var query = db.Competencias.Where(q => q.MateriaId == MateriaID).Join(db.AprendizCompetencias.Where(q => q.AprendizId == AprendizID), c => c.Id, apc => apc.CompetenciasId, (c, apc) => new
            {
                ID = apc.Id,
                Descricao = c.Descricao,
                Status = apc.Status,
                AprendizId =  apc.AprendizId,
                CompetenciaID = apc.CompetenciasId,
                MateriaID = c.MateriaId
                
            });
            var respose =  new List<AprendizCompetenciaDTO>();
            foreach (var item in query)
            {
                var element =  new AprendizCompetenciaDTO();
                element.AprendizId = item.AprendizId;
                element.CompetenciasId = item.CompetenciaID;
                element.MateriaID =  item.MateriaID;
                element.Status = item.Status;
                element.Id = item.ID;

                respose.Add(element);
            }
            return respose;
        }
    }
}
