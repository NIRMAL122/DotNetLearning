using System.Text;

namespace Logger
{
    public sealed class Log:ILog
    {
        private static readonly Lazy<Log> obj= new Lazy<Log>(() => new Log());
        private Log()
        {

        }

        public static Log getInstance()
        {
            return obj.Value;
        }

        public void LogException(string message)
        {
            string fileName = string.Format("{0}.log", "Exception");
            string logFilePath= string.Format(@"{0}\{1}",
                AppDomain.CurrentDomain.BaseDirectory, fileName);

            //...\bin\Debug\net6.0 -> exceptionfile is present at this location
            StringBuilder sb = new StringBuilder();
            sb.Append("--------------");
            sb.Append(DateTime.Now.ToString());
            sb.Append(message);

            using(StreamWriter writer = new StreamWriter(logFilePath,true))
            {
                writer.Write(sb.ToString());
                writer.Flush();
            }
        }
    }
}