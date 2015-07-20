using System;
using System.Collections.Generic;
using System.Text;

namespace Bluemix.Core
{
	/// <summary>
	/// Request Class
	/// </summary>
	public class Request
	{
		/// <summary>
		/// Gets or sets the request parameters.
		/// </summary>
		/// <value>The request parameters.</value>
		public IDictionary<string,string> RequestParameters {
			get;
			internal set;
		}

		/// <summary>
		/// Gets the fully qualified URL with query string.
		/// </summary>
		/// <value>The full URL.</value>
		public string FullUrl {
			get{ 
				var queryString = this.QueryString;
				if (queryString.Length > 0)
					return string.Format ("{0}?{1}", Endpoint, QueryString);
				return Endpoint;
						
			}

		}

		/// <summary>
		/// Gets the HTTP endpoint.
		/// </summary>
		/// <value>The endpoint.</value>
		public string Endpoint {
			get;
			private set;
		}

		/// <summary>
		/// Gets the query string.
		/// </summary>
		/// <value>The query string.</value>
		public string QueryString {
			get{
				return BuildQueryString (RequestParameters);
			}
		}

		public string ContentType {
			get;
			set;
		}
		public int Timeout { 
			get;
			set; 
		}


		/// <summary>
		/// Initializes a new instance of the <see cref="Bluemix.Core.Request"/> class.
		/// </summary>
		/// <param name="configuration">Configuration.</param>
		/// <param name = "apiPath"></param>
		public Request (IConfiguration configuration, string apiPath)
		{
			if (configuration == null)
				throw new ArgumentNullException("configuration");
			if (string.IsNullOrEmpty (configuration.BasePath))
				throw new ArgumentException ("configuration.BasePath cannot be null or empty");
			//if (string.IsNullOrEmpty (configuration.ResourcePath))
			//	throw new ArgumentException ("configuration.ResourcePath cannot be null or empty");
			
			if (string.IsNullOrEmpty (apiPath))
				throw new ArgumentException ("apiPath cannot be null or empty");
			
			string endpoint = string.Format("{0}{1}{2}", configuration.BasePath, configuration.ResourcePath, apiPath);
			Endpoint = endpoint;
			RequestParameters = new Dictionary<string, string> ();
		}

		private string BuildQueryString(IDictionary<string, string> requestParameters)
		{
			if (requestParameters == null)
				throw new ArgumentNullException("requestParameters");

			StringBuilder builder = new StringBuilder();
			foreach (var pair in requestParameters)
			{
				builder.Append(pair.Key);
				builder.Append('=');
				builder.Append(pair.Value);
				builder.Append('&');
			}

			if (builder.Length > 1)
				builder.Length--; 

			return builder.ToString();
		}
	}
}

