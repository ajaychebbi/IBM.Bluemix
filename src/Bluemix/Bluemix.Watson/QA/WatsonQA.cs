using System;
using Newtonsoft.Json;
using System.Threading.Tasks;
using Bluemix.Core;
using System.Collections.Generic;
using Bluemix.Watson;

namespace Bluemix.Watson
{
	public class WatsonQA
	{
		readonly WatsonConfiguration watsonConfiguration;
		readonly WatsonClient client;

		/// <summary>
		/// Initializes a new instance of the <see cref="Bluemix.Watson.WatsonQA"/> class.
		/// </summary>
		public WatsonQA (ICredentials credentials)
		{
			watsonConfiguration = new WatsonConfiguration ();
			client = new WatsonClient (credentials);

		}

		/// <summary>
		/// Returns the list of supported Watson Q&amp;A domains
		/// </summary>
		/// <returns>The services async.</returns>
		public async Task<IList<QAService>> GetServices ()
		{
			const string apiPath = "/v1/services";
			var responseMessage = await client.GetAsync (new Request (watsonConfiguration, apiPath));
			return await Task.Run (() => JsonConvert.DeserializeObject<IList<QAService>> (responseMessage));
		}

		/// <summary>
		/// Pings the Q&mp;A service to verify that it is available
		/// </summary>
		/// <returns><c>true</c> if this instance is ping success; otherwise, <c>false</c>.</returns>
		public async Task<bool> IsPingSuccess ()
		{
			const string apiPath = "/v1/ping";
			await client.GetAsync (new Request (watsonConfiguration, apiPath));
			// No Exception
			return true;
		}

		/// <summary>
		/// Ask the specified question and type.
		/// </summary>
		/// <param name="question">Question.</param>
		/// <param name="type">Type.</param>
		public async Task<List<QAResponse>> Ask (QAQuestion question, QADatasetType type)
		{
			// currently watson supports only two types
			string datasetType = "travel";
			if (type == QADatasetType.Healthcare)
				datasetType = "healthcare";
			
			string url = string.Format ("{0}{1}{2}{3}", 
										watsonConfiguration.BasePath, 
										watsonConfiguration.ResourcePath, "/v1/question/", datasetType); 
			//var questionJson =  @"{""question"":{""questionText"":""Places to see in NYC"",""evidenceRequest"":{""items"":1}}}";//
			var questionJson = JsonConvert.SerializeObject (question, Formatting.None, new JsonSerializerSettings{ NullValueHandling = NullValueHandling.Ignore });
				
			var response = await client.PostAsync (url, questionJson).ConfigureAwait(false);
			return await Task.Run (() => JsonConvert.DeserializeObject<List<QAResponse>> (response));
		}

	}
}


    


