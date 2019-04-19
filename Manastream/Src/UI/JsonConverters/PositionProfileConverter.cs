namespace Manastream.Src.UI.JsonConverters
{
    #region Usings

    using Manastream.Src.UI.PositionProfiles;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Linq;
    using System;

    #endregion

    /// <summary>
    /// The position profile converter that enables the deserialisation of position profiles.
    /// </summary>
    public class PositionProfileConverter : JsonConverter
    {
        #region Methods

        public override bool CanConvert(Type objectType)
        {
            return objectType == typeof(IPositionProfile);
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            object result = null;

            JObject jobj = JObject.Load(reader);

            switch (jobj["type"].Value<string>())
            {
                case "RelativePositionProfile":
                    result = JsonConvert.DeserializeObject<RelativePositionProfile>(jobj.ToString());
                    break;
            }

            return result;
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            serializer.Serialize(writer, value, typeof(IPositionProfile));
        }

        #endregion
    }
}
