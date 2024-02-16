using System.Text;

namespace RealEstate.Data.Helpers
{
    public class ErrorLogger
    {
        public static void LogError(Exception exception)
        {
            string logFilePath = @"C:\ErrorLog\RealEstateConstruction_LogFile.txt";

            // Ensure the directory exists
            string directoryPath = Path.GetDirectoryName(logFilePath);
            if (!Directory.Exists(directoryPath))
            {
                Directory.CreateDirectory(directoryPath);
            }

            // Prepend the log message to the log file
            string logMessage = GetLogMessage(exception);
            string existingContent = File.Exists(logFilePath) ? File.ReadAllText(logFilePath) : string.Empty;
            string updatedContent = logMessage + existingContent;
            File.WriteAllText(logFilePath, updatedContent);
        }

        private static string GetLogMessage(Exception exception)
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"[{DateTime.Now}]");
            sb.AppendLine($"Message: {exception.Message}");
            sb.AppendLine($"Stack Trace: {exception.StackTrace}");
            sb.AppendLine("--------------------------------------------------");

            if (exception.InnerException != null)
            {
                sb.AppendLine("Inner Exception:");
                sb.AppendLine(GetLogMessage(exception.InnerException));
            }

            return sb.ToString();
        }

    }
}
