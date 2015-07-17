using System;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace Bluemix.Watson
{
	    public class Qclasslist
    {

        [JsonProperty("value")]
        public string Value { get; set; }
    }

    public class Focuslist
    {

        [JsonProperty("value")]
        public string Value { get; set; }
    }

    public class Latlist
    {

        [JsonProperty("value")]
        public string Value { get; set; }
    }

    public class MetadataMap
    {

        [JsonProperty("originalfile")]
        public string Originalfile { get; set; }

        [JsonProperty("zoom_14")]
        public string Zoom14 { get; set; }

        [JsonProperty("title")]
        public string Title { get; set; }

        [JsonProperty("corpusName")]
        public string CorpusName { get; set; }

        [JsonProperty("deepqaid")]
        public string Deepqaid { get; set; }

        [JsonProperty("fileName")]
        public string FileName { get; set; }

        [JsonProperty("DOCNO")]
        public string DOCNO { get; set; }
    }

    public class Evidencelist
    {

        [JsonProperty("value")]
        public string Value { get; set; }

        [JsonProperty("text")]
        public string Text { get; set; }

        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("title")]
        public string Title { get; set; }

        [JsonProperty("document")]
        public string Document { get; set; }

        [JsonProperty("copyright")]
        public string Copyright { get; set; }

        [JsonProperty("termsOfUse")]
        public string TermsOfUse { get; set; }

        [JsonProperty("metadataMap")]
        public MetadataMap MetadataMap { get; set; }
    }

    public class Synonym
    {

        [JsonProperty("isChosen")]
        public bool IsChosen { get; set; }

        [JsonProperty("value")]
        public string Value { get; set; }

        [JsonProperty("weight")]
        public int Weight { get; set; }
    }

    public class SynSet
    {

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("synonym")]
        public IList<Synonym> Synonym { get; set; }
    }

    public class SynonymList
    {

        [JsonProperty("partOfSpeech")]
        public string PartOfSpeech { get; set; }

        [JsonProperty("value")]
        public string Value { get; set; }

        [JsonProperty("lemma")]
        public string Lemma { get; set; }

        [JsonProperty("synSet")]
        public IList<SynSet> SynSet { get; set; }
    }

    public class ResponseEvidenceRequest
    {

        [JsonProperty("items")]
        public int Items { get; set; }

        [JsonProperty("profile")]
        public string Profile { get; set; }
    }

    public class Answer
    {

        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("text")]
        public string Text { get; set; }

        [JsonProperty("pipeline")]
        public string Pipeline { get; set; }

        [JsonProperty("formattedText")]
        public string FormattedText { get; set; }

        [JsonProperty("confidence")]
        public double Confidence { get; set; }

        [JsonProperty("entityTypes")]
        public IList<object> EntityTypes { get; set; }
    }

    public class ResponseQuestion
    {

        [JsonProperty("qclasslist")]
        public IList<Qclasslist> Qclasslist { get; set; }

        [JsonProperty("focuslist")]
        public IList<Focuslist> Focuslist { get; set; }

        [JsonProperty("latlist")]
        public IList<Latlist> Latlist { get; set; }

        [JsonProperty("evidencelist")]
        public IList<Evidencelist> Evidencelist { get; set; }

        [JsonProperty("synonymList")]
        public IList<SynonymList> SynonymList { get; set; }

        [JsonProperty("disambiguatedEntities")]
        public IList<object> DisambiguatedEntities { get; set; }

        [JsonProperty("pipelineid")]
        public string Pipelineid { get; set; }

        [JsonProperty("formattedAnswer")]
        public bool FormattedAnswer { get; set; }

        [JsonProperty("category")]
        public string Category { get; set; }

        [JsonProperty("items")]
        public int Items { get; set; }

        [JsonProperty("status")]
        public string Status { get; set; }

        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("questionText")]
        public string QuestionText { get; set; }

        [JsonProperty("evidenceRequest")]
        public ResponseEvidenceRequest EvidenceRequest { get; set; }

        [JsonProperty("answers")]
        public IList<Answer> Answers { get; set; }

        [JsonProperty("errorNotifications")]
        public IList<object> ErrorNotifications { get; set; }

        [JsonProperty("passthru")]
        public string Passthru { get; set; }
    }

    public class QAResponse
    {

        [JsonProperty("question")]
        public ResponseQuestion Question { get; set; }
    }


}

