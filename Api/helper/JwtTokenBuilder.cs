using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using Microsoft.IdentityModel.Tokens;

namespace Api.helper
{
    public sealed class JwtTokenBuilder
    {
        private SecurityKey securityKey = null;
        //private string Key = "";
        //private string subject = "";
        //private string issuer = "";
        //private string audience = "";
        //private string nameId = "";
        private Dictionary<string, string> claims = new Dictionary<string, string>();
        private int expiryInMinutes = 5;

        public JwtTokenBuilder AddSecurityKey(SecurityKey securityKey)
        {
            this.securityKey = securityKey;
            return this;
        }

        //public JwtTokenBuilder AddSecurityKey(string key)
        //{
        //    this.Key = key;
        //    return this;
        //}

        //public JwtTokenBuilder AddSubject(string subject)
        //{
        //    this.subject = subject;
        //    return this;
        //}

        //public JwtTokenBuilder AddIssuer(string issuer)
        //{
        //    this.issuer = issuer;
        //    return this;
        //}

        //public JwtTokenBuilder AddAudience(string audience)
        //{
        //    this.audience = audience;
        //    return this;
        //}

        //public JwtTokenBuilder AddNameId(string nameId)
        //{
        //    this.nameId = nameId;
        //    return this;
        //}

        public JwtTokenBuilder AddClaim(string type, string value)
        {
            this.claims.Add(type, value);
            return this;
        }

        //public JwtTokenBuilder AddClaims(Dictionary<string, string> claims)
        //{
        //    this.claims.Union(claims);
        //    return this;
        //}

        public JwtTokenBuilder AddExpiry(int expiryInMinutes)
        {
            this.expiryInMinutes = expiryInMinutes;
            return this;
        }

        public string Build()
        {
            var claims = new List<Claim>
            {
              //new Claim(JwtRegisteredClaimNames.Sub, this.subject),
              //new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
              //new Claim("NameId", this.nameId)
            }
            .Union(this.claims.Select(item => new Claim(item.Key, item.Value)));

            var token = new JwtSecurityToken(
                              //issuer: this.issuer,
                              //audience: this.audience,
                              expires: DateTime.UtcNow.AddMinutes(expiryInMinutes),
                              claims: claims,
                              signingCredentials: new SigningCredentials(
                                                        this.securityKey,
                                                        SecurityAlgorithms.HmacSha256));

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}