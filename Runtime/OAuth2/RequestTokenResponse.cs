using System.Collections.Generic;
using System.Runtime.Serialization;
using Newtonsoft.Json;
using UnityEngine.Scripting;

namespace Cdm.Authentication.OAuth2
{
    [Preserve, DataContract]
    public class RequestTokenResponse
    {
        private readonly Dictionary<string, string> _parameters = new();

        public bool TryGetValue(string key, out string value)
        {
            return _parameters.TryGetValue(key, out value);
        }

        public string ToJson() => JsonConvert.SerializeObject(_parameters);

        public void SetResponse(string response, string url)
        {
            _parameters.Clear();
            SplitParameters(response.Substring(url.Length + 1));
        }

        public void SetParameter(string key, string value) => _parameters[key] = value;
        
        private void SplitParameters(string response)
        {
            var split = response.Split('&');
            foreach (var kvp in split)
            {
                var kp = kvp.Split('=');
                if (kp.Length > 1)
                {
                    _parameters[kp[0]] = kp[1];
                }
                else if (kp.Length > 0)
                {
                    _parameters[kp[0]] = null;
                }
            }
        }
    }
}