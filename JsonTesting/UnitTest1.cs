using Microsoft.VisualStudio.TestPlatform.TestHost;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using JsonSerializer2;


namespace JsonTesting
{

    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestIsSuccess()
        {


            Configuration obj = new Configuration(2, "www.training.com", new[] { "192.168.1.8", "192.168.1.2" });

            string actual = Ola.Serialize(obj);

            string expected = "{\"Version\":2,\"DomainName\":\"www.training.com\",\"IpAddresses\":[\"192.168.1.8\",\"192.168.1.2\"]}";



            Assert.AreEqual(expected, actual);



        }

        [TestMethod]
        public void TestIsFailed()
        {


            Configuration obj = new Configuration(55, "www.training.commmm", new[] { "192.168.1.8", "192.168.1.2" });

            string actual = Ola.Serialize(obj);

            string expected = "{\"Version\":2,\"DomainName\":\"www.training.com\",\"IpAddresses\":[\"192.168.1.8\",\"192.168.1.2\"]}";



            Assert.AreEqual(expected, actual);


        }

    


    }

}