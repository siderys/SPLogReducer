using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SPLogFilter;

namespace Test
{
    class Program
    {
        private static void Main(string[] args)
        {
            const string fileName = @"C:\@Borrar\LogToReduce.log";

            IReadOnlyList<string> logFileLines = LogTools.LoadLogFile(fileName);

            Splitter.Split(fileName, logFileLines, LogTools.LogColumn.Level);
            TextSearch.Find(fileName, "Table RequestUsage_Partition27 has 2066800640 bytes", logFileLines, LogTools.LogColumn.Message);
        }

    }
}
