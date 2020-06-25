using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.AspNetCore.Identity;
using AccessData;
using Login.Models;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.Authorization;

namespace ApiWeb.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        public static CAETIContext caetiContext;
        public static SignInManager<SystemUser> signInManager;
        public static UserManager<SystemUser> userManager;
        private IConfiguration config;
        public AccountController(IConfiguration configuration, CAETIContext context, UserManager<SystemUser> user, SignInManager<SystemUser> signIn)
        {
            config = configuration;
            caetiContext = context;
            userManager = user;
            signInManager = signIn;
        }

        // POST: Register/Create
        [AllowAnonymous]
        [HttpPost("SignIn")]
        public async Task<IActionResult> SignIn(RegisterViewModel registerViewModel) 
        {
            try
            {
                SystemUser systemUser = new SystemUser(registerViewModel.Id, registerViewModel.FirstName, registerViewModel.LastName,
                    registerViewModel.City, registerViewModel.Dni, registerViewModel.Email,
                    registerViewModel.PhoneNumber, registerViewModel.Institution,
                    registerViewModel.ImageFileName, registerViewModel.Password);

                if (caetiContext.SystemUser.Count() == 0)
                {
                    systemUser.Id = "0";
                }
                else
                {
                    systemUser.Id = (Convert.ToInt32(caetiContext.SystemUser.Max(u => u.Id)) + 1).ToString();
                }

                await userManager.UpdateSecurityStampAsync(systemUser);
                await userManager.CreateAsync(systemUser);
                await signInManager.SignInAsync(systemUser, true);
                return Login(new LoginViewModel() { 
                    Email = registerViewModel.Email,
                    Password = registerViewModel.Password
                });
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // TODO: We probably need to change the way we find the user, it's not clean. It does work though.
        // TODO: Return pertinent user information on login. We'll probably have to make a ResponseUserData class or something.
        [AllowAnonymous]
        [HttpPost("Login")]
        public IActionResult Login(LoginViewModel loginViewModel)
        {
            try
            {
                IActionResult result = Unauthorized();
                SystemUser systemUser = caetiContext.SystemUser.ToList().Find(x => x.Email == loginViewModel.Email);
                PasswordHasher<SystemUser> passwordHasher = new PasswordHasher<SystemUser>();
                if (passwordHasher.VerifyHashedPassword(systemUser, systemUser.PasswordHash, loginViewModel.Password) == PasswordVerificationResult.Success)
                {
                    var tokenString = GenerateJSONWebToken(systemUser);
                    result = Ok(new { token = tokenString });
                }
                return result;
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }            
        }

        private string GenerateJSONWebToken(SystemUser userInfo)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(config["Jwt:Key"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(config["Jwt:Issuer"],
              config["Jwt:Issuer"],
              null,
              expires: DateTime.Now.AddMinutes(120),
              signingCredentials: credentials);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        // TODO: Check how to kill the token (if possible).
        //public async Task<ActionResult> Logout()
        //{
        //    try
        //    {
        //        await signInManager.SignOutAsync();
        //        return Redirect("/Home");
        //    }
        //    catch (Exception ex)
        //    {
        //        return BadRequest(ex.Message);
        //    }
        //}
    }
}