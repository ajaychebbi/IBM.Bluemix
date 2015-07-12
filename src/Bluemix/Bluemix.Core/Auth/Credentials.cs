using System;

namespace Bluemix.Core
{
	/// <summary>
	/// Credential Class
	/// </summary>
	public class Credentials : ICredentials
	{
		

		#region ICredentials implementation
		public string UserName {
			get;
			set;
		}
		public string Password {
			get;
			set;
		}

		public string UserAgent {
			get;
			set;
		}
		#endregion

		/// <summary>
		/// Initializes a new instance of the <see cref="Bluemix.Core.Credentials"/> class.
		/// </summary>
		/// <param name="userName">User name.</param>
		/// <param name="password">Password.</param>
		public Credentials (string userName, string password)
		{
			UserName = userName;
			Password = password;
		}

	}
}

