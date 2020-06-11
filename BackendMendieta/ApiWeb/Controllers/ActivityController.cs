using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Model;
using Services;
using AccessData;

namespace ApiWeb.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class ActivityController : ControllerBase
    {

        public static AppDbContext Context;

        public static ActivityService activityService;
        
        public ActivityController(AppDbContext context)
        {
            Context = context;
            activityService = new ActivityService(Context);

            //Activity activity1 = new Activity();
            //Activity activity2 = new Activity();

            //activity1.Id = "1";
            //activity1.Area = "Robotica";
            //activity2.Id = "2";
            //activity2.Area = "Programacion c";

            //activityService.Add(activity1);
            //activityService.Add(activity2);
        }
        // GET: api/Activity

        [EnableCors("PolicyCors")]
        [HttpGet]
        public List<Activity> Get()
        {
            try
            {
                return activityService.GetActivities(null);
            }
            catch (Exception)
            {

                throw;
            }
        }

        [EnableCors("PolicyCors")]
        // GET: api/Activity/5
        [HttpGet("{id}", Name = "Get")]
        public List<Activity> Get(string id)
        {
            try
            {
                return activityService.GetActivities(id);
            }
            catch (Exception)
            {

                throw;
            }
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
                    //activities.Add(activity);
                    
                    activityService.Add(activity);

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
                activityService.Modify(activityModify);
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
                activityService.Delete(id);
                confirmation = "Deleted";
            }
            catch (Exception)
            {
            }
            return confirmation;
        }
    }
}
