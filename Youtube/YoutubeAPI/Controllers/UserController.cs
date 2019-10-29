using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using YoutubeAPI.App_Start;
using YoutubeAPI.Attributes;
using YoutubeAPI.Models;
using YoutubeEntity.Class;
using YoutubeService.Interface;

namespace YoutubeAPI.Controllers
{
    [RoutePrefix("api/Users")]
    public class UserController : ApiController
    {

        IUserService userService;

        public UserController()
        {
            this.userService = Injector.Container.Resolve<IUserService>();
        }

        [Route("Get/{id}")]
        [BasicAuthentication]
        public IHttpActionResult Get([FromUri]string id)
        {
            User user = userService.GetUserByClientId(id);
            UserModel um = new UserModel();

            um.Name = user.Name;
            um.Address = user.Address;
            um.Image = user.Image;
            um.Email = user.Email;

            return Ok(um);   
        }



    }
}
