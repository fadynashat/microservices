using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Features;

namespace FADY.Services.Lookup.API
{
    internal class TestHttpResponseTrailersFeature : IHttpResponseTrailersFeature
    {
        public IHeaderDictionary Trailers { get; set; }
    }
}