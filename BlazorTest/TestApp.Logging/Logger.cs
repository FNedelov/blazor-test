namespace TestApp.Logging
{
    public static class Logger
    {
        public static void AppendLogLineSync(string filePath, string fileName, string text)
        {
            string line = $"{DateTime.Now:yyyy-MM-dd HH:mm:ss} \t - {text}";
            string logfile = @$"{filePath}{DateTime.Now.Year:yyyy-MM-dd HH:mm:ss}_{fileName}.log";

            using StreamWriter w = File.AppendText(logfile);
            w.WriteLine(line);
        }

        public static async Task AppendLogLineAsync(string filePath, string fileName, string text)
        {
            string line = $"{DateTime.Now:yyyy-MM-dd HH:mm:ss} \t - {text}";
            string logfile = @$"{filePath}{DateTime.Now.Year:yyyy-MM-dd HH:mm:ss}_{fileName}.log";

            using StreamWriter w = File.AppendText(logfile);
            await w.WriteLineAsync(line);
        }
    }
}