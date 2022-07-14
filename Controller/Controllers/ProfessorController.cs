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
    public int registerProfessor([FromBody] Professor professor)
    {
        var id = professor.save();
        return id;
    }
}
