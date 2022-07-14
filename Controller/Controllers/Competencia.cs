using Microsoft.AspNetCore.Mvc;
using GestaoCompetencias.Models;

namespace Controller;
[ApiController]
[Route("Competencia")]
public class CompetenciaController{

    [HttpPost]
    [Route("register")]
    public  void register([FromBody] Competencia _Competencia){
        _Competencia.save();
    }
}