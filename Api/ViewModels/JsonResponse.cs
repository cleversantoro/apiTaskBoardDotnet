using System.Collections.Generic;

namespace Api.ViewModels
{
    public class JsonResponse
    {
        public string message { get; set; }
        public object data { get; set; }
        public IList<Alert> alerts { get; set; }
    }

}
