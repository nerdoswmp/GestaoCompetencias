using Microsoft.AspNetCore.Mvc;
using GestaoCompetencias.Models;
using DTO;

namespace Controller;
[ApiController]
[Route("Competencia")]
public class CompetenciaController{

    [HttpPost]
    [Route("register")]
    public  void register([FromBody] Competencia _Competencia){
        _Competencia.save();
    }

    [HttpGet]
    [Route("get/materia/{MateriaID}")]
    public List<CompetenciaDTO>  GetCompetenciasFromMaterias(int MateriaID){

        var respose = Competencia.GetCompetenciasFromMateria(MateriaID);
        return respose;
    }
}