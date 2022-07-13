﻿using System;
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

        public static void delete(Login login)
        {            
            using(var context = new DB_Gestao_CompetenciasContext())
            {
                var logins = context.Logins.FirstOrDefault(i=> i.Id == login.Id);
                context.Logins.Remove(logins);
                context.SaveChanges();                
            }            
        }

        public static object findId(int id)
        {
            using(var context = new DB_Gestao_CompetenciasContext())
            {
                var Login = context.Logins.FirstOrDefault(d => d.Id == id);
                return new
                {
                    Usuario = Login.Usuario,
                    Senha = Login.Senha
                };
            }
        }
    }
}