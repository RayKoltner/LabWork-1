using System.Text.Json;
using System.Text.Json.Serialization;

namespace Lab1
{
    internal class DateConverter : JsonConverter<DateTime>
    {
        public override DateTime Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            throw new NotImplementedException();
        }

        public override void Write(Utf8JsonWriter writer, DateTime value, JsonSerializerOptions options)
        {
            if (value != DateTime.MinValue)
            {
                JsonSerializer.Serialize(writer, value.ToShortDateString(), options);
            }
            else
            {
                JsonSerializer.Serialize(writer, "", options);
            }
        }
    }
}
