using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Common.Contracts;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using LibraryGBH.Business.Entities;
using LibraryGBH.Business.Entities.DTOs;
using LibraryGBH.WEB.Models.ViewModels;

namespace LibraryGBH.WEB.Controllers.API
{
    [Produces("application/json")]
    [Route("api/logon")]
    public class LoginController : Controller
    {

        private readonly IBusinessEngineFactory _businessEngineFactory;
        private readonly SignInManager<IdentityUser> signInManager;
        private readonly UserManager<IdentityUser> userManager;
        private readonly IDataRepositoryFactory _dataRepositoryFactory;

        public LoginController(IDataRepositoryFactory dataRepositoryFactory, UserManager<IdentityUser> userManager, IBusinessEngineFactory businessEngineFactory, SignInManager<IdentityUser> signInManager)
        {
            this.userManager = userManager;
            this._businessEngineFactory = businessEngineFactory;
            this.signInManager = signInManager;
            this._dataRepositoryFactory = dataRepositoryFactory;
        }

        [HttpPost]
        [Route("logon")]
        public async Task<IActionResult> logon([FromBody]LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
              

                var result = await signInManager.PasswordSignInAsync(model.username,
                   model.password, model.rememberMe, false);

                if (User.IsInRole("Administrador"))
                {

                }

                if (result.Succeeded)
                {
                    if (!string.IsNullOrEmpty(model.returnUrl) && Url.IsLocalUrl(model.returnUrl))
                    {
                        return Ok(model);
                    }
                    else
                    {
                        return Ok(model);
                    }
                }
            }

            return BadRequest(model);
        }

        [HttpPost]
        [Route("register")]
        public async Task<IActionResult> register([FromBody]RegisterViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = new IdentityUser { UserName = model.email, Email = model.email };
                var result = await userManager.CreateAsync(user, model.password);

                if (result.Succeeded)
                {
                    await signInManager.SignInAsync(user, false);

                    var userRoles = await userManager.AddToRoleAsync(user, "Usuario Cliente");


                    var repo = _dataRepositoryFactory.GetDataRepository<Individuos>();
                    
                    Individuos newIndividuos = new Individuos();
                    newIndividuos.Nombre = model.nombre;
                    newIndividuos.Apellidos = model.apellidos;
                    newIndividuos.CreatedDate = DateTime.Now;
                    newIndividuos.UserId = new Guid(user.Id);
                    newIndividuos.CreatedById = new Guid(user.Id);
                    newIndividuos.UpdatedById = new Guid(user.Id);
                    newIndividuos.UpdatedDate = DateTime.Now;

                    repo.Add(newIndividuos);



                    return Ok("Ok");
                    //return RedirectToAction("Index", "Home");
                }
                else
                {
                    string errorlist = string.Empty;
                    foreach (var error in result.Errors)
                    {
                        ModelState.AddModelError("", error.Description);
                        errorlist += error.Description;
                    }

                    return BadRequest(errorlist);
                }
            }

            // If we got this far, something failed, redisplay form
            return Ok(model);
        }

    }
}