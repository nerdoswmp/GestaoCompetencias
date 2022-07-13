using System;
using System.Collections.Generic;

namespace GestaoCompetencias.Models
{
    public partial class Login
    {
        public Login()
        {
            Aprendizes = new HashSet<Aprendiz>();
            Professores = new HashSet<Professor>();
        }

        public int Id { get; set; }
        public string Usuario { get; set; } = null!;
        public string Senha { get; set; } = null!;

        public virtual ICollection<Aprendiz> Aprendizes { get; set; }
        public virtual ICollection<Professor> Professores { get; set; }

        public int save()
        {
            int id = 0;
            using (var context = new DB_Gestao_CompetenciasContext())
            {
                context.Logins.Add(this);
                context.SaveChanges();
                id = this.Id;
            }
            return id;
        }

        public void delete()
        {            
            using(var context = new DB_Gestao_CompetenciasContext())
            {
                var logins = context.Logins.FirstOrDefault(i=> i.Id == this.Id);
                context.Logins.Remove(logins);
                context.SaveChanges();                
            }            
        }
    }
}
