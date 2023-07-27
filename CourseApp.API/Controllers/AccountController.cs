using CourseApp.API.Services;
using CourseApp.Core.Entities;
using CourseApp.Service.Dtos.GroupDtos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace CourseApp.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly UserManager<AppUser> _userManager;
        private readonly IConfiguration _configuration;
        private readonly JwtService _jwtService;

        public AccountController(RoleManager<IdentityRole> roleManager , UserManager<AppUser> userManager,IConfiguration configuration ,JwtService jwtService)
        {
            _roleManager = roleManager;
            _userManager = userManager;
            _configuration = configuration;
            _jwtService = jwtService;
        }

        //[HttpGet("createrole")]
        //public async Task<IActionResult> CreateRole()
        //{

        //    await _roleManager.CreateAsync(new IdentityRole("Admin"));
        //    await _roleManager.CreateAsync(new IdentityRole("Member"));

        //    return Ok();
        //}

        //[HttpGet("createadmin")]
        //public async Task<IActionResult> CreateAdmin()
        //{

        //    AppUser user = new AppUser
        //    {
        //        Fullname = "Rahim Valiyev",
        //        UserName = "Riko_admin",

        //    };

        //    var result = await _userManager.CreateAsync(user, "Admin123");
        //    var resultRole = await _userManager.AddToRoleAsync(user, "Admin");

        //    return Ok();
        //}

        [HttpPost("login")]

        public async Task<IActionResult> Login(AdminLoginDto dto)
        {
            var user =  await _userManager.FindByNameAsync(dto.Username);

            if (user == null)
            {
                return NotFound();
            }

            if (!await _userManager.CheckPasswordAsync(user,dto.Password))
            {
                return NotFound();
            }


            return Ok(new {token = await _jwtService.GenerateToken(user)});
        }
    }
}
