using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using converter.Implementors;

namespace converter.Factories
{
    public static class DocumentConverterFactory
    {
        public static IDocumentConverter GetConverter(string format)
        {
            switch (format.ToLower())
            {
                case "doc":
                    return new DocConverter();
                case "pdf":
                    return new PdfConverter();
                case "txt":
                    return new TextConverter();
                default:
                    throw new ArgumentException("Invalid");
                        
            }
        }
    }
}
