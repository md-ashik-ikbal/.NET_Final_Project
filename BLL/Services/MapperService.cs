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
                    .ForMember(dest => dest.Votes, opt => opt.MapFrom(src => src.Votes.Select(v => v.Option.Text))); // Include the relevant vote info

                // Map CreateUserDTO to UserEntity (for creating/updating users)
                cfg.CreateMap<CreateUserDTO, CreateUserDTO>();

                // Map PollEntity to CreatePollDto
                cfg.CreateMap<PollEntity, CreatePollDto>()
                    .ForMember(dest => dest.VoteCount, opt => opt.MapFrom(src => src.Votes.Count())) // Include the vote count
                    .ForMember(dest => dest.Options, opt => opt.MapFrom(src => src.Options));

                // Map CreatePollDto to PollEntity (for creating/updating polls)
                cfg.CreateMap<CreatePollDto, PollEntity>()
                    .ForMember(dest => dest.Options, opt => opt.MapFrom(src => src.Options));

                // Map VoteEntity to CreateVoteDto
                cfg.CreateMap<VoteEntity, CreateVoteDto>()
                    .ForMember(dest => dest.Username, opt => opt.MapFrom(src => src.User.Username))
                    .ForMember(dest => dest.OptionDescription, opt => opt.MapFrom(src => src.Option.Text))
                    .ForMember(dest => dest.PollTitle, opt => opt.MapFrom(src => src.Poll.Question));

                // Map CreateVoteDto to VoteEntity (for creating votes)
                cfg.CreateMap<CreateVoteDto, VoteEntity>()
                    .ForMember(dest => dest.UserId, opt => opt.MapFrom(src => src.UserId))
                    .ForMember(dest => dest.OptionId, opt => opt.MapFrom(src => src.OptionId))
                    .ForMember(dest => dest.PollId, opt => opt.MapFrom(src => src.PollId));

                // Map OptionEntity to OptionDto
                cfg.CreateMap<OptionEntity, OptionDto>()
                    .ForMember(dest => dest.VoteCount, opt => opt.MapFrom(src => src.Votes.Count())) // Include the vote count for each option
                    .ForMember(dest => dest.PollQuestion, opt => opt.MapFrom(src => src.Poll.Question));

                // Map OptionDto to OptionEntity (for creating/updating options)
                cfg.CreateMap<OptionDto, OptionEntity>()
                    .ForMember(dest => dest.PollId, opt => opt.MapFrom(src => src.PollId));
            });

            mapper = config.CreateMapper();
        }

        // Create Methods - Mapping DTO to Entity (for creating new records)
        public DAL.EF.Entities.UserEntity MapCreateUser(DTOs.CreateUserDTO createUserDto)
        {
            return mapper.Map<DAL.EF.Entities.UserEntity>(createUserDto);
        }

        public PollEntity MapCreatePoll(CreatePollDto createPollDto)
        {
            return mapper.Map<PollEntity>(createPollDto);
        }

        public VoteEntity MapCreateVote(CreateVoteDto createVoteDto)
        {
            return mapper.Map<VoteEntity>(createVoteDto);
        }

        public OptionEntity MapCreateOption(OptionDto optionDto)
        {
            return mapper.Map<OptionEntity>(optionDto);
        }

        // Read Methods - Mapping Entity to DTO (for reading records)
        public DTOs.CreateUserDTO MapUserToCreateUserDto(DAL.EF.Entities.UserEntity userEntity)
        {
            return mapper.Map<DTOs.CreateUserDTO>(userEntity);
        }

        public CreatePollDto MapPollToCreatePollDto(PollEntity pollEntity)
        {
            return mapper.Map<CreatePollDto>(pollEntity);
        }

        public CreateVoteDto MapVoteToCreateVoteDto(VoteEntity voteEntity)
        {
            return mapper.Map<CreateVoteDto>(voteEntity);
        }

        public OptionDto MapOptionToOptionDto(OptionEntity optionEntity)
        {
            return mapper.Map<OptionDto>(optionEntity);
        }

        // Map a collection of entities to their corresponding DTOs (e.g., for lists)
        public List<DTOs.CreateUserDTO> MapUserCollection(List<DAL.EF.Entities.UserEntity> userEntities)
        {
            return mapper.Map<List<DTOs.CreateUserDTO>>(userEntities);
        }

        public List<CreatePollDto> MapPollCollection(List<PollEntity> pollEntities)
        {
            return mapper.Map<List<CreatePollDto>>(pollEntities);
        }

        public List<CreateVoteDto> MapVoteCollection(List<VoteEntity> voteEntities)
        {
            return mapper.Map<List<CreateVoteDto>>(voteEntities);
        }

        public List<OptionDto> MapOptionCollection(List<OptionEntity> optionEntities)
        {
            return mapper.Map<List<OptionDto>>(optionEntities);
        }

        // Update Methods - Mapping DTO to Entity (for updating existing records)
        public void MapUpdateUser(DTOs.CreateUserDTO createUserDto, DAL.EF.Entities.UserEntity userEntity)
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

        public void MapUpdateOption(OptionDto optionDto, OptionEntity optionEntity)
        {
            mapper.Map(optionDto, optionEntity);
        }
    }
}
