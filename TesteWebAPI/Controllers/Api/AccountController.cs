using System;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using TesteWebAPI.Models;

namespace TesteWebAPI.Controllers.Api
{
    public class AccountController : ApiController
    {
        string secretKey = "jMzqCu2RbRGZQfgluxyy";

        [HttpGet]
        public string GetToken()
        {
            return GerarToken();
        }

        [HttpGet]
        public string TesteTokenHeader()
        {
            var header = Request.Headers.GetValues("Authorization");
            var token = header.First().ToString().Replace("Bearer ", string.Empty);

            return TesteToken(token);
        }

        private string TesteToken(string tokenHeader)
        {
            try
            {
                string token = "eyJ0eXAiOiJKV1QiLCJhbGciOiJIUzI1NiJ9.eyJ1c2VybmFtZSI6Imx1Y2FzIiwiZGF0ZXRpbWUiOiIyNS8wMS8yMDE4IDA5OjIwOjMxIn0.WFnQZuEEtINvy9_L8TY9Ed3VIokCqp5ExttMZcawM8o";
                var secretKey = "jMzqCu2RbRGZQfgluxyy";

                string teste = JWT.JsonWebToken.Decode(token, secretKey, true);

                string token2 = GerarToken();
                var userToken = JWT.JsonWebToken.DecodeToObject<UserToken>(token2, secretKey, true);

                var userTokenHeader = JWT.JsonWebToken.DecodeToObject<UserToken>(tokenHeader, secretKey, true);

                return "ok";
            }
            catch (Exception ex)
            {
                return "erro";
            }
        }

        private string GerarToken()
        {

            UserToken userToken = new UserToken
            {
                UserName = "lucas.veiga",
                Senha = "123456",
                Data = DateTime.Now
            };

            string token = JWT.JsonWebToken.Encode(userToken, secretKey, JWT.JwtHashAlgorithm.HS256);
            return token;
        }

        #region Teste API

        [HttpPost]
        public string Authenticate([FromBody] UserTeste userTeste)
        {
            return GerarToken();
        }

        [HttpGet]
        public HttpResponseMessage Me()
        {
            try
            {
                var header = Request.Headers.GetValues("Authorization");
                var token = header.First().ToString().Replace("Bearer ", string.Empty);

                var userTokenHeader = JWT.JsonWebToken.DecodeToObject<UserToken>(token, secretKey, true);

                var retorno = new UserTeste
                {
                    Email = userTokenHeader.UserName,
                    Password = userTokenHeader.Senha
                };

                return Request.CreateResponse(HttpStatusCode.OK, retorno);
            }
            catch (Exception)
            {
                var message = string.Format("Usuário não autenticado");
                return Request.CreateErrorResponse(HttpStatusCode.Unauthorized, message);
            }
        }


        #endregion
    }
}
