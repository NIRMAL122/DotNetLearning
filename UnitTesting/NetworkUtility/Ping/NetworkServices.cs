using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetworkUtility.Ping
{
    public class NetworkServices
    {
        public string SendPing()
        {
            return "Success: Ping Sent!";
        }

        public int PingTimeout(int a,int b)
        {
            return a + b;
        }
    }
}
