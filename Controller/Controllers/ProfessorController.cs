using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GestaoCompetencias.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;

namespace Controller.Controllers;

[ApiController]
[Route("Professor")]
public class ProfessorController
{
    [HttpPost]
    [Route("register")]
    public string registerProfessor([FromBody] Professor professor)
    {
        var id = professor.save();
        return "Deuboa";
    }

    [HttpDelete]
    [Route("delete/{id}")]
    public string deleteProfessor(int id)
    {
        Professor.delete(id);
        return "Deuboa";
    }

    [HttpGet]
    [Route("get/{id}")]
    public object getInformationProfessor(int id)
    {
        Console.WriteLine(id);
        var professor = Professor.findId(id);
        return professor;
    }

    [HttpGet]
    [Route("get/all")]
    public List<Professor> getAllProfessor()
    {
        var professor = Professor.findAll();
        return professor;
    }

}
