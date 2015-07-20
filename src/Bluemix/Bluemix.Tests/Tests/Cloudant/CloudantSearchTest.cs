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
		public async void CloudantGetByID ()
		{
			String testID = "achebbi";
			var testDbUser = "ef1aea84-f83d-4b47-83da-01a77e7dbcf0-bluemix";
			var testDbPassword = "2477e8dab7c40472a277ebb03247e1e468cbcd86649ff011cb948b8eadb97e3c";
			var testDbName = "people";

			var search = new CloudantSearch (new Credentials (userName: testDbUser,
				             password: testDbPassword));
			JObject retval = await search.GetById (testDbName, testID);
			Assert.NotNull (retval.GetValue("_id"));
			StringAssert.IsMatch(testID,retval.GetValue ("_id").ToString ());
		}
	}
}

