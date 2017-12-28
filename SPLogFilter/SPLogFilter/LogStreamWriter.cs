using System.IO;
using System.Text;

namespace SPLogFilter
{
    public class LogStreamWriter : StreamWriter
    {
        //private HashSet<string> set = new HashSet<string>();
        // Inheritance use Sample: conditional WriteLine option 
   
        public override void WriteLine(string value)
        {
            //if (!set.Contains(value))
            //{
                //set.Add(value);
                base.WriteLine(value);
            //}
        }


        public LogStreamWriter(Stream stream) : base(stream)
        {
        }

        public LogStreamWriter(Stream stream, Encoding encoding) : base(stream, encoding)
        {
        }

        public LogStreamWriter(Stream stream, Encoding encoding, int bufferSize) : base(stream, encoding, bufferSize)
        {
        }

        public LogStreamWriter(Stream stream, Encoding encoding, int bufferSize, bool leaveOpen) : base(stream, encoding, bufferSize, leaveOpen)
        {
        }

        public LogStreamWriter(string path) : base(path)
        {
        }

        public LogStreamWriter(string path, bool append) : base(path, append)
        {
        }

        public LogStreamWriter(string path, bool append, Encoding encoding) : base(path, append, encoding)
        {
        }

        public LogStreamWriter(string path, bool append, Encoding encoding, int bufferSize) : base(path, append, encoding, bufferSize)
        {
        }
    }
}