using System;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace Bluemix.Watson
{
	

	public class EvidenceRequest
    {

        [JsonProperty("items")]
        public int Items { get; set; }

        [JsonProperty("profile")]
        public string Profile { get; set; }
    }

    public class Filter
    {

        [JsonProperty("filterType")]
        public string FilterType { get; set; }

        [JsonProperty("filterName")]
        public string FilterName { get; set; }

        [JsonProperty("values")]
        public string Values { get; set; }
    }

    public class QuestionFilters
    {

        [JsonProperty("filters")]
        public IList<Filter> Filters { get; set; }
    }


    public class Question
    {

        [JsonProperty("questionText")]
        public string QuestionText { get; set; }

        [JsonProperty("items")]
        public int Items { get; set; }

        [JsonProperty("evidenceRequest")]
		public EvidenceRequest EvidenceRequest { get; set; }

        [JsonProperty("answerAssertion")]
        public string AnswerAssertion { get; set; }

        [JsonProperty("category")]
        public string Category { get; set; }

        [JsonProperty("context")]
        public string Context { get; set; }

        [JsonProperty("formattedAnswer")]
        public bool FormattedAnswer { get; set; }

        [JsonProperty("passthru")]
        public string Passthru { get; set; }

        [JsonProperty("synonyms")]
        public string Synonyms { get; set; }

        [JsonProperty("lat")]
        public string Lat { get; set; }

        [JsonProperty("filters")]
        public QuestionFilters Filters { get; set; }
    }

	public class QAQuestion
	{
		[JsonProperty("question")]
		public Question Question;
	}

}

