using BLL.DTOs;
using DAL.Repos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class UserService
    {
        readonly MapperService mapperService = new MapperService();
        readonly UserRepo userRepo = new UserRepo();

        public CreateUserDTO Add(CreateUserDTO createUser)
        {
            var newUser = userRepo.Add(mapperService.MapCreateUser(createUser));

            return mapperService.MapUserToCreateUserDto(newUser);
        }

        public List<CreateUserDTO> GetAll()
        {
            var users = userRepo.GetAll();

            foreach (var user in users)
            {
                user.PasswordHash = null;
            }

            return mapperService.MapUserCollection(users);
        }

        public CreateUserDTO GetById(int id)
        {
            var user = userRepo.GetById(id);

            if (user == null)
            {
                return null;
            }

            user.PasswordHash = null;

            return mapperService.MapUserToCreateUserDto(user);
        }

        public CreateUserDTO Login(string UserEmail, string PasswordHash)
        {
            var user = userRepo.Login(UserEmail, PasswordHash);

            if (user == null)
            {
                return null;
            }

            return mapperService.MapUserToCreateUserDto(user);
        }
    }
}
