namespace Manastream.Src.UI.JsonConverters
{
    #region Usings

    using System;
    using Manastream.Src.UI.Components.Complex;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Linq;

    #endregion

    /// <summary>
    /// The ui component converter that enables the deserialisation of UI components.
    /// </summary>
    public class UIComponentConverter : JsonConverter
    {
        #region Methods

        public override bool CanConvert(Type objectType)
        {
            return objectType == typeof(UIComponent);
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            object result = null;
            
            var settings = new JsonSerializerSettings();
            settings.Converters.Add(new PositionProfileConverter());

            JObject jobj = JObject.Load(reader);
            
            switch (jobj["type"].Value<string>())
            {
                case "Button":
                     result = JsonConvert.DeserializeObject<Button>(jobj.ToString(), settings);
                    break;

                case "Profile":
                    result = JsonConvert.DeserializeObject<Profile>(jobj.ToString(), settings);
                    break;
            }

            return result;
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            serializer.Serialize(writer, value, typeof(UIComponent));
        }

        #endregion
    }
}
