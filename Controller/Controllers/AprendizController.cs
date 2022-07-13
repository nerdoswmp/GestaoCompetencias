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
[Route("aprendiz")]
public class AprendizController{

    [HttpPost]
    [Route("register")]
    public string RegisterAprendiz([FromBody] Aprendiz _aprendiz){
       var item =  _aprendiz.save();
       return "Deu Boas";
    }

    [HttpDelete]
    [Route("delete/{AprendizID}")]
    public string DeleteAprendiz (int AprendizID){

        var teste =  Aprendiz.delete(AprendizID);
        return "Boa";
    }

    [HttpGet]
    [Route("GetAprendiz/{AprendizID}")]
    public Aprendiz GetAprendiz( int AprendizID){
        var response = Aprendiz.GetAprendiz(AprendizID);
        return response;
    }
}