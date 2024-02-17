using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UdemyCarBook.Application.Tools
{
	public class JwtTokenDefaults
	{
		public const string ValidAudiance = "https://localhost";
		public const string ValidIssuer = "https://localhost";
		public const string Key = "CarBOOK++11bookCarCarBook0321321++?aa";
		public const int Expire = 3;
	}
}
