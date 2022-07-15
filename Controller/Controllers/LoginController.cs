using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GestaoCompetencias.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using DTO;

namespace Controller.Controllers;


[ApiController]
[Route("Login")]
public class LoginController
{
    [HttpPost]
    [Route("register")]
    public int registerLogin([FromBody] Login login)
    {
        var id = login.save();

        if(id == 0)
        {
            return -1;
        }
        return id;
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

    [HttpPost]
    [Route("enter")]
    public object completeLogin([FromBody]Login login)
    {
        var user = login.VerifyExistence();
        // ! tem q verificar no front isso ae
        return user;
    }

    [HttpPut]
    [Route("updatepass")]
    public object changePassword([FromBody] LoginDTO login)
    {
        var user = Login.UpdatePassword(login);

        return user;
    }
}
