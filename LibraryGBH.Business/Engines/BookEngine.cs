using Core.Common.Contracts;
using LinqKit;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LibraryGBH.Business.Engines.Contracts;
using LibraryGBH.Business.Entities;
using LibraryGBH.Business.Entities.DTOs;

namespace LibraryGBH.Business.Engines
{
    public class BookEngine : IBookEngine
    {
        private readonly IBusinessEngineFactory _businessEngineFactory;
        private readonly UserManager<IdentityUser> userManager;
        private readonly IDataRepositoryFactory _dataRepositoryFactory;

        public BookEngine(IDataRepositoryFactory dataRepositoryFactory, UserManager<IdentityUser> userManager, IBusinessEngineFactory businessEngineFactory)
        {
            this.userManager = userManager;
            this._businessEngineFactory = businessEngineFactory;
            this._dataRepositoryFactory = dataRepositoryFactory;
        }


        public List<BookDTO> GetAllBooks()
        {
            var repoBookList = _dataRepositoryFactory.GetDataRepository<Books>();
            var predicate = PredicateBuilder.New<Books>(true);
            predicate = predicate.And(c => !c.Deferred);

            try
            {
                var listBooks = repoBookList.GetAll(x => x.Select(r => new BookDTO
                {
                    BookId = r.Id,
                    Author = r.Author,
                    BooksTypesId = r.BooksTypes.Id,
                    CoverPageImg = r.CoverPageImg,
                    Description = r.Description,
                    Name = r.Name,
                    pages = r.Pages,
                    TotalPages = r.TotalPages

                }), predicate);

                return listBooks.ToList();
            }
            catch (Exception ex)
            {

                throw;
            }

            return null;
        }

      
    }
}
