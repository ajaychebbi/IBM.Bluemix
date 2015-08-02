using System;
using Bluemix.Cloudant;
using Bluemix.Core;
using Newtonsoft.Json.Linq;
using NUnit.Framework;

namespace Bluemix.Tests
{
	[TestFixture ()]
	public class CloudantSearchTest
	{


		[Test ()]
		public async void CloudantGetByIDSuccess ()
		{
			String testID = "achebbi";
			var testDbUser = "ef1aea84-f83d-4b47-83da-01a77e7dbcf0-bluemix";
			var testDbPassword = "2477e8dab7c40472a277ebb03247e1e468cbcd86649ff011cb948b8eadb97e3c";
			var testDbName = "people";

			var ds= new Datasource (testDbName, 
											new Credentials (userName: testDbUser,
				             				password: testDbPassword));
			
			JObject retval = await ds.Search.GetById (testID);
			Assert.NotNull (retval.GetValue("_id"));
			StringAssert.IsMatch(testID,retval.GetValue ("_id").ToString ());
		}

		[Test ()]
		public async void CloudantGetByIDFailure ()
		{
			String testID = "foo";
			var testDbUser = "ef1aea84-f83d-4b47-83da-01a77e7dbcf0-bluemix";
			var testDbPassword = "2477e8dab7c40472a277ebb03247e1e468cbcd86649ff011cb948b8eadb97e3c";
			var testDbName = "people";

			var ds = new Datasource (testDbName, 
				new Credentials (userName: testDbUser,
					password: testDbPassword));
			JObject retval = await ds.Search.GetById (testID);
			Assert.NotNull (retval.GetValue("error"));
			StringAssert.IsMatch("not_found",retval.GetValue ("error").ToString ());
		}

		[Test ()]
		public async void CloudantSearchByIDSuccess ()
		{
			String testID = "achebbi";
			var testDbUser = "ef1aea84-f83d-4b47-83da-01a77e7dbcf0-bluemix";
			var testDbPassword = "2477e8dab7c40472a277ebb03247e1e468cbcd86649ff011cb948b8eadb97e3c";
			var testDbName = "people";

			var ds = new Datasource (testDbName, 
							new Credentials (userName: testDbUser,
							password: testDbPassword));
			SearchResult retval = await ds.Search.SearchById(testID);

			Assert.NotNull (retval);
			StringAssert.IsMatch(testID,retval.Rows[0].Id);
		}

		[Test ()]
		public async void CloudantSearchByIDFailure ()
		{
			String testID = "foo";
			var testDbUser = "ef1aea84-f83d-4b47-83da-01a77e7dbcf0-bluemix";
			var testDbPassword = "2477e8dab7c40472a277ebb03247e1e468cbcd86649ff011cb948b8eadb97e3c";
			var testDbName = "people";

			var ds = new Datasource (testDbName, 
				new Credentials (userName: testDbUser,
					password: testDbPassword));
			SearchResult retval = await ds.Search.SearchById(testID);

			Assert.NotNull (retval);
			StringAssert.IsMatch ("not_found", retval.Rows[0].Error);

		}
	}
}

