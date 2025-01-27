using BusinessLogic.Users;
using BusinessLogicInterface.Clients;
using EntitiesInterface.Helpers.Communication;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Rewrite;
using System.Net;
using System;
using Entities.Users;
using EntitiesInterface.Users;
using Newtonsoft.Json;

namespace SysVentasAPI.Controllers.Clients
{
    /// <summary>
    /// AZ-475
    /// Author: Esteban Arias Sáenz
    /// Descripcion
    /// </summary>
    /// <param name="">Descripcion</param>
    /// <returns></returns>
    [ApiController]
    [Route("[controller]")]
    public class UsersController : ControllerBase
    {
        private readonly IUsersBL _UsersBL;

        public UsersController()
        {
            _UsersBL = new UsersBL();
        }

        [HttpGet]
        [Route("GetAll")]
        public IResponse GetAll(string filter = "")
        {
            return _UsersBL.GetAll(filter);
        }

        [HttpGet]
        public IResponse Get(int id)
        {
            return _UsersBL.Get(id);
        }

        [HttpPost]
        public IResponse Save([FromHeader] string token, [FromBody] string user)
        {
            return _UsersBL.Save(token, user);
        }

        [HttpPut]
        public IResponse Update(string client)
        {
            return _UsersBL.Update(client);
        }

        [HttpDelete]
        public IResponse Delete(int id)
        {
            return _UsersBL.Delete(id);
        }
    }
}
