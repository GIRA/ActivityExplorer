using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using AccessData;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ApiWeb.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoleController : ControllerBase
    {
        public static RoleManager<SystemUserRole> roleManager;
        public static CAETIContext caetiContext;
        public RoleController(RoleManager<SystemUserRole> manager, CAETIContext context)
        {
            roleManager = manager;
            caetiContext = context;
        }
        // GET: api/<RoleController>
        [HttpGet]
        public IEnumerable<SystemUserRole> Get()
        {
            return roleManager.Roles;
        }

        // GET api/<RoleController>/5
        [HttpGet("{id}")]
        public async Task<SystemUserRole> Get(string id)
        {
            return await roleManager.FindByIdAsync(id);
        }

        // POST api/<RoleController>
        [HttpPost]   
        public async Task<IdentityResult> Post([FromBody]SystemUserRole role)
        {
            IdentityResult result = await roleManager.CreateAsync(role);
            return result;
        }

        // PUT api/<RoleController>/5
        [HttpPatch("{id}")]
        public async Task<IdentityResult> Patch(string id, [FromBody] SystemUserRole role)
        {
            SystemUserRole toModify = await roleManager.FindByIdAsync(id);
            toModify.Name = role.Name;
            IdentityResult result = await roleManager.UpdateAsync(toModify);
            return result;
        }

        // DELETE api/<RoleController>/5
        [HttpDelete("{id}")]
        public async Task<IdentityResult> Delete(string id)
        {
            return await roleManager.DeleteAsync(await roleManager.FindByIdAsync(id));
        }
    }
}
