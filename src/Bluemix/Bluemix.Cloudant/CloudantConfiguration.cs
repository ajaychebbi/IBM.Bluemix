using System;
using Bluemix.Core;

namespace Bluemix.Cloudant
{
	public class CloudantConfiguration : IConfiguration
	 
	{
		#region IConfiguration implementation

		public string BasePath {
			get;
			set;
		}

		public string ResourcePath {
			get;
			set;
		}

		public string ContentType {
			get;
			set;
		}


		#endregion

		public CloudantConfiguration ()
		{
			//The basepath has the userID in the URL.
			BasePath = "https://{0}.cloudant.com";
			//there is no fixed resource path concept for cloudant... 
			ResourcePath = "";

		}
	}
}

