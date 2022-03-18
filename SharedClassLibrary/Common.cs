
namespace SharedClassLibrary
{
    public static class Common
    {
        public const int DEFAULT_PAGE_SIZE = 50;
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
