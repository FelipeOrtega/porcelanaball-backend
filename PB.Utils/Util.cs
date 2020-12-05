using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;

namespace PB.Utils
{
    public class Util
    {
        public static T deserializarJSonElement<T>(Object inputModel)
        {
            string json = inputModel.ToString();
            return JsonConvert.DeserializeObject<T>(json);
        }
    }
}
