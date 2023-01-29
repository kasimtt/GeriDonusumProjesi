using Core.Entities.Concretes;
using Core.Extensions;
using Core.Utilities.Security.Encryption;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;

namespace Core.Utilities.Security.Jwt
{
    public class JwtHelper
    {
        public IConfiguration Configuration { get; }
        private TokenOptions _tokenOptions;
        private DateTime _AccessTokenExpiration;


        public JwtHelper(IConfiguration configuration)
        {
            Configuration = configuration;
            _tokenOptions = Configuration.GetSection("TokenOptions").Get<TokenOptions>();
            _AccessTokenExpiration = DateTime.Now.AddMinutes(_tokenOptions.AccessTokenExpiration);

        }

        public AccessToken CreateAccessToken(User user,List<OperationClaim> operationClaims)
        {
            var SecurityKey = SecurityKeyHelper.CreateSecurityKey(_tokenOptions.SecurityKey);
            var SigningCredentials = SigningCredentialsHelper.CreateSigningCredentials(SecurityKey);
            var jwt = CreateJwtSecurityToken(_tokenOptions, user, SigningCredentials, operationClaims);
            var jwtSecurityTokenHandler = new JwtSecurityTokenHandler();
            var token =  jwtSecurityTokenHandler.WriteToken(jwt);

            return new AccessToken
            {
                Token = token,
                Expiration = _AccessTokenExpiration
            };
        }

        public JwtSecurityToken CreateJwtSecurityToken(TokenOptions tokenOptions,User user,SigningCredentials signingCredentials,
            List<OperationClaim> operationClaims)
        {
            var jwt = new JwtSecurityToken(
                issuer:tokenOptions.Issuer,
                audience:tokenOptions.Audience,
                claims:SetClaim(user,operationClaims),
                expires: _AccessTokenExpiration,
                notBefore:DateTime.Now,
                signingCredentials:signingCredentials
                );
            return jwt;
        }
        public IEnumerable<Claim> SetClaim(User user, List<OperationClaim> operationClaims)
        {

            var claims = new List<Claim>();
            claims.AddName($"{user.FirstName} {user.LastName}");
            claims.AddEmail(user.Email);
            claims.AddNameIdentifier(user.UserId.ToString());
            claims.AddRoles(operationClaims.Select(c => c.Name).ToArray());
            return claims;

        }
    }
}
