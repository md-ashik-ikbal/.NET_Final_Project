using DAL.EF;
using DAL.EF.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace DAL.Repos
{
    public class UserRepo : Repository<UserEntity>
    {
        readonly Context context = new Context();
        public UserRepo() { }

        public override UserEntity Add(UserEntity entity)
        {
            // Check if a user with the same email already exists
            if (context.Set<UserEntity>().Any(u => u.UserEmail == entity.UserEmail))
            {
                // Return null if email already exist
                return null;
            }

            // If no user with that email exists, add the user
            context.Set<UserEntity>().Add(entity);
            context.SaveChanges();
            entity.PasswordHash = null; // set PasswordHash to null not to show in the response
            return entity;
        }

        public UserEntity Login(string UserEmail, string PasswordHash)
        {
            var user = context.Users.FirstOrDefault(u => u.UserEmail == UserEmail && u.PasswordHash == PasswordHash);
            if (user == null)
            {
                return null;
            }


            //HttpContext.Current.Session["UserId"] = user.UserId;
            return user;
        }
    }
}
