using System.Collections.Generic;
using RONC.Domain.DataObject;

namespace RONC.Domain
{
    public interface IArticleDeserializer
    {
        List<ApiDataResponse> Convert(string testString);
    }
}