using Newtonsoft.Json;
using RestSharp;
using RestSharp.Deserializers;
using RestSharp.Serializers;
using System.IO;

namespace UserManagementAPI.Repository
{
    public class RepositorySerializer : ISerializer, IDeserializer
    {
        private readonly Newtonsoft.Json.JsonSerializer serializer;
        public string ContentType { get; set; }
        public RepositorySerializer()
        {
            ContentType = "application/json";

            serializer = new Newtonsoft.Json.JsonSerializer
            {
                MissingMemberHandling = MissingMemberHandling.Ignore,
                NullValueHandling = NullValueHandling.Include,
                DefaultValueHandling = DefaultValueHandling.Include,
                DateFormatHandling = DateFormatHandling.IsoDateFormat,
                DateTimeZoneHandling = DateTimeZoneHandling.Unspecified
            };
        }
        public RepositorySerializer(Newtonsoft.Json.JsonSerializer serializer)
        {
            ContentType = "application/json";
            this.serializer = serializer;
        }
     
        public T Deserialize<T>(IRestResponse response)
        {
            var content = response.Content;

            using (var stringReader = new StringReader(content))
            {
                using (var jsonTextReader = new JsonTextReader(stringReader))
                {
                    return this.serializer.Deserialize<T>(jsonTextReader);
                }
            }
        }

        public string Serialize(object obj)
        {
            using (var stringWriter = new StringWriter())
            {
                using (var jsonTextWriter = new JsonTextWriter(stringWriter))
                {
                    jsonTextWriter.Formatting = Formatting.Indented;
                    jsonTextWriter.QuoteChar = '"';

                    serializer.Serialize(jsonTextWriter, obj);

                    var result = stringWriter.ToString();
                    return result;
                }
            }
        }

        //public string DateFormat { get; set; }
        //public string RootElement { get; set; }
        //public string Namespace { get; set; }
        //public string ContentType { get; set; }
    }
}
