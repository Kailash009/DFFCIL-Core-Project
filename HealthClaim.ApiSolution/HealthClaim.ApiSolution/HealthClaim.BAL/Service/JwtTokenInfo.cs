using HealthClaim.BAL.Service;
using HealthClaim.Model.Dtos.JwtInfo;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace HealthClaim.BAL.Service
{
    public class JwtTokenInfo
    {
        public JwtTokenInfoModel ReadTokenFromHeader(HttpRequest request)
        {
            // Read the JWT token from the HTTP request header
            string jwtToken = request.Headers["Authorization"];

            if (!string.IsNullOrEmpty(jwtToken) && jwtToken.StartsWith("Bearer "))
            {
                jwtToken = jwtToken.Substring("Bearer ".Length);

                // Process the token
                return ReadToken(jwtToken);
            }

            // Return null if no valid token is found
            return null;
        }

        public JwtTokenInfoModel ReadToken(string jwtToken)
        {
            try
            {
                var tokenHandler = new JwtSecurityTokenHandler();
                var token = tokenHandler.ReadJwtToken(jwtToken);
                var claims = token.Claims;

                return new JwtTokenInfoModel
                {
                    EmpId = token.Issuer,
                    Email = GetClaimValue(claims, "email"),
                    // Add other properties here
                };
            }
            catch (Exception)
            {
                return null;
            }
        }

        private static string GetClaimValue(IEnumerable<Claim> claims, string claimType)
        {
            var claim = claims.FirstOrDefault(c => c.Type == claimType);
            return claim?.Value;
        }
    }
}


/*
 * Example to use the above code 
 * 
 * 
using Microsoft.AspNetCore.Mvc;

public class YourController : Controller
{
    public IActionResult YourAction()
    {
        // Access the HttpRequest object
        var request = HttpContext.Request;

        // You can now use 'request' to access the HTTP request, including headers, query parameters, and more.
        // For example, you can pass 'request' to the JwtTokenInfo class:

        JwtTokenInfo jwtTokenInfo = new JwtTokenInfo();
        JwtTokenInfoModel tokenInfo = jwtTokenInfo.ReadTokenFromHeader(request);

        if (tokenInfo != null)
        {
            // You can access the token information and return it in your model
            YourModel model = new YourModel
            {
                Subject = tokenInfo.Subject,
                Email = tokenInfo.Email,
                // Set other properties in your model
            };
            return View(model);
        }
        else
        {
            // Handle the case where the token is missing or invalid
            return Unauthorized(); // Or another appropriate response
        }
    }*/

