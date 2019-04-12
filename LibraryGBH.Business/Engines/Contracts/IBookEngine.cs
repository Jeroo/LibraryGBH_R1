using Core.Common.Contracts;
using System;
using System.Collections.Generic;
using System.Text;
using LibraryGBH.Business.Entities;
using LibraryGBH.Business.Entities.DTOs;

namespace LibraryGBH.Business.Engines.Contracts
{
    public interface IBookEngine : IBusinessEngine
    {
        List<BookDTO> GetAllBooks();
    }
}
