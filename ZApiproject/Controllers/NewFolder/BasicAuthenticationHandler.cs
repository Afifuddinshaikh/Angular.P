using Microsoft.AspNetCore.Authentication;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.Extensions.Options;
using System.Net.Http.Headers;
using System.Security.Claims;
using System.Text;
using System.Text.Encodings.Web;
using ZApiproject.Models;

namespace ZApiproject.Controllers.NewFolder
{
    public class BasicAuthenticationHandler : AuthenticationHandler<AuthenticationSchemeOptions>
    {
        private readonly EmployeeContext _context;
        public BasicAuthenticationHandler(
            IOptionsMonitor<AuthenticationSchemeOptions> options,
            ILoggerFactory logger,
            UrlEncoder encoder,
            ISystemClock clock)
            : base(options, logger, encoder, clock)
        {
            _context = Context;
        }

        protected override async Task<AuthenticateResult> HandleAuthenticateAsync()
        {
            if (!Request.Headers.ContainsKey("Authorization"))
                return AuthenticateResult.Fail("fail to found");
            try
            {
                var authenticationHeadervalue = AuthenticationHeaderValue.Parse(Request.Headers["authorize"]);
                var bytes = Convert.FromBase64String(authenticationHeadervalue.Parameter);
                string[] Credential = Encoding.UTF8.GetString(bytes).Split(":");
                string emailAddres = Credential[0];
                string password = Credential[1];
                User user = _context.Users.Where(user => user.EmailAddress == emailAddres && user.Password == password).FirstOrDefault();
                if (user == null)
                         AuthenticateResult.Fail("Invalid");
                else
                {
                    var claims = new[] {new Claim(ClaimTypes.Name,user.EmailAddress)};
                    var identity = new ClaimsIdentity(claims,Scheme.Name);
                    var principle = new ClaimsPrincipal(new ClaimsIdentity());
                    var ticket=new AuthenticationTicket(principle,Scheme.Name);

                    AuthenticateResult.Success(ticket);


                }

                
                
            }
            catch (Exception ) 
            {
                return AuthenticateResult.Fail("need to implement");

            }

            return AuthenticateResult.Fail("");
        
        }
        
       
    }
}