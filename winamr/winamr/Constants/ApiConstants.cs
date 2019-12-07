using System;
using System.Collections.Generic;
using System.Text;

namespace winamr.Constants
{
    public class ApiConstants
    {
        // Place your base API URL here
        public const string BaseApiUrl = "http://192.168.1.35:5000/";

        // Place remaining API URL here
        public const string AuthenticateEndpoint = "api/authentication/authenticate";
        public const string RegisterEndpoint = "api/authentication/register";
    }
}
