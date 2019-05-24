using System.Collections.Generic;
using RONC.Domain;
using RONC.Domain.DataObject;
using Shouldly;
using Xunit;

namespace RONC.UnitTest.BackEndTests
{
    public class ArticleDeserializerShould
    {
        string errorString =
            @"{""status"":""error"",""code"":""apiKeyMissing"",""message"":""Your API key is missing. Append this to the URL with the apiKey param, or use the x-api-key HTTP header.""}";
        [Fact]
        public void ReturnValidAndStatusOkJsonStringAsPOCO()
        {
            var deserializer = new ArticleDeserializer();

            var testString =
                @"{""status"":""ok"",""totalResults"":1,""articles"":[{""source"":{""id"":""fox-news"",""name"":""Fox News""},""author"":""Samuel Chamberlain"",""title"":""Michael Avenatti indicted on charges of defrauding ex-client Stormy Daniels, identity theft - Fox News"",""description"":""Embattled attorney Michael Avenatti was charged by federal prosecutors in New York Wednesday with defrauding adult film star Stormy Daniels, the client who propelled Avenatti into the national spotlight."",""url"":""https://www.foxnews.com/us/michael-avenatti-indicted-defrauding-stormy-daniels-identity-theft"",""urlToImage"":""https://static.foxnews.com/foxnews.com/content/uploads/2018/09/stormy-avenatti.jpg"",""publishedAt"":""2019-05-22T19:04:22Z"",""content"":""Embattled attorney Michael Avenatti was charged by federal prosecutors in New York Wednesday with defrauding adult-film star Stormy Daniels, the client who propelled Avenatti into the national spotlight.\r\nAvenatti, 48, faces one count of wire fraud and one co… [+6027 chars]""}]}";

            deserializer.Convert(testString).ShouldBeOfType<List<ApiDataResponse>>();
        } 
        
        [Fact]
        public void ReturnTitlePropertyMatchingPassedJsonObject()
        {
            var deserializer = new ArticleDeserializer();

            var expectedTitle =
                "Michael Avenatti indicted on charges of defrauding ex-client Stormy Daniels, identity theft - Fox News";
            
            var testString =
                @"{""status"":""ok"",""totalResults"":1,""articles"":[{""source"":{""id"":""fox-news"",""name"":""Fox News""},""author"":""Samuel Chamberlain"",""title"":""Michael Avenatti indicted on charges of defrauding ex-client Stormy Daniels, identity theft - Fox News"",""description"":""Embattled attorney Michael Avenatti was charged by federal prosecutors in New York Wednesday with defrauding adult film star Stormy Daniels, the client who propelled Avenatti into the national spotlight."",""url"":""https://www.foxnews.com/us/michael-avenatti-indicted-defrauding-stormy-daniels-identity-theft"",""urlToImage"":""https://static.foxnews.com/foxnews.com/content/uploads/2018/09/stormy-avenatti.jpg"",""publishedAt"":""2019-05-22T19:04:22Z"",""content"":""Embattled attorney Michael Avenatti was charged by federal prosecutors in New York Wednesday with defrauding adult-film star Stormy Daniels, the client who propelled Avenatti into the national spotlight.\r\nAvenatti, 48, faces one count of wire fraud and one co… [+6027 chars]""}]}";
            
            var result = deserializer.Convert(testString);

            result[0].Title.ShouldBe(expectedTitle);
        } 

        [Fact]
        public void ReturnsArticleWithErrorMessageIfStatusNotOk()
        {
            var deserializer = new ArticleDeserializer();

            var result = deserializer.Convert(errorString);
            
            result[0].Error.Message.ShouldContain("Your API key is missing");
        }
        
    }

}