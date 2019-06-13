using System;
using Newtonsoft.Json;

namespace Quattro.Core.Common {
    public class JsonTiempoConverter : JsonConverter<Tiempo> {

        public override Tiempo ReadJson(JsonReader reader, Type objectType, Tiempo existingValue, bool hasExistingValue, JsonSerializer serializer) {
            if (reader.ValueType == typeof(long) || reader.ValueType == typeof(int) || reader.ValueType == typeof(short)) {
                int totalMinutos = Convert.ToInt32(reader.Value);
                return new Tiempo(totalMinutos);
            }
            return null;
        }

        public override void WriteJson(JsonWriter writer, Tiempo value, JsonSerializer serializer) {
            writer.WriteValue(value.TotalMinutos);
        }
    }
}
