using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Core.Common.Contracts;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using LibraryGBH.Business.Engines.Contracts;
using LibraryGBH.Business.Entities;
using LibraryGBH.Business.Entities.DTOs;
using LibraryGBH.WEB.Models.ViewModels;

namespace LibraryGBH.WEB.Controllers.API
{
    [Produces("application/json")]
    [Route("api/Book")]
    public class BookController : Controller
    {

        private readonly IBusinessEngineFactory _businessEngineFactory;
        private readonly SignInManager<IdentityUser> signInManager;
        private readonly UserManager<IdentityUser> userManager;
        private readonly IDataRepositoryFactory _dataRepositoryFactory;

        public BookController(IDataRepositoryFactory dataRepositoryFactory, UserManager<IdentityUser> userManager, 
            IBusinessEngineFactory businessEngineFactory, 
            SignInManager<IdentityUser> signInManager)
        {
            this.userManager = userManager;
            this._businessEngineFactory = businessEngineFactory;
            this.signInManager = signInManager;
            this._dataRepositoryFactory = dataRepositoryFactory;
        }

        [Route("listbooks")]
        public async Task<List<BookDTO>> ListBooks()
        {
            var productEngine = _businessEngineFactory.GetBusinessEngine<IBookEngine>();
            return productEngine.GetAllBooks();
        }

        [Route("readbook")]
        public async Task<List<BookDTO>> ReadBook(long bookid)
        {
            var productEngine = _businessEngineFactory.GetBusinessEngine<IBookEngine>();
            return productEngine.GetAllBooks();
        }
    }
}