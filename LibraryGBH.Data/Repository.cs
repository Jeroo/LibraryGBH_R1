using Core.Common.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace LibraryGBH.Data
{
    public class Repository<TEntity> : RepositoryBase<TEntity, LibraryGBHDataContext> where TEntity : class, new()
    {
        public Repository(LibraryGBHDataContext context) : base(context) { }
    }
}
