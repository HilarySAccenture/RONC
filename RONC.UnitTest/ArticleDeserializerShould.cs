using RONC.Domain;
using RONC.Domain.DataObject;
using Shouldly;
using Xunit;

namespace RONC.UnitTest
{
    public class ArticleDeserializerShould
    {
        [Fact]
        public void ReturnValidAndStatusOkJsonStringAsPOCO()
        {
            var deserializer = new ArticleDeserializer();

            var testString =
                @"{""status"":""ok"",""totalResults"":1,""articles"":[{""source"":{""id"":""fox-news"",""name"":""Fox News""},""author"":""Samuel Chamberlain"",""title"":""Michael Avenatti indicted on charges of defrauding ex-client Stormy Daniels, identity theft - Fox News"",""description"":""Embattled attorney Michael Avenatti was charged by federal prosecutors in New York Wednesday with defrauding adult film star Stormy Daniels, the client who propelled Avenatti into the national spotlight."",""url"":""https://www.foxnews.com/us/michael-avenatti-indicted-defrauding-stormy-daniels-identity-theft"",""urlToImage"":""https://static.foxnews.com/foxnews.com/content/uploads/2018/09/stormy-avenatti.jpg"",""publishedAt"":""2019-05-22T19:04:22Z"",""content"":""Embattled attorney Michael Avenatti was charged by federal prosecutors in New York Wednesday with defrauding adult-film star Stormy Daniels, the client who propelled Avenatti into the national spotlight.\r\nAvenatti, 48, faces one count of wire fraud and one co… [+6027 chars]""}]}";

            deserializer.Convert(testString).ShouldBeOfType<Article>();
        } 
    }

}