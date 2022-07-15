using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GestaoCompetencias.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using DTO;

namespace GestaoCompetencias.Controller.Controllers;

[ApiController]
[Route("Turma")]
public class TurmaController
{
    [HttpPost]
    [Route("register")]
    public object registerTurma([FromBody] TurmaDTO turma)
    {
        var Turma = new Turma(turma.Nome, turma.DataDeInicio, turma.DataDeFim);
        var id = Turma.save();
        var TurmaProfessor = new TurmaProfessor()
        {
            ProfessorId = turma.ProfessorId, 
            TurmaId = id
        };
        var idtp = TurmaProfessor.save();
        return new { id = idtp};
    }

    [HttpDelete]
    [Route("delete/{id}")]
    public string deleteTurma(int id)
    {
        Turma.delete(id);
        return "Deuboa";
    }

    [HttpGet]
    [Route("get/{id}")]
    public object getInformationTurma(int id)
    {
        Console.WriteLine(id);
        var turma = Turma.findId(id);
        return turma;
    }

    [HttpGet]
    [Route("get/all")]
    public List<Turma> getAllTurma()
    {
        var turma = Turma.findAll();
        return turma;
    }
}
