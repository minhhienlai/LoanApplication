using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharedClassLibrary
{
    public static class Common
    {
        public static string CreateJsonMessage(string key, string value)
        {
            return "{'" + key + "'}:{'" + value + "'}";
        }
    }
}
