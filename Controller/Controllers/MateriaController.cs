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
[Route("Materia")]
public class MateriaController
{
    [HttpPost]
    [Route("register")]
    public object registerMateria([FromBody] Materia materia)
    {
        var id = materia.save();
        return new { id = id };
    }
    
}
