using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Model;

namespace ApiWeb.Controllers
{
    
    [Route("api/[controller]")]
    [ApiController]
    public class ActivityController : ControllerBase
    {
        static List<Activity> activities = new List<Activity>();

        static ActivityController()
        {
            Activity activity1 = new Activity();
            Activity activity2 = new Activity();

            activity1.Id = "1";            
            activity2.Id = "2";

            activities.Add(activity1);
            activities.Add(activity2);
        }
        // G   ET: api/Activity

        [EnableCors("PolicyCors")]
        [HttpGet]
        public IEnumerable<Activity> Get()
        {
            return activities;
        }

        [EnableCors("PolicyCors")]
        // GET: api/Activity/5
        [HttpGet("{id}", Name = "Get")]
        public Activity Get(string id)
        {
            return activities.Find(x => string.Compare(x.Id, id) == 0);

        }

       
        // POST: api/Activity
        [HttpPost]
        public string Post([FromBody] Activity activity)
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

        [EnableCors("PolicyCors")]
        [HttpPatch("{id}")]
        // Patch: api/Activity/5
        public string Patch(string id, [FromBody]Activity activityModify)
        {
            string confirmation = "Not found";
            //Activity activity=new Activity();
            try
            {
                Activity activity = activities.Find(x => string.Compare(x.Id, id) == 0);
                if (activity != null && activityModify != null)
                {
                    activities.Remove(activity);
                    activityModify.Id = id;
                    activities.Add(activityModify);

                    confirmation = "Modified";
                }
            }
            catch (Exception)
            {
            }
            return confirmation;
        }

        [EnableCors("PolicyCors")]
        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public string Delete(string id)
        {
            string confirmation = "Not found";
            try
            {
                Activity activityDeleted = activities.Find(x => x.Id == id);
                if (activityDeleted != null)
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
