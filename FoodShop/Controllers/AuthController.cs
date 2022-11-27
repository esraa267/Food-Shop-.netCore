using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;

using Microsoft.AspNetCore.Mvc;
using RepositryPattern.Core.Dtos;
using RepositryPattern.EF.Data;

namespace FoodShop.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly UserManager<ApplicationUser> userManager;
        private readonly SignInManager<ApplicationUser> signInManager;
        private readonly RoleManager<IdentityRole> roleManager;

         public AuthController(UserManager<ApplicationUser> userManager, 
                               SignInManager<ApplicationUser> signInManager, 
                               RoleManager<IdentityRole> roleManager)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
            this.roleManager = roleManager;
        }
    
        [HttpPost("register")]
        public async Task<status> RegisterAsync(Register model)
        {
            var status = new status();
            var userExists = await userManager.FindByNameAsync(model.UserName);
            if(userExists != null)
            {
                status.statusCode = 0;
                status.message = "This Email Aleady exists";
                return status;
            }
            ApplicationUser user = new ApplicationUser
            {
                Id= Guid.NewGuid().ToString(),
                SecurityStamp = Guid.NewGuid().ToString(),
                UserName = model.UserName,
                Email = model.Email,
                Name = model.Name,
                EmailConfirmed = true,
                PhoneNumberConfirmed = true,
                AccessFailedCount=3,
                LockoutEnabled=true,    
                TwoFactorEnabled=true,  

            };
            var result = await userManager.CreateAsync(user,model.Password);
            if (!result.Succeeded)
            {
                status.statusCode = 0;
                status.message = "User creation failed";
                return status;
            }
            status.statusCode = 1;
            status.message = "User creation succeeded";
            return status;
        }

        [HttpPost("Login")]
        public async Task<status> LoginAsync(Login model)
        {
            var status = new status();
            var user = await userManager.FindByNameAsync(model.UserName);
            if (user == null)
            {
                status.statusCode = 0;
                status.message = "Invalid username";
                return status;
            }
            if (!await userManager.CheckPasswordAsync(user, model.Password))
            {
                status.statusCode = 0;
                status.message = "Invalid Password";
                return status;
            }

            var SignInResult = await signInManager.CheckPasswordSignInAsync(user, model.Password, false);
            if (SignInResult.Succeeded)
            {
                status.statusCode = 1;
                status.message = "Loggin succeeded ";
                return status;

            }

            else
            {
                status.statusCode = 0;
                status.message = "Loggin failed ";
                return status;
            }

        }
    }
}
