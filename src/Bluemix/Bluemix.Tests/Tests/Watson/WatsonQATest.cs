using System;
using NUnit.Framework;
using Bluemix.Watson;
using Bluemix.Core;

namespace Bluemix.Tests
{
	[TestFixture ()]
	public class WatsonQATest
	{
		[Test ()]
		public async void WatsonQAServiceSuccess ()
		{
			var wqa = new WatsonQA (new Credentials (userName: "9f8a37cf-a0ce-41b6-a2ad-87d6e5392db1",
				password: "6BAHrlmMBFlT"));

			var responseMessage = await wqa.GetServicesAsync ();

			Assert.NotNull (responseMessage);
		}

		[Test ()]
		public async void WatsonQAIsPingSuccess ()
		{
			var wqa = new WatsonQA (new Credentials (userName: "9f8a37cf-a0ce-41b6-a2ad-87d6e5392db1",
				password: "6BAHrlmMBFlT"));

			var responseMessage = await wqa.IsPingSuccess ();

			Assert.IsTrue (responseMessage);
		}

		[Test ()]
		public async void WatsonQAAskSuccess ()
		{

			var wqa = new WatsonQA (new Credentials (userName: "9f8a37cf-a0ce-41b6-a2ad-87d6e5392db1",
				password: "6BAHrlmMBFlT"));

			var responseMessage = await wqa.Ask (new QAQuestion{ Question= new Question{ QuestionText="How big is Africa?", Items =1 } }, QADatasetType.Travel);

			Assert.NotNull (responseMessage.Answers.Answers.Count > 0);
		}
	}
}

