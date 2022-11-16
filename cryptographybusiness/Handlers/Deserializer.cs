﻿using Newtonsoft.Json;

namespace cryptographybusiness.Handlers
{
    internal static  class Deserializer 
    {
        internal static Task<(bool success,string message,T? data)> DeserializeString<T>(string content)
        {
            (bool success, string message, T? data) response;
            try
            {
                var result = JsonConvert.DeserializeObject<T>(content);
                response = (true,"success",result);
                return Task.FromResult(response);

            } catch(Exception ex)
            {
                response = (false, ex.Message, default(T));
                return Task.FromResult(response);
            }
        }
    }
}