using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using AccessData;
using Microsoft.EntityFrameworkCore;
using Model;

namespace Services
{
    public class ActivityService
    {
        static AppDbContext ctx;
        public ActivityService(AppDbContext Ctx)
        { 
            ctx = Ctx;
        }
        public List<Activity> GetActivities(string id)
        {
            List<Activity> activities = new List<Activity>();
            if (id==null)
            {       
                activities=ctx.Activity.ToList();
            }
            else
            {
                activities.Add(ctx.Activity.ToList().Find(x=>x.Id==id));
            }
            return activities;
        }

        public void Add(Activity activity)
        {
                //insertar un nuevo registro
            ctx.Activity.Add(activity);

            ctx.SaveChanges();// envia la consulta     
        }


        public void Delete(string id)
        {
            //insertar un nuevo registro
            Activity activity =ctx.Activity.Find(id);
            ctx.Activity.Remove(activity);

            ctx.SaveChanges();// envia la consulta     
        }

        public void Modify(Activity activity)
        {
            //insertar un nuevo registro
            Activity activityBd = ctx.Activity.Find(activity.Id);

            ctx.Activity.Remove(activityBd);
            ctx.SaveChanges();

            ctx.Activity.Add(activity);

            ctx.SaveChanges();// envia la consulta     
        }
    }
}
