using System;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace Bluemix.Watson
{
	public class Evidence
    {

        [JsonProperty("copyright")]
        public string Copyright { get; set; }

        [JsonProperty("document")]
        public string Document { get; set; }

        [JsonProperty("termsOfUse")]
        public string TermsOfUse { get; set; }

        [JsonProperty("text")]
        public string Text { get; set; }

        [JsonProperty("title")]
        public string Title { get; set; }
    }

    public class FeatureGroup
    {

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("value")]
        public string Value { get; set; }
    }

    public class EvidenceProfile
    {

        [JsonProperty("featureGroup")]
        public IList<FeatureGroup> FeatureGroup { get; set; }
    }

    public class Answer
    {

        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("text")]
        public string Text { get; set; }

        [JsonProperty("confidence")]
        public string Confidence { get; set; }

        [JsonProperty("evidence")]
        public IList<Evidence> Evidence { get; set; }

        [JsonProperty("evidenceProfile")]
        public IList<EvidenceProfile> EvidenceProfile { get; set; }

        [JsonProperty("formattedText")]
        public string FormattedText { get; set; }
    }

    public class ResponseAnswers
    {

        [JsonProperty("answers")]
        public IList<Answer> Answers { get; set; }
    }

    public class ErrorNotification
    {

        [JsonProperty("error")]
        public string Error { get; set; }

        [JsonProperty("text")]
        public string Text { get; set; }
    }

    public class EvidenceList
    {

        [JsonProperty("copyright")]
        public string Copyright { get; set; }

        [JsonProperty("metadataMap")]
        public string MetadataMap { get; set; }

        [JsonProperty("termsOfUse")]
        public string TermsOfUse { get; set; }

        [JsonProperty("text")]
        public string Text { get; set; }

        [JsonProperty("title")]
        public string Title { get; set; }

        [JsonProperty("document")]
        public string Document { get; set; }

        [JsonProperty("value")]
        public string Value { get; set; }
    }

    public class SynonymList
    {

        [JsonProperty("term")]
        public string Term { get; set; }

        [JsonProperty("synSet")]
        public string SynSet { get; set; }

        [JsonProperty("synonym")]
        public string Synonym { get; set; }
    }

	public class QAResponse
    {

        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("answers")]
        public ResponseAnswers Answers { get; set; }

        [JsonProperty("category")]
        public string Category { get; set; }

        [JsonProperty("errorNotifications")]
        public IList<ErrorNotification> ErrorNotifications { get; set; }

        [JsonProperty("evidenceList")]
        public IList<EvidenceList> EvidenceList { get; set; }

        [JsonProperty("focusList")]
        public string FocusList { get; set; }

        [JsonProperty("latList")]
        public string LatList { get; set; }

        [JsonProperty("pipelineid")]
        public string Pipelineid { get; set; }

        [JsonProperty("qclasslist")]
        public string Qclasslist { get; set; }

        [JsonProperty("status")]
        public string Status { get; set; }

        [JsonProperty("supplemental")]
        public string Supplemental { get; set; }

        [JsonProperty("synonymList")]
        public IList<SynonymList> SynonymList { get; set; }
    }


}

