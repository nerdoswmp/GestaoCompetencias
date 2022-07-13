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
[Route("MateriaProfessor")]
public class MateriaProfessorController
{
    [HttpPost]
    [Route("register")]
    public string registerMateriaProfessor([FromBody] MateriaProfessor Mprofessor)
    {
        var id = Mprofessor.save();
        return "Deuboa";
    }
}
