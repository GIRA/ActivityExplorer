using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;
using ApiABMCActivity.Models;


namespace ApiABMCActivity.Controllers
{
    [EnableCors("*","*","*")]
    public class ActivityController : ApiController
    {
        static List<Activity> activities = new List<Activity>();

        static ActivityController()
        {
            Activity activity1 = new Activity();

            activity1.Id = "1";
            activity1.Area = "Educación";
            activity1.Descripcion = "Inserción de la robótica en el Aula";
            activity1.Duracion = "60 hrs";
            activity1.Titulo = "Insertar robots";

            Activity activity2 = new Activity();

            activity2.Id = "2";
            activity2.Area = "Educación";
            activity2.Descripcion = "Inserción de la programacion en el Aula";
            activity2.Duracion = "20 hrs";
            activity2.Titulo = "Hello Arduino";

            activities.Add(activity1);
            activities.Add(activity2);
        }
        // GET: api/Activity
        [HttpGet]
        public IEnumerable<Activity> Get()
        {
            return activities;
        }

        [HttpGet]
        // GET: api/Activity/5
        public Activity Get(string id)
        {
            return activities.Find(x => string.Compare(x.Id, id) == 0);
        }

        [HttpPost]
        // POST: api/Activity
        public string Post([FromBody]Activity activity)
        {
            string confirmation = "insert not valid";
            try
            {             
                if (activity != null)
                {
                    activities.Add(activity);
                    confirmation = "inserted";
                };
            }
            catch (Exception)
            {
            }
            return confirmation;
        }

        // Patch: api/Activity/5
        public string Patch(string id, [FromBody]Activity activityModify)
        {
            string confirmation = "Not found";
            //Activity activity=new Activity();
            try
            {
                Activity activity = activities.Find(x => string.Compare(x.Id, id) == 0);
                if (activity!= null && activityModify!=null) 
                {
                    activities.Remove(activity);
                    activityModify.Id=id;
                    activities.Add(activityModify);

                    confirmation = "Modified";
                }
            }
            catch (Exception)
            {
            }
            return confirmation;
        }

        // DELETE: api/Activity/5
        public string Delete(string id)
        {
            string confirmation = "Not found";
            try
            {               
                Activity activityDeleted = activities.Find(x => x.Id == id);
                if (activityDeleted!=null)
                {   
                    activities.Remove(activityDeleted);
                    confirmation = "Deleted";
                }
                
            }
            catch (Exception)
            {
            }               
            return confirmation;
        }
    }
}
