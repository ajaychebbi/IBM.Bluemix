using System;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace Bluemix.Cloudant
{
	/// <summary>
	/// Search result of a Cloudant search
	/// </summary>
	public class SearchResult
	{
		[JsonProperty("total_rows")]
		public long TotalRows { get; set; }

		[JsonProperty("offset")]
		public long Offset { get; set; }

		[JsonProperty("rows")]
		public IList<ResultRow> ResultRows { get; set;}

	}

	public class ResultRow
	{

		[JsonProperty("id")]
		public string Id { get; set; }

		[JsonProperty("key")]
		public string Key { get; set; }

		[JsonProperty("value")]
		public JsonObjectAttribute Value { get; set; }
	}
}

