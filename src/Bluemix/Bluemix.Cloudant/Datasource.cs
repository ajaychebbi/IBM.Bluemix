using System;
using Bluemix.Core;

namespace Bluemix.Cloudant
{
	public class Datasource
	{
		private string _dbName;
		private ICredentials _creds;
		private CloudantSearch _search;
		public Datasource (string dbname,ICredentials creds)
		{
			_dbName= dbname;
			_creds= creds;
			_search = new CloudantSearch(this);

		}
		public string DatabaseName { get { return _dbName; } }
		public ICredentials DBCredentials { get { return _creds; } }
		public CloudantSearch Search { get { return _search; } }
	}
}

