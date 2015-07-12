using System;

namespace Bluemix.Core
{
	public interface ICredentials
	{
		string UserName {
			get;
			set;
		}
		string Password {
			get;
			set;
		}
		string UserAgent {
			get;
			set;
		}
	}
}

