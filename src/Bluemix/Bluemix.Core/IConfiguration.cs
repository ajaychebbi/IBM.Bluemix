using System;

namespace Bluemix.Core
{
	public interface IConfiguration
	{
		string BasePath { 
			get; set;
		}

		string ResourcePath { 
			get; set;
		}

		string ContentType { 
			get; set;
		}


	}
}

