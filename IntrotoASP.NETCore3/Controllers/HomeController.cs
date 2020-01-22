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
        public IActionResult Index()
        {
            return View();
        }
        [Authorize]
        public IActionResult Secret()
        {
            return View();
        }
        public IActionResult Authenticate()
        {
            var testClaims = new List<Claim>()
            {
                new Claim(ClaimTypes.Name,"John"),
 
                new Claim("DrivingLicense","A+"),
            };
            var licenseClaims = new List<Claim>()
            {
                
                new Claim(ClaimTypes.Name,"Jack"),
            
                new Claim("test.Says","First Test"),
            };
        
            //Create identity
            var testIdentity = new ClaimsIdentity(testClaims, "Test Identity");
            var licenseIdentity = new ClaimsIdentity(licenseClaims, "License Identity");
            var userPrincipal = new ClaimsPrincipal(new[] { testIdentity, licenseIdentity});
           
            HttpContext.SignInAsync(userPrincipal);
           
            return RedirectToAction("Index");
        }
    }
}
