using DTO;
using GestaoCompetencias.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Controller;

[ApiController]
[Route("aprendizcompetencia")]
public class AprendizCompetenciaController
{
    [HttpPost]
    [Route("register")]
    public void RegisterCompetenciaAprendiz([FromBody] AprendizCompetencia aprendizCompetencia)
    {
        Console.WriteLine("Entrou");
        aprendizCompetencia.save();
        return;
    }

    [HttpGet]
    [Route("get/{ApredizID}/{MateriaID}")]
    public List<AprendizCompetenciaDTO> Get(int ApredizID, int MateriaID)
    {
        var respose = AprendizCompetencia.TodasCompetenciasDeUmaMateria(ApredizID, MateriaID);
        return respose;
    }
}