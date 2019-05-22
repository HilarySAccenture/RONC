using RONC.Domain;
using Xunit;
using Shouldly;


namespace RONC.UnitTest
{
    public class WrapperShould
    {
        [Fact]
        public void Exist()
        {
            var wrapper = new ApiWrapper();
            
            wrapper.ShouldBeNull();
        }
    }
}