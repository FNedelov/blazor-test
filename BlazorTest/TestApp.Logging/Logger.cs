namespace TestApp.Logging
{
    public static class Logger
    {
        public static void AppendLogLineSync(string logDirectory, string fileName, string text)
        {
            string line = $"{DateTime.Now:yyyy-MM-dd HH:mm:ss} \t - {text}";
            string logfile = @$"{logDirectory}{DateTime.Now.Year:0000}_{fileName}.log";

            using StreamWriter w = File.AppendText(logfile);
            w.WriteLine(line);
        }

        public static async Task AppendLogLineAsync(string logDirectory, string fileName, string text)
        {
            string line = $"{DateTime.Now:yyyy-MM-dd HH:mm:ss} \t - {text}";
            string logfile = @$"{logDirectory}{DateTime.Now.Year:0000}_{fileName}.log";

            using StreamWriter w = File.AppendText(logfile);
            await w.WriteLineAsync(line);
        }
    }
}