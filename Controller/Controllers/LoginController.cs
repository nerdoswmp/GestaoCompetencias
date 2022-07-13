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
    [Route("delete/{id}")]
    public string deleteLogin(int id)
    {
        Login.delete(id);
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

    [HttpGet]
    [Route("get/all")]
    public List<Login> getAllLogin()
    {
        var login = Login.findAll();
        return login;
    }
}
