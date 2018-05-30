using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using System.Web.Http.Controllers;

namespace EventPublisherBLL
{
    public class CustomAuthorize : AuthorizeAttribute
    {
        protected override bool IsAuthorized(HttpActionContext actionContext)
        {
            
            if (actionContext.Request.Headers.GetValues("Token") != null)
            {
                try
                {
                    // get value from header
                    string authenticationToken = Convert.ToString(
                      actionContext.Request.Headers.GetValues("Token").FirstOrDefault());

                    string tokenDecoded = Crypto.Base64Decode(authenticationToken);

                    string[] tokenArray = tokenDecoded.ToString().Split('^');
                    string firstPartTocken = Crypto.CreateMD5(tokenArray[0]);

                    if (firstPartTocken == tokenArray[1])
                    {
                        return true;
                    }
                    else
                    {
                        return false;

                    }
                }
                catch
                {
                    return false;
                }
               
            }
            else
            {                
                return false;
            }
           
        }

       
    }
}
