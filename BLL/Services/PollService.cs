using BLL.DTOs;
using DAL.EF.Entities;
using DAL.Repos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class PollService
    {
        readonly MapperService mapperService = new MapperService();
        readonly UserService userService = new UserService();
        readonly PollRepo pollRepo = new PollRepo();

        public CreatePollDto CreatePoll(CreatePollDto createPollDto)
        {
            var user = userService.GetById(createPollDto.UserId);

            if (user == null)
            {
                return null;
            }

            var newPoll = pollRepo.Add(mapperService.MapCreatePoll(createPollDto));
            return mapperService.MapPollToCreatePollDto(newPoll);
        }

        public List<CreatePollDto> GetAll()
        {
            var polls = pollRepo.GetAll();

            return mapperService.MapPollCollection(polls);
        }

        //public CreatePollDto Delete(CreatePollDto createPollDto)
        //{

        //}
    }
}
