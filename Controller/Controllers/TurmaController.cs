using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GestaoCompetencias.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;

namespace GestaoCompetencias.Controller.Controllers;

[ApiController]
[Route("Turma")]
public class TurmaController
{
    [HttpPost]
    [Route("register")]
    public object registerTurma([FromBody] Turma turma)
    {
        var id = turma.save();
        return new { id = id};
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
