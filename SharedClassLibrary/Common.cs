﻿
namespace SharedClassLibrary
{
    public static class Common
    {
        public static string CreateJsonMessage(string key, string value)
        {
            return "{'" + key + "'}:{'" + value + "'}";
        }
        public static string CreateMessage(string key, string value)
        {
            return key + value;
        }
    }
}
