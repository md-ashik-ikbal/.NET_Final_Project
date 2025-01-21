using BLL.DTOs;
using BLL.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Final_Proj.Controllers
{
    public class UserController : ApiController
    {
        readonly UserService userService = new UserService();

        [HttpPost]
        [Route("user/create")]
        public HttpResponseMessage Create(CreateUserDTO createUser)
        {
            var newUser = userService.Add(createUser);

            if (newUser == null)
            {
                return Request.CreateResponse(HttpStatusCode.Conflict, "User with the same email already exists.");
            }

            return Request.CreateResponse(HttpStatusCode.Created, newUser);
        }

        [HttpPost]
        [Route("user/login")]
        public HttpResponseMessage Login(string UserEmail, string PasswordHash)
        {
            return Request.CreateResponse(HttpStatusCode.OK, userService.Login(UserEmail, PasswordHash));
        }

        [HttpGet]
        [Route("user/all")]
        public HttpResponseMessage GetAll()
        {
            var users = userService.GetAll();
            return Request.CreateResponse(HttpStatusCode.OK, users);
        }

        [HttpGet]
        [Route("user/{id}")]
        public HttpResponseMessage GetById(int id)
        {
            var user = userService.GetById(id);
            return Request.CreateResponse(HttpStatusCode.OK, user);
        }
    }
}
