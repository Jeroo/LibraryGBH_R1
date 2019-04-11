using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Core.Common.Contracts;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using LibraryGBH.Business.Engines.Contracts;
using LibraryGBH.Business.Entities;

namespace LibraryGBH.WebAPP.Controllers
{
    public class HomeController : Controller
    {
        private readonly IBusinessEngineFactory _businessEngineFactory;
        private readonly SignInManager<IdentityUser> signInManager;
        private readonly UserManager<IdentityUser> userManager;

        public HomeController(UserManager<IdentityUser> userManager, IBusinessEngineFactory businessEngineFactory, SignInManager<IdentityUser> signInManager)
        {
            this.userManager = userManager;
            this._businessEngineFactory = businessEngineFactory;
            this.signInManager = signInManager;
        }


        public async Task<IActionResult> Index()
        {
            var engine = _businessEngineFactory.GetBusinessEngine<ISampleEngine>();

            var signInResult = await signInManager.PasswordSignInAsync("","", false,false);

            

            ProductosPool pp = new ProductosPool();

            
            return View();
        }

        public IActionResult Error()
        {
            ViewData["RequestId"] = Activity.Current?.Id ?? HttpContext.TraceIdentifier;
            return View();
        }
    }
}
