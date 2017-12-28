using System;
using System.Collections.Generic;
using System.IO;

namespace SPLogFilter
{
 public static class LogTools
    {
       public enum LogColumn : int
        {
            Timestamp = 0, Process, Tid, Area, Category, EventId, Level, Message, Correlation
        }
    
        public static IReadOnlyList<string> LoadLogFile(string logFilePath)
        {
            if (logFilePath == null) throw new ArgumentNullException(nameof(logFilePath));
            IReadOnlyList<string> allLines = File.ReadAllLines(logFilePath);
            return allLines;
        }

        public static void WriteLogLine(string textLine, string searchTerm, LogTools.LogColumn col)
        {
            try
            {
                var part = GetLogLinePart(textLine, col);
                if (part == (searchTerm.Trim()))
                {
                    if (textLine != null) Console.WriteLine(textLine.Trim());
                }

            }
            catch (Exception)
            {
                throw;
            }
            return;
        }
        public static void FindInLogLine(string textLine, string searchTerm, LogTools.LogColumn col)
        {
            try
            {
                var part = GetLogLinePart(textLine, col);
                if (part.Contains( (searchTerm.Trim())))
                {
                    if (textLine != null) Console.WriteLine(textLine.Trim());
                }

            }
            catch (Exception)
            {
                throw;
            }
            return;
        }

        public static string GetLogLinePart(string strl, LogTools.LogColumn col)
        {
            var part = strl.Split((char)9)[(int)col].Trim();
            return part;

        }

        public static HashSet<string> DistinctColumnSet(IReadOnlyList<string> allLines, LogTools.LogColumn col)
        {
            var set=new HashSet<string>();
            foreach (var line in allLines)
            {
                var colText = GetLogLinePart(line, col);
                if (colText.Length > 1 && colText != col.ToString().Trim())
                {
                    set.Add(colText);
                }

            }
            return set;
        }
    }
}
