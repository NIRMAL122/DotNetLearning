using NetworkUtility.DNS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;

namespace NetworkUtility.Ping
{
    public class NetworkServices
    {
        private readonly IDNS _dns;
        public NetworkServices(IDNS dns)
        {
            _dns=dns;
        }
        
        public string SendPing()
        {
            var DNSsuccess = _dns.SendDNS();
            if (DNSsuccess)
            {
                return "Success: Ping Sent!";
            }
            else
            {
                return "Failed: Ping not Sent!";
            }
        }

        public int PingTimeout(int a,int b)
        {
            return a + b;
        }

        public DateTime LastPingDate()
        {
            return DateTime.Now;
        }

        public PingOptions GetPingOptions()
        {
            return new PingOptions()
            {
                DontFragment = true,
                Ttl = 1
            };
        }

        public IEnumerable<PingOptions> GetPingOptionsList()
        {
            IEnumerable<PingOptions> pingOptions = new[]
            {
                new PingOptions()
                {
                    DontFragment = true,
                    Ttl = 1
                },
                new PingOptions()
                {
                    DontFragment = false,
                    Ttl = 2
                },
                new PingOptions()
                {
                    DontFragment = true,
                    Ttl = 3
                }
            };

            return pingOptions;
        }
    }
}
