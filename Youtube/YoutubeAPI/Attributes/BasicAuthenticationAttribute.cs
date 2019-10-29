using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Security.Principal;
using YoutubeRepository;
using YoutubeEntity.Class;

namespace YoutubeAPI.Attributes
{
    public class BasicAuthenticationAttribute : AuthorizationFilterAttribute
    {
        public override void OnAuthorization(HttpActionContext actionContext)
        {
            if(actionContext.Request.Headers.Authorization == null)
            {
                actionContext.Response = actionContext.Request.CreateResponse(HttpStatusCode.Unauthorized);
            }
            else
            {
                string encodedCredential = actionContext.Request.Headers.Authorization.Parameter;
                string decodedCredential = Encoding.UTF8.GetString(Convert.FromBase64String(encodedCredential));
                string[] arr = decodedCredential.Split(':');
                string email = arr[0];
                string password = arr[1];

                DataContext context = new DataContext();
                User user = context.Users.SingleOrDefault(u => u.Email == email && u.Password == password);
                if(user == null)
                {
                    actionContext.Response = actionContext.Request.CreateResponse(HttpStatusCode.Unauthorized);
                }
                else
                {
                    Thread.CurrentPrincipal = new GenericPrincipal(new GenericIdentity(user.Email, user.Email), new string[] { user.Email });
                }
            }
        }
    }
}