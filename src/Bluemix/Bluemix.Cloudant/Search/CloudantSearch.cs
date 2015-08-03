using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Bluemix.Core;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;


namespace Bluemix.Cloudant
{
	public  class CloudantSearch
	{
		private CloudantConfiguration cloudantConfiguration;
		private BluemixClient client;
		readonly String primaryIndexURI = "/_all_docs";
		private Datasource _ds;
		/// <summary>
		/// Initializes a new instance of the <see cref="Bluemix.Cloudant.CloudantSearch"/> class.
		/// </summary>
		/// <param name="ds">Datasource</param>
		public CloudantSearch(Datasource ds)
		{
			if (string.IsNullOrEmpty (ds.DatabaseName))
				throw new ArgumentException ("DatabaseName cannot be null or empty");
			_ds = ds;
			cloudantConfiguration = new CloudantConfiguration ();
			cloudantConfiguration.BasePath = string.Format (cloudantConfiguration.BasePath, ds.DBCredentials.UserName);
			client = new BluemixClient (ds.DBCredentials);

		}

		/// <summary>
		/// Searchs the default index by identifier.
		/// </summary>
		/// <returns>Search Result Rows.</returns>
		/// <param name="dbName">Db name.</param>
		/// <param name="SearchValue">Search value.</param>
		/// <param name="Limit">Optionally, Keep your result set to a certain size.</param>
		/// <param name="Skip">Optionally, If you want to offset your result set (for example to paginate through some rows).</param>
		public async Task<SearchResult> SearchById(String SearchValue,int Limit=-1, int Skip=-1)
		{
			String apiPath = String.Format("/{0}{1}/?keys=[\"{2}\"]",_ds.DatabaseName,primaryIndexURI,SearchValue);
			if (Limit !=-1)
				apiPath += String.Format("&limit={0}",Limit);
			if (Skip !=-1)
				apiPath += String.Format("&skip={0}",Skip);

			Request req = new Request (cloudantConfiguration, apiPath);

			var responseMessage = await client.GetAsync(req);
			SearchResult retval = JsonConvert.DeserializeObject<SearchResult>(responseMessage);
			return retval;
		}

		/// <summary>
		/// Gets the document by identifier.
		/// </summary>
		/// <returns>The doc by identifier.</returns>
		/// <param name="dbName">Db name.</param>
		/// <param name="id">id.</param>
		public async Task<JObject> GetById(String id)
		{
			String apiPath = String.Format("/{0}/{1}",_ds.DatabaseName,id);
			Request req = new Request (cloudantConfiguration, apiPath);

			var responseMessage = await client.GetAsync(req);

			JObject retval = JObject.Parse (responseMessage);
			return retval;
		}
	}
}


    


