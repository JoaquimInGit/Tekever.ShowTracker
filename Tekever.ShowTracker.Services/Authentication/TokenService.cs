using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using Tekever.ShowTracker.Services.Dtos;
using Tekever.ShowTracker.Services.Interfaces;

namespace Tekever.ShowTracker.Services.Authentication
{
	public class TokenService : ITokenService
	{
		private const string SecurityKey = "anything_s3crEt!_go3s_here";
		private AppToken ReadAppTokenWithQueries(JwtSecurityToken jwtToken, string idQuery, string emailQuery,
		   string nameQuery, string surnameQuery, string pictureQuery)
		{
			var id = jwtToken.Claims.FirstOrDefault(x => x.Type == idQuery)?.Value;
			var email = jwtToken.Claims.FirstOrDefault(x => x.Type == emailQuery)?.Value;
			var name = jwtToken.Claims.FirstOrDefault(x => x.Type == nameQuery)?.Value;
			var surname = jwtToken.Claims.FirstOrDefault(x => x.Type == surnameQuery)?.Value;
			var picture = jwtToken.Claims.FirstOrDefault(x => x.Type == pictureQuery)?.Value;

			return new AppToken(id, email, name, surname, picture, jwtToken.ValidTo);
		}

		public Guid GoogleIdToGuid(string input)
		{
			var md5 = MD5.Create();
			byte[] hash = md5.ComputeHash(Encoding.Default.GetBytes(input));
			Guid result = new Guid(hash);
			return result;
		}

		public string WriteJwtAppToken(AppToken appToken)
		{
			var symmetricSecurityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(SecurityKey));
			var signingCredentials =
				new SigningCredentials(symmetricSecurityKey, SecurityAlgorithms.HmacSha256Signature);

			var claims = new List<Claim>
			{
				new("id", appToken.Id),
				new("name", appToken.Name),
				new("email", appToken.Email),
				new("role", "user")
				
			};

			var token = new JwtSecurityToken(
				"ShowTracker",
				expires: DateTime.Now.AddDays(1),
				signingCredentials: signingCredentials,
				claims: claims
			);

			return new JwtSecurityTokenHandler().WriteToken(token);
		}

		public AppToken ReadGoogleToken(string tokenString)
		{
			var jwtToken = new JwtSecurityTokenHandler().ReadJwtToken(tokenString);

			return ReadAppTokenWithQueries(jwtToken,
				"sub",
				"email",
				"given_name",
				"family_name",
				"picture");
		}

		public AppToken ReadAppToken(string tokenString)
		{
			var tk = tokenString.Split(' ');
			var jwtToken = new JwtSecurityTokenHandler().ReadJwtToken(tk[1]);

			return ReadAppTokenWithQueries(jwtToken,
				"id",
				"email",
				"name",
				"surname",
				"picture");
		}
	}
}

