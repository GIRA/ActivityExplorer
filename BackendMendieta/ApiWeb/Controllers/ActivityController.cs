using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Model;
using Repository;

//using AccessData;

namespace ApiWeb.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class ActivityController : ControllerBase
    {
        private ActivityRepository activityRepository;
        
        public ActivityController(ActivityRepository activityRepository)
        {
            this.activityRepository = activityRepository;

        }
        // GET: api/Activity

        [EnableCors("PolicyCors")]
        [HttpGet]
        public IEnumerable<Activity> Get()
        {
            try
            {
                return activityRepository.GetAll();
            }
            catch (Exception)
            {

                throw;
            }
        }

        [EnableCors("PolicyCors")]
        // GET: api/Activity/5
        [HttpGet("{id}", Name = "Get")]
        public Activity Get(string id)
        {
            try
            {
                return activityRepository.GetById(id);
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
                    
                    activityRepository.Create(activity);

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
                //activityService.Modify(activityModify);
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
                //activityService.Delete(id);
                confirmation = "Deleted";
            }
            catch (Exception)
            {
            }
            return confirmation;
        }
    }
}
