using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Bluemix.Core;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;


namespace Bluemix.Cloudant
{
	public class CloudantSearch
	{
		readonly CloudantConfiguration cloudantConfiguration;
		readonly BluemixClient client;
		readonly String primaryIndexURI = "/_all_docs";

		/// <summary>
		/// Initializes a new instance of the <see cref="Bluemix.Cloudant.CloudantSearch"/> class.
		/// </summary>
		/// <param name="credentials">Credentials.</param>
		public CloudantSearch (ICredentials credentials)
		{
			cloudantConfiguration = new CloudantConfiguration ();
			cloudantConfiguration.BasePath = string.Format (cloudantConfiguration.BasePath, credentials.UserName);
			client = new BluemixClient (credentials);

		}

		/// <summary>
		/// Searchs the default index by identifier.
		/// </summary>
		/// <returns>The doc by identifier.</returns>
		/// <param name="dbName">Db name.</param>
		/// <param name="searchValue">Search value.</param>
//		public async Task<JObject> SearchById(String dbName,String searchValue)
//		{
//			//TODO:return a better JSON object
//			String apiPath = String.Format("/{0}{1}/?keys=[\"{2}\"]",dbName,primaryIndexURI,searchValue);
//			Request req = new Request (cloudantConfiguration, apiPath);
//
//			var responseMessage = await client.GetAsync(req);
//			JObject retval = JObject.Parse (responseMessage);
//			return retval;
//		}
		/// <summary>
		/// Gets the document by identifier.
		/// </summary>
		/// <returns>The doc by identifier.</returns>
		/// <param name="dbName">Db name.</param>
		/// <param name="searchValue">id.</param>
		public async Task<JObject> GetById(String dbName,String id)
		{
			String apiPath = String.Format("/{0}/{1}",dbName,id);
			Request req = new Request (cloudantConfiguration, apiPath);

			var responseMessage = await client.GetAsync(req);

			JObject retval = JObject.Parse (responseMessage);
			return retval;
		}
	}
}


    


