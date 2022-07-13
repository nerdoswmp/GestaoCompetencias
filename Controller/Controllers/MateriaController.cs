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

    [HttpDelete]
    [Route("delete/{id}")]
    public string deleteMateria(int id)
    {
        Materia.delete(id);
        return "Deuboa";
    }

    [HttpGet]
    [Route("get/{id}")]
    public object getInformationMateria(int id)
    {
        Console.WriteLine(id);
        var materia = Materia.findId(id);
        return materia;
    }

    [HttpGet]
    [Route("get/all")]
    public List<Materia> getAllMateria()
    {
        var materia = Materia.findAll();
        return materia;
    }
}
