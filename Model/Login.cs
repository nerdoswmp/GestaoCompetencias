using DTO;
using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

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

        public Login(string usuario, string senha)
        {
            Usuario = usuario;
            Senha = senha;
        }

        public int save()
        {
            int id = 0;
            using (var context = new DB_Gestao_CompetenciasContext())
            {
                bool alreadyexists = context.Logins.Any(l => l.Usuario == this.Usuario);

                if (!alreadyexists)
                {
                    context.Logins.Add(this);
                    context.SaveChanges();
                    id = this.Id;
                }
                else
                {
                    return 0;
                }

            }
            return id;
        }

        public static void delete(int id)
        {            
            using(var context = new DB_Gestao_CompetenciasContext())
            {
                    var logins = context.Logins.FirstOrDefault(i=> i.Id == id);
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

        public static List<Login> findAll()
        {
            using(var context = new DB_Gestao_CompetenciasContext())
            {
                List<Login> listLogin = new List<Login>();
                var Logins = context.Logins;
                foreach(var login in Logins)
                {
                    listLogin.Add(login);
                }
                return listLogin;
            }
        }

        public object VerifyExistence()
        {
            using var context = new DB_Gestao_CompetenciasContext();

            try
            {
                var login = context.Logins.Where(l => l.Senha == this.Senha && l.Usuario == this.Usuario).FirstOrDefault();

                if (login != null)
                {
                    var teacher = context.Professores.Where(p => p.Login.Id == login.Id).FirstOrDefault();
                    var student = context.Aprendizes.Include(s => s.Turma).Where(a => a.Login.Id == login.Id).FirstOrDefault();

                    if (teacher != null && student == null)
                    {
                        return new ProfessorDTO()
                        {
                            Id = teacher.Id,
                            Nome = teacher.Nome,
                            Identificador = teacher.Identificador,
                            LoginId = teacher.Login.Id,
                            Interno = teacher.Interno,
                            Adm = teacher.Adm,
                            State = false
                        };
                    }
                    else if (student != null && teacher == null)
                    {
                        return new AprendizDTO()
                        {
                            Id = student.Id,
                            Nome = student.Nome,
                            EDV = student.Edv,
                            LoginId = student.Login.Id,
                            turmaDTO = new TurmaDTO() {
                                Id = student.Turma.Id,
                                Nome = student.Turma.Nome,
                                DataDeInicio = student.Turma.DataDeInicio,
                                DataDeFim = student.Turma.DataDeFim
                            },
                            State = true
                        };
                    }
                    else
                    {
                        throw new Exception("Login não existente");
                    }
                }
                else
                {
                    throw new Exception("Login não existente");
                }
            }
            catch
            {
                throw new Exception("Login não existente");
            }


        }

        public static object UpdatePassword(LoginDTO log)
        {
            using var context = new DB_Gestao_CompetenciasContext();

            try
            {
                var login = context.Logins.Where(l => l.Usuario == log.Usuario).FirstOrDefault();

                if (login != null)
                {
                    login.Senha = log.Senha;

                    try
                    {
                        context.Update(login);
                        context.SaveChanges();
                        return log;
                    }
                    catch
                    {
                        throw new Exception();
                    }
                }
                else
                {
                    throw new NullReferenceException();
                }
            }
            catch
            {
                throw new Exception();
            }


        }
    }
}
