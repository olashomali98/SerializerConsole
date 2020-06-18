using System;

namespace JsonTesting
{
    public class Configuration
    {


        public static void main()
        {
            var cl = new Configuration(55, " OLA", new[] { "4545", "9999" });

        }

        public Configuration(int version, string domainName, string[] ipAddresses)
        {
            Version = version;
            DomainName = domainName;
            IpAddresses = ipAddresses;
        }

        public int Version;
        public string DomainName;
        public string[] IpAddresses;



    }
}
