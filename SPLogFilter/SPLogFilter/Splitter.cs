using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace SPLogFilter
{
    static class Splitter
    {

        public static void Split(string logFilePath, IReadOnlyList<string> allLines, LogTools.LogColumn col, string splitFolder = "")
        {

            var sourceFolder = Path.GetDirectoryName(logFilePath);

            if (splitFolder == "")
            {
                splitFolder = string.Concat(sourceFolder, @"\By",col.ToString(),@"\");
            }
            if (Directory.Exists(splitFolder))
            {
                Directory.Delete(splitFolder, true);
                Directory.CreateDirectory(splitFolder);
            }
            else
            {
                Directory.CreateDirectory(splitFolder);
            }

            var headersLine = allLines[0];
            foreach (var term in LogTools.DistinctColumnSet(allLines, col))
            {

                using (var writer = new LogStreamWriter(string.Concat(splitFolder, term, ".mgx"), true))
                {
                    Console.SetOut(writer);
                    Console.WriteLine(headersLine);
                    var lines = allLines;
                    Parallel.For(0, allLines.Count, x => LogTools.WriteLogLine(lines[x], term, col));
                }


            }
            allLines = null;
        }

      
    }
}
