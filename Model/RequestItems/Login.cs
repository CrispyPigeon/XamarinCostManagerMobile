using System;
using RestSharp.Deserializers;

namespace Model.RequestItems
{
    public class Login
    {
        [DeserializeAs(Name = "access_token")]
        public string Token { get; set; }
        
        [DeserializeAs(Name = ".expires")]
        public DateTime ExpireDate { get; set; }
    }
}
