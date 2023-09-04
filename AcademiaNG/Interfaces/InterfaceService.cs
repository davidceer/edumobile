using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;

namespace AcademiaNG.Interfaces
{
    public interface IHttpClientHandlerService
    {
        HttpClientHandler GetInsecureHandler();
    }
}
