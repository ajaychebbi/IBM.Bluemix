using System;
using Bluemix.Core;

namespace Bluemix.Watson
{
	public class WatsonConfiguration : IConfiguration
	 
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

		public WatsonConfiguration ()
		{
			BasePath = "https://gateway.watsonplatform.net";
			ResourcePath = "/question-and-answer-beta/api";

		}
	}
}

