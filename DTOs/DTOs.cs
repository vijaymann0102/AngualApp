using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AngularApp.DTOs
{

    public class RequestDTO
    {
        public string data { get; set; }

        public string result { get; set; }
    }

    public class ResultDTO
    {
        public ResultDTO()
        {
            response = new List<response>();
        }
        public List<response> response;
    }


    public class response
    {
        public string image { get; set; }
        public string slug { get; set; }
        public string title { get; set; }
    }
    public class PayLoad
    {
        public string title { get; set; }
        public string image { get; set; }
        public string slug { get; set; }
    }

    public class ErrorDTO
    {
        public string error { get; set; }
    }
}