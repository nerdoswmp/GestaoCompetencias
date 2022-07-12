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
    }
}
