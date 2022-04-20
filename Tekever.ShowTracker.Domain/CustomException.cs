using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tekever.ShowTracker.Domain
{
	public class CustomException : Exception
	{
		public int ErrorCode { get; set; }

		public CustomException(int error, string message) : base(message)
		{
			ErrorCode = error;
		}
	}
}
