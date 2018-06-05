using Newtonsoft.Json;
using Api.Models;
using Api.ViewModels;

namespace Api.helper
{

    public class JsonHelper
    {
        private JsonResponse jr;

        public JsonHelper()
        {
            jr = new JsonResponse();
        }

        public JsonHelper(JsonResponse jsonresponse)
        {
            jr = jsonresponse;
        }

        public string asJson()
        {
            return JsonConvert.SerializeObject(jr, Formatting.None);
        }

        public void adddBeans(object beans)
        {
            if (beans != null)
                jr.data = beans;
        }

        public void addAlert(string type, string text)
        {
            jr.alerts.Add(new Alert { type = type, text = text });
        }

    }
}
