using System;
using System.Collections.Generic;

namespace GestaoCompetencias.Models
{
    public partial class Aprendiz
    {
        public Aprendiz()
        {
            AprendizCompetencias = new HashSet<AprendizCompetencia>();
        }
        public int Id { get; set; }
        public string Nome { get; set; } = null!;
        public string Edv { get; set; } = null!;
        public int LoginId { get; set; }
        public int? TurmaId { get; set; }
        public virtual Login? Login { get; set; }
        public virtual Turma? Turma { get; set; }
        public virtual ICollection<AprendizCompetencia> AprendizCompetencias { get; set; }

        public int save(){
            int id = 0;
            using(var db = new DB_Gestao_CompetenciasContext()){
                db.Aprendizes.Add(this);
                db.SaveChanges();
                id = this.Id;

            }
            return id;
        }

        public static string delete(int AprendizID){
            using var db = new DB_Gestao_CompetenciasContext();
            var aprendiz = db.Aprendizes.FirstOrDefault( q => q.Id == AprendizID);
            int loginid = aprendiz.LoginId;
            db.Aprendizes.Remove(aprendiz);
            db.SaveChanges();
            Login.delete(loginid);
            return "boa";
        }

        public static Aprendiz GetAprendiz(int AprendizID){
            using var db = new DB_Gestao_CompetenciasContext();

            var aprendiz = db.Aprendizes.FirstOrDefault(q => q.Id == AprendizID);
            return aprendiz;
        }

    }
}
