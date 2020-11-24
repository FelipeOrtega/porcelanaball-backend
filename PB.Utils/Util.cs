using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;

namespace PB.Utils
{
    public class Util
    {
        public static Object deserializarJSonElement(Object inputModel)
        {
            JsonElement element = (JsonElement)inputModel;
            var json = element.GetRawText();
            return System.Text.Json.JsonSerializer.Deserialize<Object>(json);
        }
    }
}
