using System;
using System.Threading.Tasks;
using System.Net.Http;
using System.Net;

using System.Text;
using System.Net.Http.Headers;


namespace Bluemix.Core
{
	/// <summary>
	/// Bluemix client.
	/// </summary>
	public class BluemixClient
	{
		internal const string DefaultUserAgent = "Bluemix-net-client/0.1";
		internal const string DefaultContentType = "application/json";

		public ICredentials Credentials {
			get;
			set;
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="Bluemix.Core.WatsonClient"/> class.
		/// </summary>
		/// <param name="credentials">Credentials.</param>
		public BluemixClient (ICredentials credentials)
		{
			if (credentials == null)
				throw new ArgumentNullException ("credentials");
			Credentials = credentials;
			Credentials.UserAgent = Credentials.UserAgent ?? DefaultUserAgent;
		}
			
		/// <summary>
		/// Gets the async.
		/// </summary>
		/// <returns>The async.</returns>
		/// <param name="request">Request.</param>
		public async Task<string> GetAsync (Request request)
		{
			//TODO: Handle HTTP Errors
			HttpRequestMessage requestMessage = new HttpRequestMessage (HttpMethod.Get, new Uri (request.FullUrl));
			requestMessage.Headers.Add ("Authorization", GetCredentialString ());
			using (var client = new HttpClient ()) {
				client.DefaultRequestHeaders.Accept.Clear ();
				client.DefaultRequestHeaders.Accept.Add (new MediaTypeWithQualityHeaderValue (request.ContentType ?? DefaultContentType));
				if (request.Timeout != 0)
					client.Timeout = new TimeSpan (0, 0, 0, request.Timeout);
				
				var response = await client.SendAsync (requestMessage).ConfigureAwait (false);

				return await HandleResponseAsync (response);
			}
		}

		/// <summary>
		/// Posts the async.
		/// </summary>
		/// <returns>The async.</returns>
		/// <param name="url">Post Url.</param>
		/// <param name="postData">Post data.</param>
		public async Task<string> PostAsync (string url, string postData)
		{
			//TODO: Handle HTTP Errors
			using (var client = new HttpClient ()) {
				client.DefaultRequestHeaders.Accept.Clear ();
				client.DefaultRequestHeaders.Accept.Add (new MediaTypeWithQualityHeaderValue (DefaultContentType));
				client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue ("Basic", GetBase64CredentialString ());
				var response = await client.PostAsync (url, new StringContent (postData, Encoding.UTF8, DefaultContentType)).ConfigureAwait (false);
				return await HandleResponseAsync (response);
			}
		}

		async Task<string> HandleResponseAsync (HttpResponseMessage response)
		{
			return await response.Content.ReadAsStringAsync ().ConfigureAwait (false);
		}

		private string GetCredentialString ()
		{
			return string.Format ("{0} {1}", "Basic", GetBase64CredentialString ());
		}

		private string GetBase64CredentialString ()
		{
			var auth = string.Format ("{0}:{1}", Credentials.UserName, Credentials.Password);
			return Convert.ToBase64String (Encoding.UTF8.GetBytes (auth));
			//return auth;

		}
	}
}

