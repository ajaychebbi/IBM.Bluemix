using System;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace Bluemix.Watson
{
	public class QAService
	{

		[JsonProperty("overall")]
		public int Overall { get; set; }

		[JsonProperty("dataset")]
		public string Dataset { get; set; }

		[JsonProperty("name")]
		public string Name { get; set; }

		[JsonProperty("description")]
		public string Description { get; set; }
	}


}

