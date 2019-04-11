using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;

namespace LibraryGBH.Business.Base
{
    public class EngineBase
    {
        //private Guid _CurrentUserId;
        //protected Guid CurrentUserId
        //{
        //    get {
        //        if (_CurrentUserId == null)
        //        {
        //            var context = (IHttpContextAccessor)this.HttpContext.RequestServices.GetService(typeof(IHttpContextAccessor));

        //            _CurrentUserId = Guid.Parse(context.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value);
        //        }

        //        return _CurrentUserId;
        //    }
        //}

        //private Guid _CurrentRoleId;
        //protected Guid CurrentRoleId
        //{
        //    get {
        //        if (_CurrentRoleId == Guid.Empty)
        //        {
        //            var context = (IHttpContextAccessor)this.HttpContext.RequestServices.GetService(typeof(IHttpContextAccessor));

        //            _CurrentRoleId = Guid.Parse(context.HttpContext.User.FindFirst("roleid").Value);
        //        }

        //        return _CurrentRoleId;
        //    }
        //}

        //private string _CurrentRoleName;
        //protected string CurrentRoleName
        //{
        //    get {
        //        if (!string.IsNullOrEmpty(_CurrentRoleName))
        //        {
        //            var context = (IHttpContextAccessor)this.HttpContext.RequestServices.GetService(typeof(IHttpContextAccessor));

        //            _CurrentRoleName = context.HttpContext.User.FindFirst(ClaimTypes.Role).Value;
        //        }

        //        return _CurrentRoleName;
        //    }
        //}
    }
}
