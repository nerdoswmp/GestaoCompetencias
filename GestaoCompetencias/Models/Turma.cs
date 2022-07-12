﻿using System;
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
    }
}
