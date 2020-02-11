using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace IntrotoASP.NETCore3.Controllers
{
    public class HomeController: Controller
    {
        private readonly IAuthorizationService _authorizationService;
        public HomeController(IAuthorizationService authorizationService)
        {
            _authorizationService = authorizationService;
        }
        
        public IActionResult Index()
        {
            return View();
        }
        [Authorize]
        public IActionResult Secret()
        {
            return View();
        }
        [Authorize(Policy ="Claim.DoB")]
        public IActionResult SecretPolicy()
        {
            return View("Secret");
        }
        [Authorize(Roles ="Admin")]
        public IActionResult SecretRole()
        {
            return View("Secret");
        }
        [AllowAnonymous]
        public IActionResult Authenticate()
        {
            var testClaims = new List<Claim>()
            {
                new Claim(ClaimTypes.Name,"John"),
                new Claim(ClaimTypes.DateOfBirth,"02/02/1992"),
                new Claim(ClaimTypes.Role,"Admin"),
                new Claim("test.Says","First Test"),

            };
            var licenseClaims = new List<Claim>()
            {
                
                new Claim(ClaimTypes.Name,"Jack"),
                new Claim("DrivingLicense","A+"),
               
            };
        
            //Create identity
            var testIdentity = new ClaimsIdentity(testClaims, "Test Identity");
            var licenseIdentity = new ClaimsIdentity(licenseClaims, "License Identity");
            var userPrincipal = new ClaimsPrincipal(new[] { testIdentity, licenseIdentity});
           
            HttpContext.SignInAsync(userPrincipal);
           
            return RedirectToAction("Index");
        }
        public async Task<IActionResult> DoStuff(
            [FromServices] IAuthorizationService authorizationService)
        {
       
        var builder = new AuthorizationPolicyBuilder("Schema");
            var customPolicy = builder.RequireClaim("Hello").Build();
          var authResult=  await _authorizationService.AuthorizeAsync(User, customPolicy);
           if (authResult.Succeeded)
            {
                return View("Index");
            }
            return View("Index");
        }
            
    }
}
