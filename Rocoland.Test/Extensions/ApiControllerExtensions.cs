using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;
using Moq;
using Rocoland.Controllers;
using Rocoland.Repositories;

namespace Rocoland.Test.Extensions
{
    public static class ApiControllerExtensions
    {
        public static void MockCurrentUser(this ApiController apiController,string username,string userid)
        {
            var identity = new GenericIdentity(username);

            identity.AddClaim(new Claim("http://schemas.xmlsoap.org/ws/2005/05/identity/claims/name", username));
            identity.AddClaim(new Claim("http://schemas.xmlsoap.org/ws/2005/05/identity/claims/nameidentifier", userid));

            var principal = new GenericPrincipal(identity, null);
            
            apiController.User = principal;
        }
    }
}
