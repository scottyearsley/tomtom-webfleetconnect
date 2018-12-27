using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TomTom.WebFleetConnect.Operations;

namespace TomTom.WebFleetConnect.Models
{
    public class ApiParameters
    {
        private readonly Dictionary<string, string> _parameters = new Dictionary<string, string>();
        
        public ApiParameters(string operationName, object config)
        {
            Create(operationName, config);
        }

        internal ApiParameters()
        {
        }
        
        public string ToQuery()
        {
            return string.Join("&", _parameters.Select(kvp => $"{kvp.Key}={HttpUtility.UrlEncode(kvp.Value)}"));
        }
        
        private void Create(string operationName, object config)
        {
            if (config == null)
            {
                return;
            }
            
            var properties = config.GetType().GetProperties();
            var operationParams = OperationParameters.Map[operationName];

            foreach (var operationParam in operationParams)
            {
                var property = properties.SingleOrDefault(p => p.Name == operationParam.WrapperName);

                if (property != null)
                {
                    var value = property.GetValue(config);

                    if (value != null && value.ToString() != string.Empty)
                    {
                        _parameters.Add(operationParam.ConnectName, value.ToString());
                        continue;
                    }

                    if (value == null && operationParam.Required)
                    {
                        // TODO: Create specific exception type.
                        throw new Exception($"Parameter {operationParam.WrapperName} is required");
                    }
                }
            }
        }
    }
}