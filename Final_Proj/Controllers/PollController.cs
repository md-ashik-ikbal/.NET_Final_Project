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
    public class PollController : ApiController
    {
        readonly PollService pollService = new PollService();

        [HttpPost]
        [Route("poll/create")]
        public HttpResponseMessage Create(CreatePollDto createPoll)
        {
            var newPoll = pollService.CreatePoll(createPoll);

            if (newPoll == null)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound, new {Message = "User not found!"});
            }
            return Request.CreateResponse(HttpStatusCode.Created, newPoll);
        }

        [HttpGet]
        [Route("poll/all")]
        public HttpResponseMessage GetAll()
        {
            var polls = pollService.GetAll();
            return Request.CreateResponse(HttpStatusCode.OK, polls);
        }
    }
}