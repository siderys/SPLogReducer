#region

using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

#endregion

namespace SPLogFilter
{
    public static class TextSearch
    {
        public static void Find(string logFilePath, string findText, IReadOnlyList<string> logFile,
            LogTools.LogColumn col)
        {
            var sourceFolder = Path.GetDirectoryName(logFilePath);
            var splitFolder = string.Concat(sourceFolder, @"\Find", col.ToString(), @"\");

            if (Directory.Exists(splitFolder))
            {
                Directory.Delete(splitFolder, true);
                Directory.CreateDirectory(splitFolder);
            }
            else
            {
                Directory.CreateDirectory(splitFolder);
            }
            var headersLine = logFile[0];
            using (var writer =
                new LogStreamWriter(string.Concat(splitFolder, findText.Substring(0, 36).Replace(" ", ""), ".mgx"),
                    true))
            {
                Console.SetOut(writer);
                Console.WriteLine(headersLine);
                var lines = logFile;
                Parallel.For(0, logFile.Count, x => LogTools.FindInLogLine(lines[x], findText, col));
            }

            return;
        }
    }
}