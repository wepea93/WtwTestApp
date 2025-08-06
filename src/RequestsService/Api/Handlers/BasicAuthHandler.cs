using Microsoft.AspNetCore.Authentication;
using Microsoft.Extensions.Options;
using System.Text.Encodings.Web;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;
using System.Linq;
using System;
using System.Text;
using System.Net.Http.Headers;

namespace RequestsService.Api.Handlers
{
    public class BasicAuthHandler : AuthenticationHandler<AuthenticationSchemeOptions>
    {
        private readonly IConfiguration _configuration;

        public BasicAuthHandler(
            IOptionsMonitor<AuthenticationSchemeOptions> options,
            ILoggerFactory logger,
            UrlEncoder encoder,
            IConfiguration configuration)
            : base(options, logger, encoder)
        {
            _configuration = configuration;
        }

        protected override Task<AuthenticateResult> HandleAuthenticateAsync()
        {
            if (!Request.Headers.ContainsKey("Authorization"))
                return Task.FromResult(AuthenticateResult.Fail("Missing Authorization Header"));

            try
            {
                var authHeader = AuthenticationHeaderValue.Parse(Request.Headers["Authorization"]!);
                if (authHeader.Parameter == null)
                {
                    return Task.FromResult(AuthenticateResult.Fail("Invalid Authorization Header"));
                }
                var credentialBytes = Convert.FromBase64String(authHeader.Parameter);
                var credentials = Encoding.UTF8.GetString(credentialBytes).Split(new[] { ':' }, 2);
                var username = credentials[0];
                var password = credentials[1];

                var expectedUsername = _configuration["BasicAuth:Username"];
                var expectedPassword = _configuration["BasicAuth:Password"];

                if (username == expectedUsername && password == expectedPassword)
                {
                    var claims = new[] { new System.Security.Claims.Claim("Username", username) };
                    var identity = new System.Security.Claims.ClaimsIdentity(claims, Scheme.Name);
                    var principal = new System.Security.Claims.ClaimsPrincipal(identity);
                    var ticket = new AuthenticationTicket(principal, Scheme.Name);

                    return Task.FromResult(AuthenticateResult.Success(ticket));
                }
            }
            catch
            {
                return Task.FromResult(AuthenticateResult.Fail("Invalid Authorization Header"));
            }

            return Task.FromResult(AuthenticateResult.Fail("Invalid Username or Password"));
        }
    }
}