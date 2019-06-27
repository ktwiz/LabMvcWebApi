using LabMvcWebApi.Models;
using LabMvcWebApi.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace LabMvcWebApi.Controllers
{
    public class AuthenticateController : ApiController
    {
        IAuth _IAuthenticate = null;
        public AuthenticateController()
        {
            _IAuthenticate = new AuthApp();
        }

        // POST: api/Authenticate
        public HttpResponseMessage Authenticate([FromBody]ClientKey ClientKeys)
        {
            if (string.IsNullOrEmpty(ClientKeys.Client_Id) && string.IsNullOrEmpty(ClientKeys.Client_Secret))
            {
                var message = new HttpResponseMessage(HttpStatusCode.NotAcceptable);
                message.Content = new StringContent("Not Valid Request");
                return message;
            }
            else
            {
                if (_IAuthenticate.ValidateKeys(ClientKeys))
                {
                    var clientkeys = _IAuthenticate.GetClientKeysDetailsbyCLientIDandClientSecert(ClientKeys.Client_Id, ClientKeys.Client_Secret);

                    if (clientkeys == null)
                    {
                        var message = new HttpResponseMessage(HttpStatusCode.NotFound);
                        message.Content = new StringContent("InValid Keys");
                        return message;
                    }
                    else
                    {
                        if (_IAuthenticate.IsTokenAlreadyExists(clientkeys.Company_code))
                        {
                            _IAuthenticate.DeleteGenerateToken(clientkeys.Company_code);

                            return GenerateandSaveToken(clientkeys);
                        }
                        else
                        {
                            return GenerateandSaveToken(clientkeys);
                        }
                    }
                }
                else
                {
                    var message = new HttpResponseMessage(HttpStatusCode.NotFound);
                    message.Content = new StringContent("InValid Keys");
                    return new HttpResponseMessage { StatusCode = HttpStatusCode.NotAcceptable };
                }
            }
        }


        [NonAction]
        private HttpResponseMessage GenerateandSaveToken(ClientKey clientkeys)
        {
            var IssuedOn = DateTime.Now;
            var newToken = _IAuthenticate.GenerateToken(clientkeys, IssuedOn);
            TokensManager token = new TokensManager();
            token.TokenID = 0;
            token.TokenKey = newToken;
            token.CompanyCode = clientkeys.Company_code;
            token.IssuedOn = IssuedOn;
            token.ExpiresOn = DateTime.Now.AddMinutes(10);
            token.CreatedOn = DateTime.Now;
            var result = _IAuthenticate.InsertToken(token);

            if (result == 0)
            {
                HttpResponseMessage response = new HttpResponseMessage();
                response = Request.CreateResponse(HttpStatusCode.OK, "Authorized");
                response.Headers.Add("Token", newToken);
                response.Headers.Add("TokenExpiry", "10");
                response.Headers.Add("Access-Control-Expose-Headers", "Token,TokenExpiry");
                return response;
            }
            else
            {
                var message = new HttpResponseMessage(HttpStatusCode.NotAcceptable);
                message.Content = new StringContent("Error in Creating Token");
                return message;
            }
        }
    }
}
