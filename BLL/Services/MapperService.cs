using AutoMapper;
using BLL.DTOs;
using DAL.EF.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    internal class MapperService
    {
        readonly IMapper mapper;
        public MapperService()
        {
            var config = new MapperConfiguration(cfg =>
            {
                // Map UserEntity to CreateUserDTO
                cfg.CreateMap<UserEntity, CreateUserDTO>()
                    .ForMember(dest => dest.Polls, opt => opt.MapFrom(src => src.Polls.Select(p => new CreatePollDto
                    {
                        PollId = p.PollId,
                        Question = p.Question,
                        EndDateTime = p.EndDateTime,
                        Options = p.Options.Select(o => new CreateOptionDto
                        {
                            OptionId = o.OptionId,
                            Text = o.Text
                        }).ToList()
                    }).ToList()));

                // Map CreateUserDTO to UserEntity
                cfg.CreateMap<CreateUserDTO, UserEntity>()
                    .ForMember(dest => dest.Polls, opt => opt.MapFrom(src => src.Polls.Select(p => new PollEntity
                    {
                        PollId = p.PollId,
                        Question = p.Question,
                        EndDateTime = p.EndDateTime,
                        Options = p.Options.Select(o => new OptionEntity
                        {
                            OptionId = o.OptionId,
                            Text = o.Text
                        }).ToList()
                    }).ToList()));

                // Map PollEntity to CreatePollDto
                cfg.CreateMap<PollEntity, CreatePollDto>()
                    .ForMember(dest => dest.Votes, opt => opt.MapFrom(src => src.Votes.Select(v => new CreateVoteDto
                    {
                        VoteId = v.VoteId,
                        OptionId = v.OptionId,
                        IsAnonymous = v.IsAnonymous,
                        UserId = v.UserId,
                        Username = v.User.Username,
                        OptionDescription = v.Option.Text,
                        PollTitle = v.Poll.Question
                    }).ToList()))
                    .ForMember(dest => dest.Options, opt => opt.MapFrom(src => src.Options.Select(o => new CreateOptionDto
                    {
                        OptionId = o.OptionId,
                        Text = o.Text,
                        PollId = o.PollId
                    }).ToList()));

                // Map CreatePollDto to PollEntity
                cfg.CreateMap<CreatePollDto, PollEntity>()
                    .ForMember(dest => dest.Options, opt => opt.MapFrom(src => src.Options.Select(o => new OptionEntity
                    {
                        OptionId = o.OptionId,
                        Text = o.Text,
                        PollId = o.PollId
                    }).ToList()))
                    .ForMember(dest => dest.Votes, opt => opt.MapFrom(src => src.Votes.Select(v => new VoteEntity
                    {
                        OptionId = v.OptionId,
                        IsAnonymous = v.IsAnonymous,
                        UserId = v.UserId,
                        PollId = v.PollId
                    }).ToList()));

                // Map OptionEntity to CreateOptionDto
                cfg.CreateMap<OptionEntity, CreateOptionDto>()
                    .ForMember(dest => dest.VoteCount, opt => opt.MapFrom(src => src.Votes.Count()));
                    //.ForMember(dest => dest.PollQuestion, opt => opt.MapFrom(src => src.Poll.Question));

                // Map CreateOptionDto to OptionEntity
                cfg.CreateMap<CreateOptionDto, OptionEntity>()
                    .ForMember(dest => dest.PollId, opt => opt.MapFrom(src => src.PollId));

                // Map VoteEntity to CreateVoteDto
                cfg.CreateMap<VoteEntity, CreateVoteDto>()
                    .ForMember(dest => dest.Username, opt => opt.MapFrom(src => src.User.Username))
                    .ForMember(dest => dest.OptionDescription, opt => opt.MapFrom(src => src.Option.Text))
                    .ForMember(dest => dest.PollTitle, opt => opt.MapFrom(src => src.Poll.Question));

                // Map CreateVoteDto to VoteEntity
                cfg.CreateMap<CreateVoteDto, VoteEntity>()
                    .ForMember(dest => dest.UserId, opt => opt.MapFrom(src => src.UserId))
                    .ForMember(dest => dest.OptionId, opt => opt.MapFrom(src => src.OptionId))
                    .ForMember(dest => dest.PollId, opt => opt.MapFrom(src => src.PollId));
            });

            mapper = config.CreateMapper();
        }

        // Create Methods - Mapping DTO to Entity (for creating new records)
        public UserEntity MapCreateUser(CreateUserDTO createUserDto)
        {
            return mapper.Map<UserEntity>(createUserDto);
        }

        public PollEntity MapCreatePoll(CreatePollDto createPollDto)
        {
            return mapper.Map<PollEntity>(createPollDto);
        }

        public VoteEntity MapCreateVote(CreateVoteDto createVoteDto)
        {
            return mapper.Map<VoteEntity>(createVoteDto);
        }

        public OptionEntity MapCreateOption(CreateOptionDto CreateOptionDto)
        {
            return mapper.Map<OptionEntity>(CreateOptionDto);
        }

        // Read Methods - Mapping Entity to DTO (for reading records)
        public CreateUserDTO MapUserToCreateUserDto(UserEntity userEntity)
        {
            return mapper.Map<CreateUserDTO>(userEntity);
        }

        public CreatePollDto MapPollToCreatePollDto(PollEntity pollEntity)
        {
            return mapper.Map<CreatePollDto>(pollEntity);
        }

        public CreateVoteDto MapVoteToCreateVoteDto(VoteEntity voteEntity)
        {
            return mapper.Map<CreateVoteDto>(voteEntity);
        }

        public CreateOptionDto MapOptionToCreateOptionDto(OptionEntity optionEntity)
        {
            return mapper.Map<CreateOptionDto>(optionEntity);
        }

        // Map a collection of entities to their corresponding DTOs (e.g., for lists)
        public List<CreateUserDTO> MapUserCollection(List<UserEntity> userEntities)
        {
            return mapper.Map<List<CreateUserDTO>>(userEntities);
        }

        public List<CreatePollDto> MapPollCollection(List<PollEntity> pollEntities)
        {
            return mapper.Map<List<CreatePollDto>>(pollEntities);
        }

        public List<CreateVoteDto> MapVoteCollection(List<VoteEntity> voteEntities)
        {
            return mapper.Map<List<CreateVoteDto>>(voteEntities);
        }

        public List<CreateOptionDto> MapOptionCollection(List<OptionEntity> optionEntities)
        {
            return mapper.Map<List<CreateOptionDto>>(optionEntities);
        }

        // Update Methods - Mapping DTO to Entity (for updating existing records)
        public void MapUpdateUser(CreateUserDTO createUserDto, UserEntity userEntity)
        {
            mapper.Map(createUserDto, userEntity);
        }

        public void MapUpdatePoll(CreatePollDto createPollDto, PollEntity pollEntity)
        {
            mapper.Map(createPollDto, pollEntity);
        }

        public void MapUpdateVote(CreateVoteDto createVoteDto, VoteEntity voteEntity)
        {
            mapper.Map(createVoteDto, voteEntity);
        }

        public void MapUpdateOption(CreateOptionDto CreateOptionDto, OptionEntity optionEntity)
        {
            mapper.Map(CreateOptionDto, optionEntity);
        }
    }
}
