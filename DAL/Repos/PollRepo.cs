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
    public class PollRepo : Repository<PollEntity>
    {
        readonly Context context = new Context();
        //readonly int userId = (int)HttpContext.Current.Session["UserId"];
        public PollRepo() { }

        public override PollEntity Add(PollEntity entity)
        {
            //var currentUser = context.Users.Find(userId);

            //if (currentUser != null)
            if(true)
            {
                context.Set<PollEntity>().Add(entity);
                context.SaveChanges();
                return entity;
            }

            //return null;
        }

        //public override PollEntity Delete(PollEntity entity)
        //{
        //    var currentUser = context.Users.Find(userId);
        //    return base.Delete(entity);
        //}
    }
}
