using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CFD33
{
    public class StringWriterEncoding : StringWriter
    {
        public StringWriterEncoding(Encoding encoding)
            : base()
        {
            this.m_Encoding = encoding;
        }
        private readonly Encoding m_Encoding;
        public override Encoding Encoding
        {
            get
            {
                return this.m_Encoding;
            }
        }
    }
}
