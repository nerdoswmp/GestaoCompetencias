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
[Route("Login")]
public class LoginController
{
    [HttpPost]
    [Route("register")]
    public string registerLogin([FromBody] Login login)
    {
        var id = login.save();
        return "Deuboa";
    }

    [HttpDelete]
    [Route("delete")]
    public string deleteLogin([FromBody] Login login)
    {
        login.delete();
        return "Deuboa";
    }

    [HttpGet]
    [Route("get/{id}")]
    public object getInformationLogin(int id)
    {
        Console.WriteLine(id);
        var login = Login.findId(id);
        return login;
    }

    [HttpPost]
    [Route("enter")]
    public object completeLogin([FromBody]Login login)
    {
        var user = login.VerifyExistence();

        return user;
    }
}
